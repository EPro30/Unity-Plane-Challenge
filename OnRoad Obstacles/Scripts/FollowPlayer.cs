using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject secondaryCam;
    public GameObject BlueMainCam;
    public GameObject player1;
    public GameObject player2;
    private Vector3 offset = new Vector3(0, 6, -13);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mainCam.SetActive(true);
            BlueMainCam.SetActive(true);
            secondaryCam.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mainCam.SetActive(false);
            BlueMainCam.SetActive(false);
            secondaryCam.SetActive(true);
        }

        // setting the camera position to vehicle position, so the camera moves along with the vehicle
        mainCam.transform.position = player1.transform.position + offset;
        BlueMainCam.transform.position = player2.transform.position + offset;
    }
}
