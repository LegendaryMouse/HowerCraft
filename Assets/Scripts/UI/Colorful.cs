using UnityEngine;

public class Colorful : MonoBehaviour
{
    bool On;
    Color Col;

    float hpr;

    ImpulseDestroy imp;
    Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        imp = GetComponent<ImpulseDestroy>();
        Col = Color.white;
        rend.material.color = Col;
    }
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (GetComponent<ImpulseDestroy>())
            {
                hpr = imp.hpRemain;
                Col = new Color(1 - hpr, hpr, 0, 1);
                rend.material.color = Col;
            }
            else
            {
                Col = new Color(0, 0, 0, 1);
                rend.material.color = Col;
            } 
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            Col = Color.white;
            rend.material.color = Col;
        }
    }
}
