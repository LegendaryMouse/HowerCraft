using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explosionLight;
    public GameObject engineLight;

    public ImpulseDestroy TurretHp;
    public AudioSource explosionVolume;
    public int afterExplodeLifeTime = 10;

    Transform tr;
    ImpulseDestroy id;
    Rigidbody rb;
    float lMas;
    float mas;
    bool deadCore = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        id = GetComponent<ImpulseDestroy>();
        explosionVolume.volume = rb.mass / 500;

        mas = id.maxHp;
        lMas = mas / 100;
    }
    void Update()
    {
        if (deadCore)
            KillEngine();
    }
    public void Explosion()
    {
        if (id)
            mas = id.maxHp;

        lMas = mas / 100;

        if (explosionLight)
            explosionLight.SetActive(true);
        if (engineLight)
            engineLight.SetActive(false);




        explosionVolume.Play();

        if (GetComponent<FunctionsControl>())
            CoreExplode();
        if (GetComponent<Engine>())
            EngineExplode();

        Collider[] blocks = Physics.OverlapSphere(transform.position, lMas);
        for (int i = 0; i < blocks.Length; i++)
        {
            tr = blocks[i].GetComponent<Transform>();
            id = blocks[i].GetComponent<ImpulseDestroy>();
            rb = blocks[i].GetComponent<Rigidbody>();

            float distRaw = Vector3.Distance(GetComponent<Transform>().position, tr.position);
            float dist = Mathf.Clamp(distRaw, 1, Mathf.Infinity);

            if (id)
                id.hp -= ((mas * 1) / (dist * dist));
            if (rb)
                rb.AddExplosionForce((mas * 1) / dist, tr.position, lMas);
        }


    }

    void CoreExplode()
    {
        deadCore = true;
        FunctionsControl fc = GetComponent<FunctionsControl>();
        for (int c = 0; c < fc.fari.Capacity; c++)
        {
            if (fc.fari[c])
                Destroy(fc.fari[c]);
        }

        if (TurretHp)
            TurretHp.hp = 0;
    }

    void KillEngine()
    {
        FunctionsControl fc = GetComponent<FunctionsControl>();

        for (int a = fc.engines.Count - 1; a >= 0; a--)
        {
            if (fc.engines[a] && fc.engines[a].GetComponent<ImpulseDestroy>())
            {
                ImpulseDestroy iD = fc.engines[a].GetComponent<ImpulseDestroy>();
                iD.hp -= (iD.maxHp / afterExplodeLifeTime * Time.deltaTime);
            }
        }
    }

    void EngineExplode()
    {
        ImpulseDestroy ID = GetComponent<Engine>().core.GetComponent<ImpulseDestroy>();
        if (ID)
        {
            ID.hp -= (ID.maxHp / 5);
        }
        Destroy(GetComponent<Engine>());
    }
}
