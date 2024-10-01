using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestinationManager : MonoBehaviour
{
    public Button canteenButton;
    public Button receptionButton;
    public Button elevatorsButton;
    public Button toiletsButton;
    public Button exitButton;

    void Start()
    {
        canteenButton.onClick.AddListener(() => OnDestinationSelected("Canteen"));
        receptionButton.onClick.AddListener(() => OnDestinationSelected("Reception"));
        elevatorsButton.onClick.AddListener(() => OnDestinationSelected("Elevators"));
        toiletsButton.onClick.AddListener(() => OnDestinationSelected("Toilets"));
        exitButton.onClick.AddListener(ExitApplication);
    }

    public void OnDestinationSelected(string destinationName)
    {
        Debug.Log("Selected destination: " + destinationName);

        switch (destinationName)
        {
            case "Canteen":
                Debug.Log("Loading AR content for the Canteen...");
                break;
            case "Reception":
                Debug.Log("Loading AR content for the Reception...");
                break;
            case "Elevators":
                Debug.Log("Loading AR content for the Elevators...");
                break;
            case "Toilets":
                Debug.Log("Loading AR content for the Toilets...");
                break;
            default:
                Debug.Log("Unknown destination");
                break;
        }
    }

    public void ExitApplication()
    {
        Debug.Log("Exiting the application...");
        Application.Quit();
    }
}
