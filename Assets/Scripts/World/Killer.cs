using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    Collider[] colliders;
    public float killerField;
    public float dps;

    private void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, killerField);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].GetComponent<ImpulseDestroy>())
            {
                float dist = Vector3.Distance(colliders[i].transform.position, transform.position);
                colliders[i].GetComponent<ImpulseDestroy>().hp -= dps * Time.deltaTime / dist;
            }
        }
    }
}
