using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    private float movementX, movementY;
    public float speed = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Pickup_Parent;
    public GameObject[] pickup;
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private float spawnrange = 5f;
    void Start()
    
    {
        pickup = new GameObject[1];
        speed= 8f;
        count = 0;
        winTextObject.SetActive(false);
        SetCountText();
        rb = GetComponent<Rigidbody>();
        for (int i = 0; i < 12; i++)
        {
            float randomXVal = Random.Range(-spawnrange, spawnrange);
            float randomYVal = Random.Range(-spawnrange, spawnrange);
            pickup[i] = GameObject.Instantiate(Pickup_Parent);
            pickup[i].transform.position = new Vector3(randomXVal, 0.0f, randomYVal);
        }

    }

    void OnMove(InputValue movementValue)
    {        
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;

            SetCountText();

        }
    }
    //  Function to update the displayed count of "PickUp" objects collected.
 void SetCountText() 
    {
 // Update the count text with the current count.
        countText.text = "Count: " + count.ToString();

 // Check if the count has reached or exceeded the win condition.
 if (count >= 12)
        {
 // Display the win text.
            winTextObject.SetActive(true);
        }
    }
}
