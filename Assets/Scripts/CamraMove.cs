using UnityEngine;

public class CamraMove : MonoBehaviour
{
    public GameObject Camera, Player;
    Vector3 Distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Distance = Camera.transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.transform.position = Player.transform.position + Distance;
        
    }
}
