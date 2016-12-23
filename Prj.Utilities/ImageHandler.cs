using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Prj.Utility.Common
{
  public  class ImageHandler
    {
        public static bool UploadsImage(string urlPath, Image image, string fileName)
        {

            bool result = false;
            string vFileName = urlPath + "\\" + fileName;
            try
            {
                if (!System.IO.Directory.Exists(urlPath))
                {
                    System.IO.Directory.CreateDirectory(urlPath);
                }

                if (fileName.ToLower().Contains(".jpg") || fileName.ToLower().Contains(".jpeg"))
                {
                    image.Save(vFileName, ImageFormat.Jpeg);
                }
                else if (fileName.ToLower().Contains(".png"))
                {
                    image.Save(vFileName, ImageFormat.Png);
                }
                else
                {
                    image.Save(vFileName, ImageFormat.Jpeg);
                }
               
                result = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return result;
        }



        #region Private Methods
        public static Image HardResizeImage(int width, int height, Image image)
        {
            if (image.Width < width || image.Height < height) return image;
            Image resized = null;
            resized = width > height ? ResizeImage(width, width, image) : ResizeImage(height, height, image);
            Image output = CropImage(resized, height, width);
            return output;
        }

        public static MemoryStream ResizeImage(Image imgToResize, Size size)
        {
            try
            {
                //var ms = new MemoryStream(b);
                //var imgToResize = Image.FromStream(ms, true, true);

                int sourceWidth = imgToResize.Width;
                int sourceHeight = imgToResize.Height;

                float nPercent = 0;
                float nPercentW = 0;
                float nPercentH = 0;

                nPercentW = ((float)size.Width / (float)sourceWidth);
                nPercentH = ((float)size.Height / (float)sourceHeight);

                nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;

                int destWidth = (int)(sourceWidth * nPercent);
                int destHeight = (int)(sourceHeight * nPercent);

                Bitmap newBitmap = new Bitmap(destWidth, destHeight);
                Graphics g = Graphics.FromImage((Image)newBitmap);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
                g.Dispose();

                var oMemoryStream = new MemoryStream();
                newBitmap.Save(oMemoryStream, ImageFormat.Jpeg);

                return oMemoryStream;
            }
            catch (Exception ex)
            {
                ex.ToString();
              //  _loggingService.WebError(string.Format("Function: CommonHelper - ResizeImage \r\n Exception: {0}", ex));
            }
            return null;
        }

        public static Image HardResizeImage(int width, int height, MemoryStream ms)
        {
            var image = Image.FromStream(ms, true, true);
            if (image.Width < width || image.Height < height) return image;
            Image resized = null;
            resized = width > height ? ResizeImage(width, width, image) : ResizeImage(height, height, image);
            Image output = CropImage(resized, height, width);
            return output;
        }

        public static Image ResizeImage(int maxWidth, int maxHeight, Image image)
        {
            using (var bitmapImage = new Bitmap(image))
            {
                int width = bitmapImage.Width;
                int height = bitmapImage.Height;
                if (width > maxWidth || height > maxHeight)
                {
                    //The flips are in here to prevent any embedded image thumbnails -- usually from cameras
                    //from displaying as the thumbnail image later, in other words, we want a clean
                    //resize, not a grainy one.
                    bitmapImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipX);
                    bitmapImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipX);

                    float ratio = 0;
                    if (width > height)
                    {
                        ratio = (float)width / (float)height;
                        width = maxWidth;
                        height = Convert.ToInt32(Math.Round((float)width / ratio));
                    }
                    else
                    {
                        ratio = (float)height / (float)width;
                        height = maxHeight;
                        width = Convert.ToInt32(Math.Round((float)height / ratio));
                    }

                    //return the resized image
                    return bitmapImage.GetThumbnailImage(width, height, null, IntPtr.Zero);
                }

                //return the original resized image
                return image;
            }
        }

        public static Image CropImage(Image image, int height, int width)
        {
            try
            {
                //check the image height against our desired image height
                if (image.Height < height)
                {
                    height = image.Height;
                }

                if (image.Width < width)
                {
                    width = image.Width;
                }

                //create a bitmap window for cropping
                using (var bmPhoto = new Bitmap(width, height, PixelFormat.Format24bppRgb))
                {
                    bmPhoto.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                    //create a new graphics object from our image and set properties
                    Graphics grPhoto = Graphics.FromImage(bmPhoto);
                    //grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
                    //grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    //grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    //now do the crop
                    grPhoto.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel);
                    return image;
                    // Save out to memory and get an image from it to send back out the method.
                    //using (var mm = new MemoryStream())
                    //{
                    //    bmPhoto.Save(mm, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //    image.Dispose();
                    //    bmPhoto.Dispose();
                    //    grPhoto.Dispose();
                    //    Image outimage = Image.FromStream(mm);

                    //    return outimage;
                    //}

                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error cropping image, the error was: " + ex.Message);
            }
        }

        public static void WriteFile(Image img, string path, string imageName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(path + imageName, FileMode.Create, FileAccess.ReadWrite))
                {
                    img.Save(ms, ImageFormat.Jpeg);
                    byte[] bytes = ms.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                    fs.Dispose();
                }
            }
        }

        public static void WriteFile(MemoryStream ms, string path, string imageName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            {
                using (var fs = new FileStream(path + imageName, FileMode.Create, FileAccess.ReadWrite))
                {
                    byte[] bytes = ms.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                    //fs.Close();
                    //fs.Dispose();
                }
            }
        }

        public static void WriteFile(Image img, string file)
        {
            var extension = Path.GetExtension(file);
            using (var ms = new MemoryStream())
            {
                using (var fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite))
                {
                    switch (extension)
                    {
                        case ".png": img.Save(ms, ImageFormat.Png); break;
                        case ".gif": img.Save(ms, ImageFormat.Gif); break;
                        case ".bmp": img.Save(ms, ImageFormat.Gif); break;
                        default: img.Save(ms, ImageFormat.Jpeg); break;
                    }

                    byte[] bytes = ms.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                    fs.Dispose();
                }
            }
        }

        public static Image AddWaterMarkText(Image imgPhoto, string watermarkText)
        {
            var phWidth = imgPhoto.Width;
            var phHeight = imgPhoto.Height;
            var bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(72, 72);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
            grPhoto.DrawImage(imgPhoto, new Rectangle(0, 0, phWidth, phHeight), 0, 0, phWidth, phHeight, GraphicsUnit.Pixel);
            var sizes = new int[] { 20, 18, 16, 14, 12, 8, 6 };
            Font crFont = null;
            var crSize = new SizeF();
            for (int i = 0; i < 7; i++)
            {
                crFont = new Font("Tohama", sizes[i], FontStyle.Bold);
                crSize = grPhoto.MeasureString(watermarkText, crFont);

                if ((ushort)crSize.Width < (ushort)phWidth)
                    break;
            }
            var yPixlesFromBottom = (int)(phHeight * .05);
            float yPosFromBottom = ((phHeight - yPixlesFromBottom) - (crSize.Height / 2));
            float xCenterOfImg = phWidth / 2;

            var strFormat = new StringFormat
            {
                Alignment = StringAlignment.Center
            };
            var semiTransBrush2 = new SolidBrush(Color.FromArgb(153, 0, 0, 0));

            grPhoto.DrawString(watermarkText, crFont, semiTransBrush2, new PointF(xCenterOfImg + 1, yPosFromBottom + 1), strFormat);

            var semiTransBrush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));

            grPhoto.DrawString(watermarkText, crFont, semiTransBrush, new PointF(xCenterOfImg, yPosFromBottom), strFormat);

            return bmPhoto;
        }

        // Match the orientation code to the correct rotation:

        public static ImageFormat GetImageFormat(string ext)
        {
            switch (ext)
            {
                case "bmp": return ImageFormat.Bmp;
                case "gif": return ImageFormat.Gif;
                case "jpg": case "jpeg": return ImageFormat.Jpeg;
                case "png": return ImageFormat.Png;
                default: return null;
            }
        }

        public static RotateFlipType OrientationToFlipType(string orientation)
        {
            switch (int.Parse(orientation))
            {
                case 1:
                    return RotateFlipType.RotateNoneFlipNone;
            
                case 2:
                    return RotateFlipType.RotateNoneFlipX;
               
                case 3:
                    return RotateFlipType.Rotate180FlipNone;
               
                case 4:
                    return RotateFlipType.Rotate180FlipX;
             
                case 5:
                    return RotateFlipType.Rotate90FlipX;
              
                case 6:
                    return RotateFlipType.Rotate90FlipNone;
                
                case 7:
                    return RotateFlipType.Rotate270FlipX;
                
                case 8:
                    return RotateFlipType.Rotate270FlipNone;
                  
                default:
                    return RotateFlipType.RotateNoneFlipNone;
            }
        }
        #endregion
    }
}
