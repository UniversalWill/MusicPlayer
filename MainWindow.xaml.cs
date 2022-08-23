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
    public partial class MainWindow : Window
    {
        private readonly MediaPlayer mediaPlayer = new();

        private FileInfo[]? files = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        public FileInfo[]? GetFiles()
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            FileInfo[]? Files = null;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var path_to_music = dialog.FileName;
                DirectoryInfo folder_with_music = new(path_to_music);
                Files = folder_with_music.GetFiles("*.mp3");
            }
            return Files;
        }

        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            files = GetFiles();
            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    ListMusic.Items.Add(System.IO.Path.GetFileNameWithoutExtension(file.Name));
                }
            }
             
        }

        private void PlayTrack_Click(object sender, RoutedEventArgs e)
        {
            if (files != null)
            {
                int selected_music = ListMusic.SelectedIndex;
                mediaPlayer.Open(new Uri(files[selected_music].ToString()));
                mediaPlayer.Play();
            }
        }
    }
}
