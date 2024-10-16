using UnityEngine;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

public class QRScanner
{
    private QRCodeReader qrCodeReader;

    public QRScanner()
    {
        qrCodeReader = new QRCodeReader(); // Directly using QRCodeReader
    }

    public Result ScanQRCode(Texture2D cameraImage)
    {
        LuminanceSource source = new Color32LuminanceSource(cameraImage.GetPixels32(), cameraImage.width, cameraImage.height);
        BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
        var result = qrCodeReader.decode(bitmap);
        return result;
    }
}

public class Color32LuminanceSource : BaseLuminanceSource
{
    // Constructor accepting Color32[] array
    public Color32LuminanceSource(Color32[] color32Array, int width, int height)
        : base(width, height)
    {
        for (int i = 0; i < color32Array.Length; i++)
        {
            // Convert the Color32 pixel to luminance (grayscale)
            var color = color32Array[i];
            int luminance = (int)(0.2126f * color.r + 0.7152f * color.g + 0.0722f * color.b);  // Standard luminance formula
            luminances[i] = (byte)luminance;
        }
    }

    // Constructor for handling new luminances (byte[])
    private Color32LuminanceSource(byte[] luminances, int width, int height)
        : base(width, height)
    {
        System.Array.Copy(luminances, this.luminances, luminances.Length); // Copy the luminances directly
    }

    // CreateLuminanceSource override to create a new instance with a luminance array
    protected override LuminanceSource CreateLuminanceSource(byte[] newLuminances, int width, int height)
    {
        return new Color32LuminanceSource(newLuminances, width, height); // Handle byte[] for luminances
    }
}