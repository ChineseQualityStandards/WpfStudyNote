using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfStudyNote.Services
{
    public static class ImageHelper
    {
        /// <summary>
        /// 将 BitmapImage 转换为 Base64 字符串
        /// </summary>
        /// <param name="bitmapImage">要转换的 BitmapImage</param>
        /// <returns>Base64 字符串</returns>
        public static string BitmapImageToBase64(BitmapImage bitmapImage)
        {
            if (bitmapImage == null)
                throw new ArgumentNullException(nameof(bitmapImage));

            byte[] data;
            GifBitmapEncoder encoder = new GifBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));

            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }

            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// 将 Base64 字符串转换回 BitmapImage
        /// </summary>
        /// <param name="base64String">Base64 字符串</param>
        /// <returns>BitmapImage</returns>
        public static BitmapImage Base64ToBitmapImage(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
                throw new ArgumentNullException(nameof(base64String));

            byte[] data = Convert.FromBase64String(base64String);
            BitmapImage bitmapImage = new BitmapImage();

            using (MemoryStream ms = new MemoryStream(data))
            {
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze(); // 确保图像在不同线程中使用时不会引发异常
            }

            return bitmapImage;
        }
    }
}
