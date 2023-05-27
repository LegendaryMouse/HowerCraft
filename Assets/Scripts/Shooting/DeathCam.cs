using UnityEngine;

public class DeathCam : MonoBehaviour
{
    void FixedUpdate()
    {
        if (!transform.parent.GetComponent<Shoot>())
        {
            transform.SetParent(transform.parent.transform.parent);

            //GetComponent<Transform>().position.Set(0, 90, 0);
            //GetComponent<Transform>().rotation.Set(90, 0, 0, 0);

            //transform.Translate(-GetComponent<Transform>().position);
            //transform.Rotate(-GetComponent<Transform>().rotation.eulerAngles);

            Destroy(GetComponent<DeathCam>());
        }
    }
}
