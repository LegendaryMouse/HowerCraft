using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemJump : MonoBehaviour
{
    public GameObject item;
    public GameObject roof;
    public float jumpForce;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "bullet")
        {
            Destroy(item.GetComponent<ConfigurableJoint>());
            item.GetComponent<Rigidbody>().AddForce(0, item.GetComponent<Rigidbody>().mass * jumpForce, 0);
            item.GetComponent<Rigidbody>().AddForce(0, item.GetComponent<Rigidbody>().mass * jumpForce, 0);
            Debug.Log("beb");
        }
    }
}
