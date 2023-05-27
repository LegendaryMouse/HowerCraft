using UnityEngine;

public class CrashSound : MonoBehaviour
{
    
    public AudioSource sound;

    float imp;
    float minImp;
    Vector3 imp0;


    /*void Start()
    {
        minImp = GetComponent<Rigidbody>().mass * 40;
    }

    void OnCollisionEnter(Collision other)
    {
        imp0 = other.impulse;
        imp = imp0.magnitude; // force of hit

        if (imp > minImp)
        {
            Crash();
        }
    }

    void Crash()
    {
        sound.volume = imp / (minImp * 5);
        sound.Play();
    }*/
    
}