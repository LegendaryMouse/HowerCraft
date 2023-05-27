using UnityEngine;

public class PhyIteration : MonoBehaviour
{
    public int solverIterationUnity;
    Rigidbody[] rigidbodies;

    [System.Obsolete]
    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
            IterationChanger(1);
        if (Input.GetKey(KeyCode.K))
            IterationChanger(-1);
    }

    [System.Obsolete]
    void IterationChanger(int changeAmount)
    {
        if (solverIterationUnity > 4 && solverIterationUnity < 200)
        {
            rigidbodies = FindObjectsOfType<Rigidbody>();
            solverIterationUnity += changeAmount;
            foreach (Rigidbody rigidbody in rigidbodies)
            {
                rigidbody.solverIterations = solverIterationUnity;
                rigidbody.solverVelocityIterations = solverIterationUnity / 2;
            }
        }
    }
}

