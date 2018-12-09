using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using ZXing;
using ZXing.QrCode;

namespace QRCodeGenerator
{
    public class QRCoder
    {

        private static string _outputDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Output");

        public static Bitmap Encode(string content)
        {
            var writer = new BarcodeWriter()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions() { Height = 200, Width = 200 }
            };

            return writer.Write(content);
        }

        public static void Output(string fileName, Bitmap image)
        {
            if (CreateOutputDirectory())
            {
                var file = Path.Combine(_outputDirectory, $"{fileName}.jpg");
                image.Save(file, ImageFormat.Jpeg);
            }
        }

        private static bool CreateOutputDirectory()
        {
            var result = false;

            try
            {
                if (!Directory.Exists(_outputDirectory))
                {
                    Directory.CreateDirectory(_outputDirectory);
                }
                result = true;
            }
            catch { }

            return result;
        }

    }
}
