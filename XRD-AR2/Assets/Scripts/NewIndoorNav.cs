
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class NewIndoorNav : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private ARTrackedImageManager m_trackedImageManager;
    [SerializeField] private GameObject trackedImagePrefab;
    [SerializeField] private LineRenderer line;

    private List<NavigationTarget> navigationTargets = new List<NavigationTarget>();
    private NavMeshSurface navMeshSurface;
    private NavMeshPath navMeshPath;
    
    private GameObject navigationBase;

    private void Start()
    {
        navMeshPath = new NavMeshPath();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        
    }
    
    private void Update()
    {
        if (navigationBase != null && navigationTargets.Count > 0 && navMeshSurface != null)
        {
            // navMeshSurface.BuildNavMesh(); 
            NavMeshPath navMeshPath = new NavMeshPath();
            
            if (player != null && navigationTargets.Count > 0)
            {
                NavMesh.CalculatePath(player.position, navigationTargets[0].transform.position, NavMesh.AllAreas, navMeshPath);
                // Check if the path calculation was successful
                if (navMeshPath.status == NavMeshPathStatus.PathComplete)
                {
                    // Set the positions on the line renderer based on the calculated path corners
                    line.positionCount = navMeshPath.corners.Length;
                    line.SetPositions(navMeshPath.corners);
                }
                else
                {
                    line.positionCount = 0; // Clear line if the path is not complete
                }
            }
        }
    }


    private void OnEnable()
    {
        m_trackedImageManager.trackedImagesChanged += OnChanged;
        
    }
    private void OnDisable()
    {
        m_trackedImageManager.trackedImagesChanged += OnChanged;
    }

    private void OnChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var newImage in args.added)
        {
            navigationBase = Instantiate(trackedImagePrefab, newImage.transform.position, newImage.transform.rotation);
             
            
            navigationTargets.Clear();
            navigationTargets = navigationBase.transform.GetComponentsInChildren<NavigationTarget>().ToList();
            navMeshSurface = navigationBase.transform.GetComponentInChildren<NavMeshSurface>();
        }


        foreach (ARTrackedImage updatedImage in args.updated)
        {
            if (updatedImage.trackingState == TrackingState.Tracking)
            {
                
                Vector3 position = updatedImage.transform.position;
                Quaternion rotation = updatedImage.transform.rotation;

                
                GameObject associatedObject = updatedImage.transform.GetChild(0).gameObject; 
                associatedObject.transform.position = position;
                associatedObject.transform.rotation = rotation;
            }
        }


        foreach (ARTrackedImage removedImage in args.removed)
        {
            
        }
    }
    
}
