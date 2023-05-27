using UnityEngine;

public class HCControl : MonoBehaviour
{
    FunctionsControl fc;
    Rigidbody rb;
    Engine en;
    ImpulseDestroy id;

    public float engineForce;
    public float targetHeight;

    float speed;
    float angularSpeed;

    float ws;
    float ad;

    private void Start()
    {
        fc = GetComponent<FunctionsControl>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        speed = engineForce * 3;
        angularSpeed = engineForce * 10;

        ad = Input.GetAxis("Horizontal");
        ws = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < fc.engines.Count; i++)
        {
            if (fc.engines[i] && fc.engines[i].GetComponent<ImpulseDestroy>())
            {
                en = fc.engines[i].GetComponent<Engine>();

                if (en.y < en.tooHigh)
                {
                    id = fc.engines[i].GetComponent<ImpulseDestroy>();

                    rb.AddForce(id.hpRemain * speed * ws * transform.forward);
                    rb.AddTorque(ad * angularSpeed * id.hpRemain * transform.up);
                }
            }
        }
    }
}