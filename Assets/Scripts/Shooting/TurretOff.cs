using UnityEngine;

public class TurretOff : MonoBehaviour
{
    public ImpulseDestroy imp;
    void Update()
    {
        if (imp.hp < 0.01f)
            Turretoffer();
    }

    public void Turretoffer()
    {
        Destroy(GetComponent<Shoot>());
        Destroy(GetComponent<CameraMove>());
    }
}
