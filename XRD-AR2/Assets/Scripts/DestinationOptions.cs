using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Destination
{
    Canteen,
    Reception,
    ElevatorA,
    ElevatorB,
    ElevatorC,
    ElevatorMain
}

public class DestinationManager : MonoBehaviour
{
    public Button canteenButton;
    public Button receptionButton;
    public Button exitButton;

    public Button elevatorAButton;
    public Button elevatorBButton;
    public Button elevatorCButton;
    public Button elevatorMainButton;

    void Start()
    {
        //canteenButton.onClick.AddListener(() => OnDestinationSelected("Canteen"));
        //receptionButton.onClick.AddListener(() => OnDestinationSelected("Reception"));
        //elevatorAButton.onClick.AddListener(() => OnDestinationSelected("ElevatorA"));
        //elevatorBButton.onClick.AddListener(() => OnDestinationSelected("ElevatorB"));
        //elevatorCButton.onClick.AddListener(() => OnDestinationSelected("ElevatorC"));
        //elevatorMainButton.onClick.AddListener(() => OnDestinationSelected("ElevatorMain"));
        exitButton.onClick.AddListener(ExitApplication);
    }

    public void OnDestinationSelected(Destination destinationName)
    {
        Debug.Log("Selected destination: " + destinationName);

        switch (destinationName)
        {
            case Destination.Canteen:
                Debug.Log("Loading AR content for the Canteen...");
                break;
            case Destination.Reception:
                Debug.Log("Loading AR content for the Reception...");
                break;
            case Destination.ElevatorA:
                Debug.Log("Loading AR content for the Elevators...");
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
