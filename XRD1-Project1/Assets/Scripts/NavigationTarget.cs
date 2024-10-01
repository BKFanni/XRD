using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject Prefab;  
    [SerializeField]
    private Transform User;
    [SerializeField]
    private LineRenderer Path;
    [SerializeField]
    private float PathHeightOffset = 1f;
    [SerializeField]
    private float TargetHeightOffset = 1f;
    [SerializeField]
    private float PathUpdateSpeed = 0.25f;

    private GameObject ActiveInstance;  
    private NavMeshTriangulation Triangulation;
    private Coroutine DrawPathCoroutine;


    private void Awake()
    {
        Triangulation = NavMesh.CalculateTriangulation();
    }

    private void Start()
    {
        SpawnNewTarget();
    }

    private void SpawnNewTarget()
    {
        // Instantiate the prefab as a GameObject
        ActiveInstance = Instantiate(Prefab,
            Triangulation.vertices[Random.Range(0, Triangulation.vertices.Length)] + Vector3.up * TargetHeightOffset,
            Quaternion.Euler(90, 0, 0));

        if (DrawPathCoroutine != null)
        {
            StopCoroutine(DrawPathCoroutine);
        }

        DrawPathCoroutine = StartCoroutine(DrawPathToTarget());
    }

    private IEnumerator DrawPathToTarget()
    {
        WaitForSeconds wait = new WaitForSeconds(PathUpdateSpeed);
        NavMeshPath path = new NavMeshPath();

        while (ActiveInstance != null)
        {
            if (NavMesh.CalculatePath(User.position, ActiveInstance.transform.position, NavMesh.AllAreas, path))
            {
                Path.positionCount = path.corners.Length;

                for (int i = 0; i < path.corners.Length; i++)
                {
                    Path.SetPosition(i, path.corners[i] + Vector3.up * PathHeightOffset);
                }
            }
            else
            {
                Debug.LogError($"Unable to calculate a path on the NavMesh between {User.position} and {ActiveInstance.transform.position}!");
            }

            yield return wait;
        }
    }
}
