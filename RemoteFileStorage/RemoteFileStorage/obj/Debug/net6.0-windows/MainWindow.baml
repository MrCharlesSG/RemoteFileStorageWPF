   M S B A M L   `   `   `  ����L  HRemoteFileStorage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:RemoteFileStorageRemoteFileStorage  5   	   "    RemoteFileStorage.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:RemoteFileStorage     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �    GradientBackground#��[  5   	   .+�5   
   �� -   5         ��Name$ lbItems��5       �� DisplayMemberPath$
 Name��5      $	��250��5      $��50,92,470,92q�6   �� 5   
   $��Choose directory:��6   $
��Left=�6,   $��	50,43,0,0q�6G   $	��Top=�6Z    J� RenderTransformOrigin$ -1.842,0.579&�6r   �� 5   
   -   5         ��Name$ cbDirectories��5       �� 
IsEditable$
 True��5      $
��Left=�5      $��
180,45,0,0q�6(   $	��Top=�6<   $	��150��6T   �� 5   
   -   5         ��Name$ 	btnUpload��5      $��Upload��5      
���   �$
��Left=�5      $��
50,364,0,0q�6(   $	��Top=�6<   $��70��6T   �� 5   
   -   5        $ btnDownload��5      $��Download��5       
���/kU�$
��Left=�5#      $��155,364,0,0q�6(   $	��Top=�6=   $��70��6U   �� 5$   
   -   5        $ 	btnDelete��5%      $��Delete��5&      
���  ��$
��Left=�5)      $��260,364,0,0q�6(   $	��Top=�6=   $��70��6U   �� 5+   
   $
��Auto=�6   $��400,45,0,50q�6:   .��5,      �� .+�5-      �� $��Content type:��6   $
��Left=�60   $	��Top=�6K   �� 5.       �� 
IsReadOnly$
 True��6O   $
��Left=�6a   	 �� TextWrapping$
	 Wrap=�6|   $	��Top=�6�   $	��363��6�   $��24��6�   ��6   �� *Properties.ContentType+
 �� Mode$
 OneWay=�6�   �� 50      $��Content size:��6   $
��Left=�60   $	��Top=�6K   �� 51      $
 True��6Q   $
��Left=�6c   $
	 Wrap=�6~   $	��363��6�   $��24��6�   ��6   �� *Properties.ContentLength+$
 OneWay=�6�   �� 53      $��Date Created:��6   $
��Left=�60   $	��Top=�6K   �� 54      $
 True��6M   $
��Left=�6_   $
	 Wrap=�6z   $	��Top=�6�   $	��363��6�   $��24��6�   ��6   �� *Properties.CreatedOn+$
 OneWay=�6�   �� 56      $��Last modified:��6   $
��Left=�61   $	��Top=�6L   �� 57      $
 True��6P   $
��Left=�6b   $
	 Wrap=�6}   $	��Top=�6�   $	��363��6�   $��24��6�   ��6   �� *Properties.LastModified+$
 OneWay=�6�   �� 59      $��Server encrypted:��6   $
��Left=�64   $	��Top=�6O   �� 5:      $
 True��6S   $
��Left=�6e   $
	 Wrap=�6�   $	��Top=�6�   $��55��6�   $��24��6�   ��6   �� *Properties.ServerEncrypted+$
 OneWay=�6�   �� 5=      -   5         ��Name$ pictureBorder��5?      $	��200��5=      $	��300��5>      
�������$��1q�5@   !   $��2��65   ._�5A      �� -   5         ��Name$ picture��5B      $��Uniform=�5C      ��5D      �� *Image+5F      5G      5H      5K      5L      