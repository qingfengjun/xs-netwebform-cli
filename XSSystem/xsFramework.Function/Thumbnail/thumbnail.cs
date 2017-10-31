using System;
using System.IO;
using System.Drawing.Imaging;

namespace xsFramework.Function.Thumbnail
{
    /// <summary>
    /// Function: Get the thumbnail of the image
    /// Author:xs
    /// Create Time:2013/7/9
    /// </summary>
    public class thumbnail
    {
        /// <summary>
        /// convert to thumbnail
        /// </summary>
        /// <param name="myStream">The original image </param>
        /// <param name="savePath"> the save path</param>
        /// <param name="picName"> the name of thumbnail </param>
        /// <param name="height">the height of thumbnail </param>
        /// <param name="width">the width of thumbnail </param>
        /// <returns>success:true</returns>
        public static bool toThumbnail(Stream myStream, string savePath, string picName, int height, int width)
        {

            try
            {
                string suffix = picName.Substring(picName.LastIndexOf("."));//the suffix
                string Extlist = ".bmp.jpg.jpeg.gif.png.tiff.emf.icon.exif.wmf";
                if (Extlist.Contains(suffix))
                {
                    string fileXpath = savePath + picName;//the  save path  of thumbnail
                    System.Drawing.Image myImage = System.Drawing.Image.FromStream(myStream, true);
                    System.Drawing.Image thumbImage = myImage.GetThumbnailImage(width, height, null, System.IntPtr.Zero);
                    thumbImage.Save(fileXpath, thumbnail.getImageFormat(suffix));
                    thumbImage.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }


        /// <summary>
        /// According to the suffix return to save the image format
        /// </summary>
        /// <param name="suffix">image suffix</param>
        /// <returns>save image format</returns>
        private static ImageFormat getImageFormat(string suffix)
        {
            ImageFormat myFormat;

            switch (suffix.ToLower())
            {
                case ".bmp": myFormat = ImageFormat.Bmp; break;
                case ".jpg":
                case ".jpeg": myFormat = ImageFormat.Jpeg; break;
                case ".gif": myFormat = ImageFormat.Gif; break;
                case ".png": myFormat = ImageFormat.Png; break;
                case ".tiff": myFormat = ImageFormat.Tiff; break;
                case ".emf": myFormat = ImageFormat.Emf; break;
                case ".icon": myFormat = ImageFormat.Icon; break;
                case ".exif": myFormat = ImageFormat.Exif; break;
                case ".wmf": myFormat = ImageFormat.Wmf; break;
                default: myFormat = ImageFormat.MemoryBmp; break;

            }
            return myFormat;
        }

    }

}
