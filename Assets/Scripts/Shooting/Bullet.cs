using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool on = true;

    void OnCollisionEnter(Collision other)
    {
        if (on == true)
        {
            on = false;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Invoke("SelfDestroy", 10f);
        GetComponent<AudioSource>().volume = rb.velocity.magnitude * rb.mass / 25000; //звук выстрела
        GetComponent<AudioSource>().Play();
    }

    void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
