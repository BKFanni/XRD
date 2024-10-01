<h2>Fanni</h2>
<p>
Working together with Duarte, I have implemented the script to calculate the path between the user and the target (for e.g. Canteen, or Reception).
The script manages the target object (a prefab) and visualizes a path from the player to the target using Unity’s NavMesh system. It includes serialized fields for the target prefab, the player's position, and a LineRenderer to display the path, along with settings for offsets and path update speed.
<br/>
In the Awake() method, the NavMesh triangulation data is gathered, defining the walkable area. If a path-drawing coroutine is already running, it stops and starts a new one to continuously update the path between the player and the target.
<br/>
The DrawPathToTarget() coroutine calculates and updates the path between the player's position and the target’s position in real time, using the NavMesh.CalculatePath() method. The path's waypoints are used to update the LineRenderer to visually represent the path on the scene, with periodic updates based on the PathUpdateSpeed. If no valid path is found, it logs an error.
</p>
