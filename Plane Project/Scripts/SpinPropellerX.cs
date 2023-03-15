using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // rotating the propeller about its z-axis
        transform.Rotate(0f, 0f, 50f * 10 * Time.deltaTime, Space.Self);
    }
}
