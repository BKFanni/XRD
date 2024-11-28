<h2>Marwa, Fanni, Duarte, Andrejs</h2>
<p>All 4 of us together were brainstorming on how to move forward with the project and fixing some issues. Andrejs made a new folder where he created a new project from scratch so that it would solve the team's issue with not being able to have the project open as it takes up too much memory on the computers. So he copy pasted the work that we have already done from the old to the new project folder. In the meantime, Duarte was working on the map and NavMesh components in Unity. Then everyone together was working on what we need to show to use user, how we can define the destinations in Unity (for that we place GameObjects in the scene).
</p>
<h3>Fanni</h3>
<p>
Part of the project involved integrating QR code scanning functionality using the ZXing.Net library. This library was employed to decode QR codes, which provided essential information such as coordinates or destination names. The decoded information was used to set the user's starting position in the AR environment or dynamically adjust their destination. A custom script, QRScanner, was created to handle the camera feed, decode the QR code, and pass the extracted data to the navigation system. The decoded location or destination was then used to direct the user within the virtual space overlaid on the real world.<br>

Following the QR scanning implementation, the project focused on creating a robust pathfinding system using Unity's NavMesh. The NavMeshAgent component was utilized to calculate and display paths in the AR environment. The agent was attached to the user’s AR camera, representing the user’s movement, and dynamically adjusted as new destinations were selected. The navigation system ensures that the user can navigate through the environment by setting the destination points via the user interface or QR code scanning.<br>

The UI is connected to the pathfinding system, and upon clicking a button, the NavMeshAgent updates the destination accordingly. This interaction was handled by the DestinationManager script, which links the UI buttons to the corresponding destinations.<br>

A key element of the project was the visualization of the navigation path. To assist users in following the path to their destination, two visualization methods were implemented: a LineRenderer to draw a line along the calculated path, and a system of arrows instantiated at key points (corners) of the path. This ensured that users could clearly see and follow the route to their selected destination. Both methods ensured that the path was visible in the AR environment and adapted to the real-world context, making it easy for users to navigate in real time.<br>

In the context of augmented reality, camera control is handled naturally by the user’s movement, as the AR system leverages the mobile device’s camera and sensors to determine orientation. Thus, no additional scripting was necessary to adjust the camera’s rotation or positioning manually. The user’s physical movement, captured by the AR system, allows the camera to automatically adjust based on how the user interacts with the environment.<br>
</p>

<h2>Marwa</h2>
<p> After defining the game objects for the destinations (canteen, reception, elevators), I changed the destination options script by creating an enum to manage the different locations. After that, I referenced the destination option buttons and linked them to the corresponding Transform variables for each destination. I then built a navigation system using NavMeshAgent and UI buttons.
  
I set up the NavMeshAgent on the character and connected the destination points to the Transform variables in the script. I used AddListener() for each button to trigger navigation when clicked. The OnDestinationSelected() method determines the selected destination and calls SetDestination() to move the agent. I also added an exit button to close the application, allowing for easy navigation through the UI.</p>


<h2>Duarte</h2>
<p>
</p>

<h2>Andrejs</h2>
<p>Most of what I did was trying to figure out how to fix the existing project before settling with others that it's best to make a new one. After creating a new one, I copied over the old stuff that I had done and helped testing the project again to make sure it works correctly.</p>