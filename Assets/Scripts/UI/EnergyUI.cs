using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    public Reactor reactor;
    float width;
    float delta;
    Image img;

    void Awake()
    {
        img = GetComponent<Image>();
        width = img.rectTransform.sizeDelta.x;
    }
    void Update()
    {
        delta = width * reactor.totalEnergyRemain / reactor.totalEnergyCapaticy;
        Vector2 size = new(delta, img.rectTransform.sizeDelta.y);
        img.rectTransform.sizeDelta = size;

    }
}
