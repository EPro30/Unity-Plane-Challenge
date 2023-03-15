using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    // Private variables
    public GameObject player;
    private float speed = 15.0f;
    private float turnSpeed = 40.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Getting input from the user (keyboard or joystick)
        horizontalInput = Input.GetAxis("Horizontal2");
        forwardInput = Input.GetAxis("Vertical2");

        // Move the vehicle forward and backward
        player.transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput); slides left or right

        // Rotate the vehicle left and right. Time.deltaTime.....Input represents the rotation angle
        player.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
