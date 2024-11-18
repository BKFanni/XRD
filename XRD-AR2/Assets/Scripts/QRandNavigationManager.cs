using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.IO;
using UnityEngine.XR.ARSubsystems;

public class QRandNavigationManager : MonoBehaviour
{
    public ARPathfinding pathfindingScript;  // Reference to your ARPathfinding script
    public ARCameraManager arCameraManager; // Reference to ARCameraManager for capturing images

    private QRScanner qrScanner;

    void Start()
    {
        // Initialize QRScanner
        qrScanner = new QRScanner();
    }

    void Update()
    {
        // Capture camera image and scan QR code
        Texture2D cameraImage = CaptureCameraImage();  // Capture camera image

        if (cameraImage != null)
        {
            // Scan the QR code
            var qrResult = qrScanner.ScanQRCode(cameraImage);

            if (qrResult != null)
            {
                Debug.Log("QR Code Detected: " + qrResult.Text);

                // Based on the QR code, set the start or destination for ARPathfinding
                string[] positionData = qrResult.Text.Split(',');

                if (positionData.Length == 3)
                {
                    float x = float.Parse(positionData[0]);
                    float y = float.Parse(positionData[1]);
                    float z = float.Parse(positionData[2]);

                    Vector3 decodedPosition = new Vector3(x, y, z);

                    // Set the start position in the ARPathfinding script
                    pathfindingScript.SetStartPosition(decodedPosition);
                }
            }
        }
    }

    // Captures the AR camera image
    private Texture2D CaptureCameraImage()
    {
        if (arCameraManager == null)
        {
            Debug.LogWarning("ARCameraManager is not assigned.");
            return null;
        }

        XRCpuImage image;
        if (arCameraManager.TryAcquireLatestCpuImage(out image)) // Acquire the latest image from the camera
        {
            // Convert the image to Texture2D
            Texture2D texture = ConvertCpuImageToTexture(image);
            image.Dispose(); // Always dispose of the image when done
            return texture;
        }

        Debug.LogWarning("Failed to acquire camera image.");
        return null;
    }

    // Converts AR camera XRCpuImage to a Texture2D
    private Texture2D ConvertCpuImageToTexture(XRCpuImage cpuImage)
    {
        // Set up Texture2D
        Texture2D texture = new Texture2D(cpuImage.width, cpuImage.height, TextureFormat.RGBA32, false);

        // Create a conversion parameter
        XRCpuImage.ConversionParams conversionParams = new XRCpuImage.ConversionParams
        {
            inputRect = new RectInt(0, 0, cpuImage.width, cpuImage.height),
            outputDimensions = new Vector2Int(cpuImage.width, cpuImage.height),
            outputFormat = TextureFormat.RGBA32,
            transformation = XRCpuImage.Transformation.None
        };

        // Allocate texture buffer
        var rawTextureData = texture.GetRawTextureData<byte>();
        cpuImage.Convert(conversionParams, rawTextureData);
        texture.Apply(); // Apply the converted data to the texture

        return texture;
    }
}
