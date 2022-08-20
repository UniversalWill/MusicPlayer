using System;
using System.IO;
using System.Collections.Generic;
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
using Microsoft.Win32;
using System.Media;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace MusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var path_to_music = dialog.FileName;
                ListMusic.Items.Clear();
                DirectoryInfo folder_with_music = new(path_to_music);
                FileInfo[] Files = folder_with_music.GetFiles("*.mp3");
                foreach (FileInfo file in Files)
                {
                    ListMusic.Items.Add(System.IO.Path.GetFileNameWithoutExtension(file.Name));
                }
            }

        }
    }
}
