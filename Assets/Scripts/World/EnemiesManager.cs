using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public GameObject[] enemies;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            Destroy(enemies[i]);
            i++;
        }
        if (i >= enemies.Length)
        {
            i=0;
        }
    }
}
