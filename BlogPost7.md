<h2>Fanni</h2>
Today, I was trying to debug the errors in the AR project, by making some changes in the build and player settings, as well as adding a new GameObject called DestinationManager to make the destination buttons functional. 
I integrated QR code scanning with QRScanner to decode QR codes and dynamically set start positions in the ARPathfinding script, alongside implementing the CaptureCameraImage function to utilize the AR camera feed for QR code scanning. 
I also assigned the destination buttons and transforms in the DestinationManager script to handle navigation to various destinations. 
As for the VR project, I have added a sand castle as an object on the beach. I have also added banana and fish prefabs to the scene and made them interactable (the user can pick them up and throw them away). 

<h2>Marwa</h2>

<h4>Implementing Throwable Objects in a VR Beach Scene</h4>
For our VR project, I added beach objects to use as interactable items such as Aquarius, Desk, starfish, and other beach stuff. I wrote a script called `ThrowableObject.cs` to allow users to pick up and throw the object naturally. This script keeps track of the object’s velocity during interaction and applies that velocity when the object is released, creating a realistic throwing effect.

To set everything up, I added a Collider to detect interactions and a Rigidbody for physics simulation, initially set to kinematic. I then attached the XR Grab Interactable component, which handles the grabbing and releasing mechanics. In the component’s settings, I linked the OnGrabbed method to disable physics when the object is picked up, and the OnReleased method to re-enable physics and apply the velocity when it’s thrown.
