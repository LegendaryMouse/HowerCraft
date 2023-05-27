using UnityEngine;

public class Battery : MonoBehaviour
{
    public float batteryCapaticy;
    public float batteryEnergyRemain;

    private void LateUpdate()
    {
        if(!GetComponent<ImpulseDestroy>())
            Destroy(this);
    }
}
