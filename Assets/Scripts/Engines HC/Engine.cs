using UnityEngine;

public class Engine : MonoBehaviour
{
    public GameObject core;

    Rigidbody rb;
    Transform tr;
    AudioSource aus;


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
        aus = GetComponent<AudioSource>();
        hcc = core.GetComponent<HCControl>();
    }

    void FixedUpdate()
    {
        tooHigh = hcc.targetHeight * 10;

        if (Physics.Raycast(tr.position - (transform.up * 0.5f), -transform.up, out ray))
        {
            y = ray.distance;
        }
        else
        {
            y = tooHigh; // No hit, assume too high
        }

        divePercent = (hcc.targetHeight - y + tr.localScale.y) / hcc.targetHeight; // Added engine scale to make dive percent more accurate
        divePercentNormalized = Mathf.Clamp01(divePercent);

        float smoothingFactor = 5f; // Adjust to tweak responsiveness
        rb.drag = Mathf.Lerp(rb.drag, divePercentNormalized, Time.deltaTime * smoothingFactor);
        rb.angularDrag = Mathf.Lerp(rb.angularDrag, divePercentNormalized, Time.deltaTime * smoothingFactor);

        rb.AddForce(10 * Mathf.Pow(divePercentNormalized, 2) * hcc.engineForce * transform.up);

        aus.volume = Mathf.Lerp(aus.volume, rb.velocity.magnitude / 90, Time.deltaTime * smoothingFactor);
        aus.pitch = Mathf.Lerp(aus.pitch, rb.velocity.magnitude / 90, Time.deltaTime * smoothingFactor);
    }
}
