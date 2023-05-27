using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetField;
    public float magnetForce;

    public float magnetSpeed;

    Collider[] colliders;

    private void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, magnetField);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].GetComponent<Rigidbody>())
                if (!colliders[i].GetComponent<Magnet>())
                {
                    float dist = Vector3.Distance(colliders[i].transform.position, transform.position);
                    Vector3 direction = colliders[i].transform.position - transform.position;
                    colliders[i].GetComponent<Rigidbody>().AddForce(direction * magnetForce / (dist * dist));
                }
        }
    }
}