using Azure.Storage.Blobs.Models;
using RemoteFileStorage.Dal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteFileStorage.ViewModels
{
    internal class ItemsViewModel
    {
        public const string ForwardSlash = "/";

        public ObservableCollection<BlobItem> Items { get; }
        public ObservableCollection<String> Directories { get; }

        private string? directory;
        public string? Directory
        {
            get => directory;
            set
            {
                directory = value;
                Refresh();
            }
        }
        public ItemsViewModel()
        {
            Items = new ObservableCollection<BlobItem>();
            Directories = new ObservableCollection<string>();
            Refresh();

        }

        private void Refresh()
        {
            Directories.Clear();
            Items.Clear();
            Repository.Container.GetBlobs().ToList().ForEach(item =>
            {
                // deal with directories first
                // if there is /, create directory if it does not exist
                if (item.Name.Contains(ForwardSlash))
                {
                    var directory = item.Name[..item.Name.LastIndexOf(ForwardSlash)];
                    if (!Directories.Contains(directory))
                    {
                        Directories.Add(directory);
                    }
                }
                // first, handle all elements from root
                // if directory not set and does not contain /
                if (string.IsNullOrEmpty(Directory) && !item.Name.Contains(ForwardSlash))
                {
                    Items.Add(item);
                }
                // then, handle only the ones in the current selected directory
                // if directory is set and item pertains to it
                else if (!string.IsNullOrEmpty(Directory) && item.Name.StartsWith($"{Directory}{ForwardSlash}"))
                {
                    Items.Add(item);
                }
            });
        }
        //Normally, you would want to return a Task. The main exception should be when you need to have a void return type 
        //(for events). But with void, you have no way of knowing when the function’s task has completed
        //Task can be awaited and its progress checked
        public async Task UploadAsync(string path)
        {
            var filename = path[(path.LastIndexOf(Path.DirectorySeparatorChar) + 1)..];
            var extension = Path.GetExtension(path).TrimStart('.');

            if (string.IsNullOrEmpty(extension) || !isImage(extension))
            {
                throw new Exception("Is not an Image");
            }

            var directory = extension.ToLower(); // Directorio basado en la extensión
            var blobPath = $"{directory}/{filename}";

            using (var fs = File.OpenRead(path))
            {
                await Repository.Container.GetBlobClient(blobPath).UploadAsync(fs, true);
            }

            Refresh();
        }
        public async Task DownloadAsync(BlobItem item,string path)
        {
            using var fs = File.OpenWrite(path);
            await Repository.Container.GetBlobClient(item.Name).DownloadToAsync(fs);
        }
        public async Task DeleteAsync(BlobItem item)
        {
            await Repository.Container.GetBlobClient(item.Name).DeleteAsync();
            Refresh();
        }

        private bool isImage(string extension)
        {
            return extension == "jpg"
                || extension == "png"
                || extension == "jpeg"
                || extension == "tiff"
                || extension == "svg"
                || extension == "gif";
        }

    }
}
