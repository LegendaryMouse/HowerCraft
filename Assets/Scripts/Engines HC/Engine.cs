using UnityEngine;

public class Engine : MonoBehaviour
{
    public GameObject core;

    Rigidbody rb;
    Transform tr;
    AudioSource ass;


    public float y;

    public float tooHigh;

    float divePercent;
    float divePercentNormalized;
    HCControl hcc;

    public LayerMask LayerMask;
    RaycastHit ray;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        ass = GetComponent<AudioSource>();
        hcc = core.GetComponent<HCControl>();
    }

    void FixedUpdate()
    {
        tooHigh = hcc.targetHeight * 10;

        Physics.Raycast(tr.position - (transform.up * 0.5f), -transform.up, out ray);
        y = ray.distance;

        if (y == 0f)
            y = tooHigh;

        divePercent = -y + hcc.targetHeight - tr.localScale.x * 0.5f;
        divePercentNormalized = Mathf.Clamp(divePercent, 0, 1);

        rb.drag = divePercentNormalized;
        rb.angularDrag = divePercentNormalized;

        rb.AddForce(10 * divePercentNormalized * hcc.engineForce * transform.up);

        ass.volume = rb.velocity.magnitude / 90;
    }
}
