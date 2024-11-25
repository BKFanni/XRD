using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

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
    // Reference to the NavMeshAgent for navigation
    public NavMeshAgent agent;

    // Destination transforms
    public Transform canteenDest;
    public Transform receptionDest;
    public Transform elevatorADest;
    public Transform elevatorBDest;
    public Transform elevatorCDest;
    public Transform elevatorMainDest;

    // UI buttons
    public Button canteenButton;
    public Button receptionButton;
    public Button elevatorAButton;
    public Button elevatorBButton;
    public Button elevatorCButton;
    public Button elevatorMainButton;
    public Button exitButton;

    // Reference to the MenuCanvas
    public GameObject menuCanvas;
 
    // Current destination transform
    private Transform currentDestination;

    void Start()
    {
        // Add listeners to buttons
        canteenButton.onClick.AddListener(() => OnDestinationSelected(Destination.Canteen));
        receptionButton.onClick.AddListener(() => OnDestinationSelected(Destination.Reception));
        elevatorAButton.onClick.AddListener(() => OnDestinationSelected(Destination.ElevatorA));
        elevatorBButton.onClick.AddListener(() => OnDestinationSelected(Destination.ElevatorB));
        elevatorCButton.onClick.AddListener(() => OnDestinationSelected(Destination.ElevatorC));
        elevatorMainButton.onClick.AddListener(() => OnDestinationSelected(Destination.ElevatorMain));
        exitButton.onClick.AddListener(ExitApplication);
    }

     void Update()
    {
        // Check if the agent has reached the destination
        if ((currentDestination != null) && (Vector3.Distance(agent.transform.position, currentDestination.position) < 2))
        {
            Debug.Log("Destination reached: " + currentDestination.name);

            // Show the MenuCanvas
            if (menuCanvas != null && !menuCanvas.activeSelf)
            {
                menuCanvas.SetActive(true);
                currentDestination = null; // Clear the destination to stop further checks
            }
        }
    }

    // Handle destination selection
    public void OnDestinationSelected(Destination destinationName)
    {
        Debug.Log("Selected destination: " + destinationName);

        switch (destinationName)
        {
            case Destination.Canteen:
                SetDestination(canteenDest);
                break;
            case Destination.Reception:
                SetDestination(receptionDest);
                break;
            case Destination.ElevatorA:
                SetDestination(elevatorADest);
                break;
            case Destination.ElevatorB:
                SetDestination(elevatorBDest);
                break;
            case Destination.ElevatorC:
                SetDestination(elevatorCDest);
                break;
            case Destination.ElevatorMain:
                SetDestination(elevatorMainDest);
                break;
            default:
                Debug.Log("Unknown destination");
                break;
        }

        // Disable the MenuCanvas
        if (menuCanvas != null)
        {
            menuCanvas.SetActive(false);
        }
        else
        {
            Debug.LogWarning("MenuCanvas is not assigned!");
        }
    }

    // Method to set the destination for the NavMeshAgent
    public void SetDestination(Transform destination)
    {
        if (agent != null && destination != null)
        {
            currentDestination = destination; // Set the current destination for Update checks
            agent.SetDestination(destination.position);
            Debug.Log("Navigating to: " + destination.name);
        }
        else
        {
            Debug.LogWarning("Agent or Destination is missing!");
        }
    }

    // Exit application
    public void ExitApplication()
    {
        Debug.Log("Exiting the application...");
        Application.Quit();
    }
}
