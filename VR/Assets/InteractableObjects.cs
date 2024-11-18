using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    private Rigidbody rb;
    private bool isHeld = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PickUp(Transform hand)
    {
        isHeld = true;
        rb.isKinematic = true;  // Disable physics while holding
        transform.SetParent(hand);
        transform.localPosition = Vector3.zero;
    }

    public void Throw(Vector3 throwForce)
    {
        isHeld = false;
        transform.SetParent(null);
        rb.isKinematic = false;  // Enable physics again
        rb.AddForce(throwForce, ForceMode.Impulse);
    }

    private void OnMouseDown()  // For testing with mouse, replace with VR input logic
    {
        Debug.Log($"{name} interacted with!");
    }
}
