using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Win32;
using RemoteFileStorage.Dal;
using RemoteFileStorage.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RemoteFileStorage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ItemsViewModel itemsViewModel;
        public MainWindow()
        {
            InitializeComponent();
            itemsViewModel = new ItemsViewModel();
            Init();
        }

        private void Init()
        {
            cbDirectories.ItemsSource = itemsViewModel.Directories;
            lbItems.ItemsSource = itemsViewModel.Items;
        }

        private async void LbItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if(lbItems.SelectedItem != null)
            {
                BlobItem selectedItem = (BlobItem)lbItems.SelectedItem;
                DataContext = selectedItem;
                var blobClient = Repository.Container.GetBlobClient(selectedItem.Name);
                BlobDownloadInfo blobDownloadInfo = await blobClient.DownloadAsync();
                Stream image = blobDownloadInfo.Content;
                picture.Source = Convert(image);
            }
        }

        public BitmapImage? Convert(object value)
        {
            if (value is Stream stream)
            {
                try
                {
                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();

                    return bitmapImage;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error converting BitmapImage: {ex.Message}");
                }
            }

            return null;
        }

        private void CbDirectories_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                itemsViewModel.Directory = cbDirectories.Text.Trim();
                cbDirectories.Text = itemsViewModel.Directory;
            }
        }

        private void CbDirectories_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (itemsViewModel.Directories.Contains(cbDirectories.Text))
            {
                itemsViewModel.Directory = cbDirectories.Text;
                cbDirectories.SelectedItem = itemsViewModel.Directory;
            }
        }
        private async void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    await itemsViewModel.UploadAsync(openFileDialog.FileName);
                }
                cbDirectories.Text = itemsViewModel.Directory;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void BtnDownload_Click(object sender, RoutedEventArgs e)
        {
            if (lbItems.SelectedItem is not BlobItem item)
            {
                return;
            }
            var saveFileDialog = new SaveFileDialog()
            {
                FileName = item.Name[(item.Name.LastIndexOf(ItemsViewModel.ForwardSlash) + 1)..]
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                await itemsViewModel.DownloadAsync(item, saveFileDialog.FileName);
            }
            cbDirectories.Text = itemsViewModel.Directory;

        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbItems.SelectedItem is not BlobItem item)
            {
                return;
            }
            await itemsViewModel.DeleteAsync(item);
            cbDirectories.Text = itemsViewModel.Directory;
        }
    }
}
