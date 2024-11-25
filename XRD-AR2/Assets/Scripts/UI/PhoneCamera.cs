using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;
    private double lastChecked = -100;

    [SerializeField]
    private RawImage background;
    [SerializeField]
    private AspectRatioFitter fit;
    [SerializeField]
    private double cameraRecheckInterval = 1;

    // Start is called before the first frame update
    void Start()
    {
        defaultBackground = background.texture;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastChecked + cameraRecheckInterval <= Time.timeAsDouble)
        {
            recheckCameras();
            lastChecked = Time.timeAsDouble;
        }

        if (!camAvailable)
            return;

        if (!backCam.isPlaying)
        {
            backCam.Play();
        }
        background.texture = backCam;

        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }

    private void recheckCameras()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            UnsetCamera();
            return;
        }

        WebCamTexture newBackCam = null;
        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing)
            {
                // A safety exit to not override already playing camera
                if (camAvailable && backCam.isPlaying)
                    return;

                newBackCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                break;
            }
        }

        if (!newBackCam) {
            UnsetCamera();
        } else {
            backCam = newBackCam;
            camAvailable = true;
        }
    }

    private void UnsetCamera()
    {
        if (backCam && backCam.isPlaying)
        {
            backCam.Stop();
        }
        background.texture = null;
        backCam = null;
        camAvailable = false;
    }
}
