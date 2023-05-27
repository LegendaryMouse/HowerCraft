using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    bool secondRun = false;

    public int targetFPS = 5;

    void Start()
    {
        Invoke("LowFpsAwoid", 5f);
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P))
            ReloadScene();

        if (secondRun)
            LowFpsAwoid();
    }

    void LowFpsAwoid()
    {
        secondRun = true;

        if (1 / Time.deltaTime < targetFPS)
        {
            Debug.Log("Your fps was: " + 1 / Time.deltaTime);
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

