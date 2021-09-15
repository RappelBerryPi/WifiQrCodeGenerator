using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Drawing.Imaging;
using System.IO;
using QRCoder;

namespace WifiQrCodeGenerator {
    public class Program {
        public static int Main(string[] args) {
            var rootCommand = new RootCommand
            {
                new Option<FileInfo>(new[] { "-o", "--output-file" }),
                new Option<string>(new[] { "-s", "--ssid" }),
                new Option<string>(new[] { "-p", "--password" }),
                new Option<PayloadGenerator.WiFi.Authentication>(new[] { "-a", "--authentication-method" })
            };
            rootCommand.Handler = CommandHandler.Create<FileInfo, string, string, PayloadGenerator.WiFi.Authentication>(CreateQRCode);

            return rootCommand.Invoke(args);
        }

        public static void CreateQRCode(FileInfo outputFile, string ssid, string password, PayloadGenerator.WiFi.Authentication AuthenticationMethod) {
            var       QrCodeWifiGenerator = new PayloadGenerator.WiFi(ssid, password, AuthenticationMethod);
            var       qrGenerator         = new QRCodeGenerator();
            var       data                = qrGenerator.CreateQrCode(QrCodeWifiGenerator.ToString(), QRCodeGenerator.ECCLevel.Q);
            var       qrCode              = new QRCode(data);
            var       qrCodeImage         = qrCode.GetGraphic(20);
            using var stream              = new MemoryStream();
            var       outputFormat        = GetOutputFileFormat(outputFile);
            qrCodeImage.Save(outputFile.Name, outputFormat);
        }


        private static ImageFormat GetOutputFileFormat(FileInfo outputFile) {
            switch (outputFile.Extension.ToLower()) {
                case ".jpg":
                    return ImageFormat.Jpeg;
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".gif":
                    return ImageFormat.Gif;
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".tiff":
                    return ImageFormat.Tiff;
                case ".png":
                    return ImageFormat.Png;
                default:
                    throw new ArgumentException($"Unknown File Type: {outputFile.Extension}");
            }
        }
    }
}