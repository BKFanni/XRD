using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ScanQRButtonScript : MonoBehaviour
{
    [SerializeField]
    private string mainSceneName = "NewMainScene";
    [SerializeField]
    private string QRScanningScene = "QRScanScene";

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => SwitchScene());
    }

    private void SwitchScene()
    {
        var activeScene = SceneManager.GetActiveScene();
        if (activeScene.name.Equals(mainSceneName))
        {
            SceneManager.LoadScene(QRScanningScene);
            return;
        }

        SceneManager.LoadScene(mainSceneName);
    }
}
