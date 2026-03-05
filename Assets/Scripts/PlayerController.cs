using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    Vector2 movementVector;
    Vector3 actualVector;
    float movementX, movementY;
    public float speed = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject pickup_Parent;
    public GameObject[] pickup;
    private int score;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    void Start()
    {
        pickup = new GameObject[1000];
        speed= 10f;
        score = 0;
        winTextObject.SetActive(false);
        SetCountText();
        rb = GetComponent<Rigidbody>();
        for (int i = 0; i < 1000; i++)
        {
            pickup[i] = GameObject.Instantiate(pickup_Parent);
            pickup[i].transform.position = new Vector3(i, 1f, 0);
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
        actualVector = new Vector3 (movementX, 0f, movementY);
        rb.AddForce(actualVector * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            other.gameObject.SetActive(false);
            score++;

            SetCountText();

        }
    }
     // Function to update the displayed count of "PickUp" objects collected.
 void SetCountText() 
    {
 // Update the count text with the current count.
        countText.text = "Count: " + score.ToString();

 // Check if the count has reached or exceeded the win condition.
 if (score >= 10)
        {
 // Display the win text.
            winTextObject.SetActive(true);
        }
    }
}
