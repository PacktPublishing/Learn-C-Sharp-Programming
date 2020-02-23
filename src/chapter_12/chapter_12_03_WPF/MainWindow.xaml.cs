using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace chapter_12_03_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _uri = "https://picsum.photos/200";
        private UserInterface _ui = new UserInterface();

        public MainWindow()
        {
            InitializeComponent();
            Debug.WriteLine($"Main TID: {Thread.CurrentThread.ManagedThreadId}");
        }

        // Breaking the task chain – fire and forget
        private async void btWriteFile1_Click(object sender, RoutedEventArgs e)
        {
            await File.WriteAllTextAsync("log.txt", "something");
        }

        // Breaking the task chain – fire and forget
        private void btWriteFile2_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllTextAsync("log.txt", "something");
        }

        /*
            The following code smoothly load 100 pictures
            It demonstrates the use of:
            - ConfigureAwait(false)
            - await foreach
        */
        private async void btDownload_Click(object sender, RoutedEventArgs e)
        {
            await foreach (var info in AsyncLoader(100))
            {
                Debug.WriteLine($"btDownload2_Click 1 TID: {Thread.CurrentThread.ManagedThreadId}");
                icContainer.Items.Add(info);
            }
        }

        async IAsyncEnumerable<ImageInfo> AsyncLoader(int amount)
        {
            foreach (var item in Enumerable.Range(0, amount))
            {
                Debug.WriteLine($"AsyncLoader 1 TID: {Thread.CurrentThread.ManagedThreadId}");
                var info = await GetImageAsync(_uri).ConfigureAwait(false);
                Debug.WriteLine($"AsyncLoader 2 TID: {Thread.CurrentThread.ManagedThreadId}");
                yield return info;
            }
        }

        /// <summary>
        /// Here we use ConfigureAwait to avoid coming back to the UI
        /// thread when we don't really need
        /// </summary>
        private async Task<ImageInfo> GetImageAsync(string uri)
        {
            var imageInfo = new ImageInfo();
            var sw = new Stopwatch();
            sw.Start();
            Debug.WriteLine($"GetImageAsync 1 TID: {Thread.CurrentThread.ManagedThreadId}");
            using var client = new HttpClient();
            using var response = await client.GetAsync(uri).ConfigureAwait(false);
            Debug.WriteLine($"GetImageAsync 2 TID: {Thread.CurrentThread.ManagedThreadId}");
            response.EnsureSuccessStatusCode();
            var blob = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            Debug.WriteLine($"GetImageAsync 3 TID: {Thread.CurrentThread.ManagedThreadId}");
            imageInfo.Blob = blob;
            imageInfo.Title = $"{sw.Elapsed.TotalMilliseconds}ms Size: {blob.Length}";
            return imageInfo;
        }

    }
}
