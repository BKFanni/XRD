using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

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

    // AR components for rendering navigation markers
    public ARRaycastManager arRaycastManager;
    public GameObject navigationMarkerPrefab; // AR marker to guide the user

    // Arrays of predefined AR waypoints for each destination
    public Transform[] canteenWaypoints;
    public Transform[] receptionWaypoints;
    public Transform[] elevatorAWaypoints;
    public Transform[] elevatorBWaypoints;
    public Transform[] elevatorCWaypoints;
    public Transform[] elevatorMainWaypoints;

    private GameObject currentNavigationMarker;

    void Start()
    {
        // Adding listeners for all buttons, passing the correct Destination enum value.
        canteenButton.onClick.AddListener(() => OnDestinationSelected(Destination.Canteen));
        receptionButton.onClick.AddListener(() => OnDestinationSelected(Destination.Reception));
        elevatorAButton.onClick.AddListener(() => OnDestinationSelected(Destination.ElevatorA));
        elevatorBButton.onClick.AddListener(() => OnDestinationSelected(Destination.ElevatorB));
        elevatorCButton.onClick.AddListener(() => OnDestinationSelected(Destination.ElevatorC));
        elevatorMainButton.onClick.AddListener(() => OnDestinationSelected(Destination.ElevatorMain));

        exitButton.onClick.AddListener(ExitApplication);
    }

    public void OnDestinationSelected(Destination destination)
    {
        Debug.Log("Selected destination: " + destination);

        // Clear the previous navigation marker if any
        if (currentNavigationMarker != null)
        {
            Destroy(currentNavigationMarker);
        }

        // Handle navigation based on the selected destination
        switch (destination)
        {
            case Destination.Canteen:
                Debug.Log("Navigating to the Canteen...");
                LoadNavigationPath(canteenWaypoints); // Load path to canteen
                break;
            case Destination.Reception:
                Debug.Log("Navigating to Reception...");
                LoadNavigationPath(receptionWaypoints); // Load path to reception
                break;
            case Destination.ElevatorA:
                Debug.Log("Navigating to Elevator A...");
                LoadNavigationPath(elevatorAWaypoints); // Load path to Elevator A
                break;
            case Destination.ElevatorB:
                Debug.Log("Navigating to Elevator B...");
                LoadNavigationPath(elevatorBWaypoints); // Load path to Elevator B
                break;
            case Destination.ElevatorC:
                Debug.Log("Navigating to Elevator C...");
                LoadNavigationPath(elevatorCWaypoints); // Load path to Elevator C
                break;
            case Destination.ElevatorMain:
                Debug.Log("Navigating to Main Elevator...");
                LoadNavigationPath(elevatorMainWaypoints); // Load path to Main Elevator
                break;
            default:
                Debug.Log("Unknown destination selected.");
                break;
        }
    }

    // Function to load a navigation path using AR markers or waypoints
    private void LoadNavigationPath(Transform[] waypoints)
    {
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("No waypoints defined for this destination.");
            return;
        }

        // Place AR markers or navigation indicators along the path
        foreach (Transform waypoint in waypoints)
        {
            // Raycast to find the AR plane at each waypoint
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRaycastManager.Raycast(waypoint.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
            {
                // If a plane is found, place a navigation marker
                Pose hitPose = hits[0].pose;
                currentNavigationMarker = Instantiate(navigationMarkerPrefab, hitPose.position, hitPose.rotation);
            }
        }
    }

    public void ExitApplication()
    {
        Debug.Log("Exiting the application...");
        Application.Quit();
    }
}
