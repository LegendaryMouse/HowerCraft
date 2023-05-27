using UnityEngine;

public class Colorful : MonoBehaviour
{
    bool On;
    bool ful = true;
    Color Col;

    float hpr;

    ImpulseDestroy imp;
    Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        imp = GetComponent<ImpulseDestroy>();
    }
    void Update()
    {
        rend.material.color = Col;

        On = Input.GetKeyDown(KeyCode.C);

        if (On)
            ful = !ful;

        if (GetComponent<ImpulseDestroy>())
        {
            hpr = imp.hpRemain;
            Col = new Color(1 - hpr, hpr, 0, 1);
        }
        else
            Col = new Color(0, 0, 0, 1);

        if (ful)
            Col = Color.white;
    }
}
