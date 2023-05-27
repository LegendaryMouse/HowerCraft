using UnityEngine;
using UnityEngine.UI;

public class TotalHpUI : MonoBehaviour
{
    public TotalHp totalHp;
    Vector2 imageSize;
    Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
    }
    void Update()
    {
        imageSize = new Vector2(totalHp.deltaHp * 100, totalHp.deltaHp * 140);

        img.color = totalHp.Col;
        img.rectTransform.sizeDelta = imageSize;
    }
}
