using UnityEngine;

public class TotalHp : MonoBehaviour
{
    float totalHp = 0;
    public float remainHp = 0;

    public float deltaHp;

    public Color Col;

    public string carName = "OffRoad";

    //bool hitCore = false;

    void Start()
    {
        carName = transform.root.name;
        Collider[] blocks = Physics.OverlapSphere(transform.position, 15);
        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i].transform.root.name == carName)
                if (blocks[i].GetComponent<ImpulseDestroy>())
                {
                    totalHp += blocks[i].GetComponent<ImpulseDestroy>().hp;
                }
        }
    }

    void FixedUpdate()
    {
        //if (hitCore && deltaHp < 0.9f && GetComponent<ImpulseDestroy>())
        //GetComponent<ImpulseDestroy>().hp -= 1 / deltaHp / deltaHp;
    }
    void Update()
    {
        remainHp = 0;

        Collider[] blocks = Physics.OverlapSphere(transform.position, 15);
        for (int a = 0; a < blocks.Length; a++)
        {
            if (blocks[a].transform.root.name == carName && blocks[a].GetComponent<ImpulseDestroy>())
            {
                remainHp += blocks[a].GetComponent<ImpulseDestroy>().hp;
            }
        }
        deltaHp = remainHp / totalHp;

        Col = new Color(1 - deltaHp, deltaHp, 0f, deltaHp * 0.5f);


        //hitCore = true;
    }
}
