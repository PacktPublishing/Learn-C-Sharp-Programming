using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace chapter_12_03_WPF
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string resourceImage)
            {
                return GetImageFromPack(resourceImage);
            }

            if (value is byte[] blobImage)
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                using (var ms = new MemoryStream())
                {
                    ms.Write(blobImage.AsSpan());
                    ms.Seek(0, SeekOrigin.Begin);
                    image.StreamSource = ms;
                    image.StreamSource.Seek(0, SeekOrigin.Begin);
                    image.EndInit();
                }

                return image;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static BitmapImage GetImageFromPack(string resourceName)
        {
            Uri uri = new Uri("pack://application:,,,/" + resourceName, UriKind.RelativeOrAbsolute);
            return new BitmapImage(uri);
        }

    }
}
