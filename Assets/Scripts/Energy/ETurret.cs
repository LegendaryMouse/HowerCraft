using UnityEngine;

public class ETurret : MonoBehaviour
{
    [System.NonSerialized] public GameObject core;
    Reactor r;
    public float shootEnergyCost;
    public bool enoughEnergy = false;

    private void Start()
    {
        r = core.GetComponent<Reactor>();
    }

    public void EShoot()
    {
        enoughEnergy = false;

        for (int i = 0; i < r.batteryCount.Count; i++)
        {
            if (r.batteryCount[i].GetComponent<Battery>())
            {
                Battery b = r.batteryCount[i].GetComponent<Battery>();
                if (b.batteryEnergyRemain > shootEnergyCost)
                {
                    b.batteryEnergyRemain -= shootEnergyCost;
                    enoughEnergy = true;
                    break;
                }
            }
        }
    }
}
