using UnityEngine;

public class DayNight : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddTorque(speed, 0, 0);
    }
}
