using UnityEngine;

public class ImpulseDestroy : MonoBehaviour
{
    public float hp;
    [System.NonSerialized] public float maxHp;
    [System.NonSerialized] public float hpRemain;

    public AudioSource explosion;

    void Awake()
    {
        hp = GetComponent<Rigidbody>().mass * 1000;
        if (GetComponent<Engine>())
            hp = GetComponent<Rigidbody>().mass * 150;
        if(GetComponent<Rigidbody>().mass == 150)
            hp = GetComponent<Rigidbody>().mass * 75;
        if (GetComponent<FunctionsControl>())
            hp = GetComponent<Rigidbody>().mass * 50;

        maxHp = hp;
    }

    void OnCollisionEnter(Collision other)
    {
        Vector3 impRaw = other.impulse;
        float imp = Mathf.Clamp(impRaw.magnitude, 0, hp);

        if (imp > 0.005f * hp)
            hp -= imp;
    }

    void Update()
    {
        //Debug.Log("name: " + name + " imp = " + imp + " hp remains: " + hp);

        hpRemain = hp / maxHp;
        if (hp < 0.1f)
        {
            if (GetComponent<Explode>())
                GetComponent<Explode>().Explosion();

            Destruct();
        }
    }
    void Destruct()
    {
        Destroy(GetComponent<ConfigurableJoint>());
        Destroy(GetComponent<ImpulseDestroy>());
    }
}

















//Debug.Log((name + " " + (GetComponent<Transform>().position - core.GetComponent<Transform>().position).magnitude));
//if((GetComponent<Transform>().position - core.GetComponent<Transform>().position).magnitude > 12)
//Destruct();


/*hpRemain = 0;
if(name == "Core")

{
float cmas = GetComponent<Rigidbody>().mass;
explosion.Play();
GetComponent<Rigidbody>().mass = cmas * 100;
TurretHp.hp = 0;
Collider[] blocks = Physics.OverlapSphere(transform.position, cmas / 40);
for(int i=0;i<blocks.Length;i++)
{
    float dist = (transform.position - blocks[i].GetComponent<Transform>().position).magnitude;
    if(blocks[i].GetComponent<ImpulseDestroy>())
        blocks[i].GetComponent<ImpulseDestroy>().hp = blocks[i].GetComponent<ImpulseDestroy>().hp - ((cmas * 5) / dist);
    if(blocks[i].GetComponent<Rigidbody>())
        blocks[i].GetComponent<Rigidbody>().AddExplosionForce(cmas * 2.5f, transform.position, cmas / 40, 1);
}

}

if(name == "Sphere")
Destroy(GetComponent<CameraMove>());
Destroy(GetComponent<Enemy>());
Destroy(GetComponent<ImpulseDestroy>()); 

if(GetComponent<HowerController>())
{
float mas = GetComponent<Rigidbody>().mass;
Debug.Log(hp + name);
explosion.Play();
GetComponent<HowerController>().core.GetComponent<ImpulseDestroy>().hp = GetComponent<HowerController>().core.GetComponent<ImpulseDestroy>().hp - (GetComponent<HowerController>().core.GetComponent<ImpulseDestroy>().maxHp / GetComponent<HowerController>().core.GetComponent<FunctionsControl>().engines.Length);
Collider[] blocks = Physics.OverlapSphere(transform.position, mas / 10);
for(int i=0;i<blocks.Length;i++)
{
    if(blocks[i].GetComponent<ImpulseDestroy>())
        blocks[i].GetComponent<ImpulseDestroy>().hp = blocks[i].GetComponent<ImpulseDestroy>().hp - (mas * 3);
    if(blocks[i].GetComponent<Rigidbody>())
        blocks[i].GetComponent<Rigidbody>().AddExplosionForce(mas * 10, transform.position, mas / 10, 1);
}
}*/

