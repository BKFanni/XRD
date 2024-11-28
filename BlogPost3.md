<h2>Fanni</h2>
<p>
Working together with Duarte, I have implemented the script to calculate the path between the user and the target (for e.g. Canteen, or Reception).
The script manages the target object (a prefab) and visualizes a path from the player to the target using Unity’s NavMesh system. It includes serialized fields for the target prefab, the player's position, and a LineRenderer to display the path, along with settings for offsets and path update speed.
<br/>
In the Awake() method, the NavMesh triangulation data is gathered, defining the walkable area. If a path-drawing coroutine is already running, it stops and starts a new one to continuously update the path between the player and the target.
<br/>
The DrawPathToTarget() coroutine calculates and updates the path between the player's position and the target’s position in real time, using the NavMesh.CalculatePath() method. The path's waypoints are used to update the LineRenderer to visually represent the path on the scene, with periodic updates based on the PathUpdateSpeed. If no valid path is found, it logs an error.
</p>

<h2>Marwa</h2>
<p>As part of our AR mobile app project, I designed a user interface that allows users to select their desired destination. The first step was adding a Canvas to the scene, which serves as the container for all the UI elements. I then added a text element to introduce the app's features and explain the navigation options.

To present the destination options in a clean and organized way, I used a Vertical Layout Group. I created an empty GameObject to hold all the destination buttons and applied the Vertical Layout Group component to it, which automatically arranges the buttons in a stacked layout.

Next, I wrote a DestinationManager script to handle user interactions. In the Start() method, I used OnClick listeners for each button, which trigger the OnDestinationSelected() function when the user selects a destination. This function will eventually load the relevant AR content based on the selected destination.

I also implemented an Exit button so that users can close the app easily. The ExitApplication() function is responsible for handling this, allowing the app to terminate cleanly when the exit button is pressed.

This structure provides a simple and efficient way for users to interact with our app, select destinations, and navigate through the AR experience.</p>


<h2>Duarte</h2>
<p>The navigation system was still not working completely so I worked together with Fanni to fix this issue.</p>

<h2>Andrejs</h2>
<p>There were some issues with the navigation mesh and the floor model, so I helped Duarte fix them. We used the navigation mesh to calculate the path for the user to take to get to their destination. I also helped debugging and testing the locations and fixed their places in the map. To calculate the destinations I placed cube GameObjects without collision and without a MeshRenderer, so they act only as position GameObjects.</p>