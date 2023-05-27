using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomness : MonoBehaviour
{
    public GameObject[] items;
    public float[] itemsChance;
    float lucky;
    Vector3 zero = new Vector3(0, 1.75f, 0);
    float totalChance;

    private void Start()
    {
        for(int i = 0; i < itemsChance.Length; i++)
        {
            totalChance += itemsChance[i];
        }

            lucky = Random.Range(0, totalChance);

        for(int i = 0; i < items.Length; i++)
        {
            if (lucky < itemsChance[i])
            {
                GetComponent<ItemJump>().item = Instantiate(items[i], zero, Quaternion.Euler(zero));
                i = 999;
            }
        }
    }
}
