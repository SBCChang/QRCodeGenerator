using System.Drawing;
using ZXing;
using ZXing.QrCode;

namespace QRCodeGenerator
{
    public class QRCoder
    {

        public static Bitmap Encode(string content)
        {
            var writer = new BarcodeWriter()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions() { Height = 200, Width = 200 }
            };

            return writer.Write(content);
        }

    }
}
