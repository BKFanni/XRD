using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowableObject : MonoBehaviour
{
    private Rigidbody rb; // Rigidbody for the object
    private Vector3 lastPosition; // Tracks the object's last position
    private Vector3 velocity; // Tracks the object's velocity

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("ThrowableObject: Rigidbody component is missing!");
        }
    }

    void FixedUpdate()
    {
        // Track the object's velocity
        velocity = (transform.position - lastPosition) / Time.fixedDeltaTime;
        lastPosition = transform.position;
    }

    // Called when the object is grabbed
    public void OnGrabbed(SelectEnterEventArgs args)
    {
        // Disable physics while the object is being held
        rb.isKinematic = true;
    }

    // Called when the object is released
    public void OnReleased(SelectExitEventArgs args)
    {
        // Re-enable physics when the object is released
        rb.isKinematic = false;

        // Apply the captured velocity to simulate throwing
        rb.velocity = velocity;
    }
}
