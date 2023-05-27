using UnityEngine;

public class CubeClean : MonoBehaviour
{
    private void Update()
    {
        if (!GetComponent<ImpulseDestroy>())
        {
            Invoke(nameof(Die), 10f);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
