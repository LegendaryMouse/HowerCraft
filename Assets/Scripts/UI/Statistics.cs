using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    public Text enginePower;
    public Text currentHeight;
    public Text coreSpeed;
    public Text fps;

    HCControl hc;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hc = GetComponent<HCControl>();
    }
    void Update()
    {
        RaycastHit shit;  // Ненавижу лучи
        Physics.Raycast(transform.position, -transform.up, out shit);

        if (enginePower)
            enginePower.text = "Force: " + hc.engineForce;
        if (currentHeight)
            currentHeight.text = "Height: " + Mathf.Round(shit.distance * 100) + "SM";
        if (coreSpeed)
            coreSpeed.text = "Speed: " + Mathf.Round(rb.velocity.magnitude * 3.6f) + "K/H";
        if (fps)
        {
            fps.text = "FPS: " + Mathf.Round(1 / Time.deltaTime);
        }
        if (rb.velocity.magnitude > 200)
        {
            SceneManager.LoadScene(0);
            Debug.Log(rb.velocity.magnitude);
        }
    }
}
