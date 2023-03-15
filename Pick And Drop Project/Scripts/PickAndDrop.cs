using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndDrop : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObj;
    private Rigidbody heldObjRB;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    PickupObject(hit.transform.gameObject);
                    Debug.DrawLine(transform.position, transform.TransformDirection(Vector3.forward), Color.red);
                }
            }
            else
            {
                Debug.Log(heldObj.name);
                if (heldObj.name != "Truck")
                    DropObject(); // null
            }
        }
        if (heldObj != null && heldObj.name != "Truck")
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        // If the distance between initial location and new location is  > 0.1,
        // then move the object in the new direction by certain distance
        // with the assigned pick up force
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.name == "Truck")
        {
            Debug.Log("Found it!!");
            return;
        }

        if (pickObj.GetComponent<Rigidbody>())
      {
         heldObjRB = pickObj.GetComponent<Rigidbody>();
         heldObjRB.useGravity = false;
         heldObjRB.drag = 10;
         heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;
            
         heldObjRB.transform.parent = holdArea;
         heldObj = pickObj;
      }
    }

    void DropObject()
    {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;
        heldObj = null;
    }
}
