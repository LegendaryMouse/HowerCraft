using UnityEngine;
using UnityEngine.ProBuilder;

public class CameraMove : MonoBehaviour
{
    public float sensitivity = 3f; // Норма сенсы где-то 1.5
    public bool Xrot;
    public bool Yrot;


    private Transform tr;
    private Vector3 qtr;
    private float rotX;
    private float rotY;

    void Awake()
    {
        tr = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        if (Xrot)
            rotX += Input.GetAxis("Mouse X");
        if (Yrot)
            rotY += Input.GetAxis("Mouse Y");

        qtr = new Vector3((-rotY * sensitivity * 0.001f * Screen.width), rotX * sensitivity * 0.001f * Screen.height, 0f);
        tr.localRotation = Quaternion.Euler(qtr);
    }
}