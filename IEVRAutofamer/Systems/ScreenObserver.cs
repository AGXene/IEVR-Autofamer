using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using WpfScreenHelper;

namespace IEVRAutofamer.Systems
{
    //Use this class to read the pixels data of the screen and get/find all 
    //the existing active monitors in the system.
    public class ScreenObserver
    {
        public static IEnumerable<Screen> GetAllScreens()
        {
            return Screen.AllScreens;
        }

        public static Bitmap? TakeScreenshot(Screen screen)
        {
            try
            {
                Rect rect = screen.Bounds;
                Bitmap bitmap = new Bitmap((int)rect.Width, (int)rect.Height, PixelFormat.Format32bppArgb);
                Graphics graphics = Graphics.FromImage(bitmap);

                System.Drawing.Size size = new System.Drawing.Size((int)rect.Size.Width, (int)rect.Size.Height);

                graphics.CopyFromScreen((int)rect.Left, (int)rect.Top, 0, 0, size);
                return bitmap;
            }
            catch
            {
                MessageBox.Show("Error taking a screenshot");
                return null;
            }
        }

        public static bool DetectIfBlackScreen(Screen screen, double multiplier)
        {
            var bitmap = TakeScreenshot(screen);
            if (bitmap == null)
            {
                return false;
            }

            var height = bitmap.Height;
            var width = bitmap.Width;

            var blackPixels = 0;
            var pixels = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var pix = bitmap.GetPixel(j, i);
                    if (pix.ToArgb() == Color.Black.ToArgb())
                    {
                        blackPixels++;
                        if (blackPixels >= (width * multiplier))
                        {
                            return true;
                        }
                    }
                    pixels += 1;
                }
                if (blackPixels <= 850 || pixels > (width * multiplier + 150))
                {
                    return false;
                }
            }
            return false;
        }
    }
}
