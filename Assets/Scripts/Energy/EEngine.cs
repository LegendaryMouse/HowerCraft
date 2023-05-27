using UnityEngine;

public class EEngine : MonoBehaviour
{
    HCControl hcc;
    public float speedBoost;
    public float boostEnergyCost;
    float originalForce;

    Reactor r;

    private void Start()
    {
        hcc = GetComponent<HCControl>();

        originalForce = hcc.engineForce;

        r = GetComponent<Reactor>();
    }
    private void Update()
    {
        hcc.engineForce = originalForce;

        if (Input.GetKey(KeyCode.N))
            for (int i = 0; i < r.batteryCount.Count; i++)
            {
                if (r.batteryCount[i].GetComponent<Battery>())
                {
                    Battery b = r.batteryCount[i].GetComponent<Battery>();
                    if (b.batteryEnergyRemain > boostEnergyCost)
                    {
                        b.batteryEnergyRemain -= boostEnergyCost;
                        hcc.engineForce *= speedBoost;
                        break;
                    }
                }
            }
    }
}
