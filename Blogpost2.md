<h1>About the project</h1>
<h4>Fanni</h4>
<p>The project is going to be an AR mobile application designed to be used by students / people at VIA University College Campus Horsens. <br/>
  It will help people navigate inside the building, especially for newcomers, for example: where the canteen is located and show directions to get there.<br/>
  To minimize the scope of the project due to time limitation, we decided to make the project only for the groundfloor of the building.
</p>
<h2>Planning</h2>
<h4>Fanni</h4>
<p>First, Andrejs has made sure that we have the permission and floorplan from VIA. In the meantime, Marwa setup a basic AR project in Unity and Duarte looked into what technologies we could use for creating the project. After getting the floorplan, Duarte started on creating the 3D models of the building. <br/>
Next, we will identify and discuss the use cases and features that would be implemented and equally split the tasks between the group members. 
</p>

<h2>Marwa</h2>
<p>First, I created an AR mobile project in Unity and set it up using AR Foundation with Android support via the Package Manager. I then enabled AR support in Build Settings by turning on ARCore for Android under XR Plug-in Management.</p>
<p></p>Next, I added an AR Session and an AR Session Origin to the scene. The AR Session manages the lifecycle of the AR experience, while the AR Session Origin aligns AR objects with the real world and includes an AR camera for tracking the environment. I ensured that the AR camera from the AR Session Origin was used instead of the default main camera.</p>
<p>To integrate our 3D model, I added it to the prefabs and attached an AR Tracked Image Manager to the AR Session Origin. I then created a reference image, using our QR code as the serialized image library, and linked the 3D building plan model as the prefab for the tracked image.</p>


<h2>Duarte</h2>
<p>Before our first lab week, I took on the task of making the 3D model on Blender. It was my first time working with this tool but with the help of some videos I learned how to get around it and was able to complete my task.</p>
<p>My next task was to implement Navigation Pathfinding that its not functional yet. I setup NavMesh, the first waypont and wrote a script that calculates the navigation path.</p>
