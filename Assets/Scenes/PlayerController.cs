using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour {

    Rigidbody rb;
    Vector2 movementVector;
    Vector3 actualVector;
    float movementX, movementY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void onMove(InputValue movementValue)
    {        
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        actualVector = new Vector3 (movementX, 0, movementY);
        rb.AddForce(movementVector * 10f);
    }
}
