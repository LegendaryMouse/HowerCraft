using System.Collections.Generic;
using UnityEngine;

public class FunctionsControl : MonoBehaviour
{
    public List<Rigidbody> engines;

    Rigidbody rb;

    float brakePower;

    public List<GameObject> fari;

    public List<Collider> hower = new();

    void Awake()
    {
        rb = GetComponent<Rigidbody>();


        hower.AddRange(Physics.OverlapSphere(transform.position, 20));

        for (int i = 0; i < hower.Count; i++)
        {
            if (hower[i].GetComponent<Engine>())
            {
                engines.Add(hower[i].GetComponent<Rigidbody>());
                hower[i].GetComponent<Engine>().core = gameObject;
                //Debug.Log(hower[i].name);
            }
            if (hower[i].GetComponent<Battery>())
            {
                GetComponent<Reactor>().batteryCount.Add(hower[i].gameObject);
            }
            if (hower[i].GetComponent<TurretOff>())
            {
                hower[i].transform.GetChild(0).GetComponent<ETurret>().core = gameObject;
            }

        }
    }
    void Update()
    {
        brakePower = rb.mass * 10 / rb.velocity.magnitude;

        if (Input.GetKey(KeyCode.Space))
            Brake();
        if (Input.GetKeyDown(KeyCode.X))
            GetUp();
        if (Input.GetKeyDown(KeyCode.G))
            Suicide();
    }

    void Brake()
    {
        if (rb.velocity.magnitude > 0.1f)
            for (int i = 0; i < engines.Count; i++)
            {
                if (engines[i].GetComponent<ConfigurableJoint>())
                {
                    Engine en = engines[i].GetComponent<Engine>();
                    if (en.y < en.tooHigh)
                    {
                        Vector3 forceX = new(engines[i].velocity.x * -brakePower, 0, 0);
                        Vector3 forceZ = new(0, 0, engines[i].velocity.z * -brakePower);

                        Vector3 torqueXYZ = (engines[i].angularVelocity * -brakePower);

                        rb.AddForce(50 * Time.deltaTime * forceX);
                        rb.AddForce(50 * Time.deltaTime * forceZ);

                        rb.AddTorque(50 * Time.deltaTime * torqueXYZ);
                    }
                }
            }
    }

    void GetUp()
    {
        {
            rb.AddForce(0, rb.mass * 1500, 0);
            rb.AddTorque(0, rb.mass * 30000, 0);
        }
    }

    public void Suicide()
    {
        if (GetComponent<ImpulseDestroy>())
            GetComponent<ImpulseDestroy>().hp = 0;
    }
}
