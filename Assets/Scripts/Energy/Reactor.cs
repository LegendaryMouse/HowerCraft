using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour
{
    public float energyProductionRaw;
    public float energyProduction;

    public List<GameObject> batteryCount;

    public float totalEnergyRemain;
    public float totalEnergyCapaticy;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (GetComponent<ImpulseDestroy>())
            energyProduction = energyProductionRaw * GetComponent<ImpulseDestroy>().hpRemain / batteryCount.Count;

        totalEnergyCapaticy = 0;
        totalEnergyRemain = 0;

        for (int i = 0; i < batteryCount.Count; i++)
        {
            //batteryCount[i].GetComponent<Battery>().batteryEnergyRemain = totalEnergyRemain / batteryCount.Count;
        }

        for (int i = 0; i < batteryCount.Count; i++)
        {
            if (batteryCount[i] && batteryCount[i].GetComponent<Battery>())
            {
                Battery b = batteryCount[i].GetComponent<Battery>();
                if (b.batteryEnergyRemain < b.batteryCapaticy && energyProduction < 5000)
                    b.batteryEnergyRemain += energyProduction * Time.deltaTime;
                if (b.batteryEnergyRemain > b.batteryCapaticy)
                    b.batteryEnergyRemain = b.batteryCapaticy;

                totalEnergyCapaticy += b.batteryCapaticy;
                totalEnergyRemain += b.batteryEnergyRemain;
            }

        }

        for (int i = 0; i < batteryCount.Count; i++)
        {
            //batteryCount[i].GetComponent<Battery>().batteryEnergyRemain = totalEnergyRemain / batteryCount.Count;
        }
    }
}
