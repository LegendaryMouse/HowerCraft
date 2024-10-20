using UnityEngine;
using UnityEngine.UI;

public class EngineUI : MonoBehaviour
{
    public GameObject engine;

    Color Col;
    float hpr;
    Image img;
    ImpulseDestroy impDes;
    RectTransform tr;

    private void Awake()
    {
        img = GetComponent<Image>();
        tr = GetComponent<RectTransform>();
        impDes = engine.GetComponent<ImpulseDestroy>();
    }
    void Update()
    {
        img.color = Col;

        if (engine.GetComponent<ImpulseDestroy>())
        {
            hpr = impDes.hpRemain;
            Col = new Color(1 - hpr, hpr, 0f, 1f);
            img.rectTransform.localScale = new Vector3(1, hpr, 1);
        }
        else
        {
            Debug.Log("Destroyed");
            img.rectTransform.localScale = new Vector3(1, 0, 1);
        }
    }
}
