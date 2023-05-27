using UnityEngine;
using UnityEngine.UI;

public class EngineUI : MonoBehaviour
{
    public GameObject engine;

    Color Col;
    float hpr;
    Image img;
    ImpulseDestroy impDes;

    private void Awake()
    {
        img = GetComponent<Image>();
        impDes = engine.GetComponent<ImpulseDestroy>();
    }
    void Update()
    {
        img.color = Col;

        if (engine.GetComponent<ImpulseDestroy>())
        {
            hpr = impDes.hpRemain;
            Col = new Color(1 - hpr, hpr, 0f, 1f);
        }
        else
        {
            Col = new Color(0, 0, 0, 0.8f);
        }
    }
}
