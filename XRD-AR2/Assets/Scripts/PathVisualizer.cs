using UnityEngine;
using UnityEngine.AI;

public class PathVisualizer : MonoBehaviour
{
    public NavMeshAgent agent;  // The NavMeshAgent for pathfinding
    public LineRenderer lineRenderer;  // The LineRenderer for visualizing the path

    void Update()
    {
        if (agent.hasPath)
        {
            DrawPath(agent.path);
        }
        else
        {
            lineRenderer.positionCount = 0;  // Clear the line if there is no path
        }
    }

    // Function to draw the path using the LineRenderer
    void DrawPath(NavMeshPath path)
    {
        lineRenderer.positionCount = path.corners.Length;  // Set number of positions in the line
        lineRenderer.SetPositions(path.corners);  // Set positions for each corner of the path
    }
}
