using UnityEngine;

public class Mina : MonoBehaviour
{
    bool notExploded = true;

    public AudioSource beep;
    Rigidbody rb;
    Renderer rend;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        Collider[] target = Physics.OverlapSphere(transform.position, rb.mass);
        for (int i = 0; i < target.Length; i++)
        {
            if (target[i].CompareTag("player"))
                if (notExploded)
                {
                    beep.Play();
                    Invoke(nameof(Counter), 2f);
                    rend.material.color = Color.red; 
                    notExploded = false;
                }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>())
        {
            Invoke(nameof(Counter), 0.1f);
        }
    }

    void Counter()
    {
        GetComponent<Explode>().Explosion();
        Invoke(nameof(Die), 3f);
        Destroy(GetComponent<MeshRenderer>());
        Destroy(beep);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
