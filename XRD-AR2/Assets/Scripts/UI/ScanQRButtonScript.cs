using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ScanQRButtonScript : MonoBehaviour
{
    [SerializeField]
    private Canvas menuCanvas;
    [SerializeField]
    private Canvas QRScanningCanvas;

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => ChangeCanvas());
    }

    private void ChangeCanvas()
    {
        Console.WriteLine("Changing canvas");
        if (menuCanvas.enabled)
        {
            // Changing to qr scanning canvas
            QRScanningCanvas.enabled = true;
            menuCanvas.enabled = false;
            return;
        }

        // Changing to menu canvas
        menuCanvas.enabled = true;
        QRScanningCanvas.enabled = false;
        return;
    }
}
