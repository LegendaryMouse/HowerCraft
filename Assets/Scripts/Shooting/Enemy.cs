using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Collider[] target;

    Shoot shot;

    private Transform tr;
    private Vector3 qtr;

    public bool Xrotation;
    public bool Yrotation;

    public Quaternion totalRotationEuler;
    public Vector3 totalRotation;
    public Vector3 trueRotation;

    float rotationX;
    float rotationY;


    void Awake()
    {
        tr = GetComponent<Transform>();
        shot = GetComponent<Shoot>();
    }

    void R()
    {
        shot.Reload();
    }

    void Update()
    {
        Collider[] target = Physics.OverlapSphere(tr.position, 250);

        for (int i = 0; i < target.Length; i++)
        {

            if (target[i].GetComponent<Rigidbody>())
                if (target[i].transform.root.name == "OffRoad")
                    if (target[i].GetComponent<ImpulseDestroy>())
                    {

                        totalRotationEuler = Quaternion.LookRotation(target[i].GetComponent<Transform>().position - tr.position);
                        totalRotation = totalRotationEuler.eulerAngles;

                        rotationX = totalRotation.x;
                        rotationY = totalRotation.y;

                        if (!Xrotation)
                        {
                            rotationX = 0.0f;
                        }
                        if (!Yrotation)
                        {
                            rotationY = 0.0f;
                        }

                        trueRotation = new Vector3(rotationX, rotationY, 0);
                        tr.rotation = Quaternion.Euler(trueRotation);

                        //tr.rotation = Quaternion.identity;
                        //tr.Rotate(trueRotation);

                        //Debug.Log(name + "   " + trueRotation + " <rotation / current> " + tr.rotation.eulerAngles + "   " + target[i].name);

                        if (GetComponent<Shoot>())
                            shot.ShootPrepare();

                        i = 9999;
                    }
        }
        if (Yrotation && tr.rotation.eulerAngles.y != 0)
        {
            //Debug.LogWarning("Enemy is rotating on Y axis, but rotationY is set to false!");
        }
    }
}
