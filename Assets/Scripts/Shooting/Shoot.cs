using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float reloadTime = 2;       //Время Перезарядки

    public int bulletInOboima = 6;   //Количество пуль в одной обойме

    [NonSerialized] public bool isEnemy;  // true если на враге

    public GameObject bullet;        //Сюда ставишь Пулю

    public float bulletSpeed;        //Скорость на Выходе

    public Vector2 offset;           //Отдаление от пушки, чтобы не взорвать себя

    public float startDelay;          //Задержка первого выстрела

    ETurret et;

    AudioSource au;
    Transform tr;

    int bulletShot = 0;

    public bool reloaded = true;
    public bool isReloading = false;
    public GameObject corpuse;

    void Awake()
    {
        tr = GetComponent<Transform>();
        au = GetComponent<AudioSource>();

        //Cursor.lockState = CursorLockMode.Locked;

        if (GetComponent<Enemy>())
            isEnemy = true;

        et = GetComponent<ETurret>();
    }

    void Update()
    {
        if (!isEnemy)
        {
            if (Input.GetMouseButtonDown(0))
                ShootPrepare();

        }
        else
        {
            if (!corpuse.GetComponent<ImpulseDestroy>())
                Destroy(gameObject);
        }

    }

    public void ShootPrepare()       //Куча Логики, не бойся
    {
        if (reloaded)
        {
            bulletShot++;
            if (bulletShot > bulletInOboima - 1)
                reloaded = false;

            Invoke("Shoots", startDelay);
        }
        else
        {
            if (!isReloading)
            {
                if (reloadTime > 0.5f)
                {
                    au.Play();
                }
                Invoke("Reload", reloadTime);
                isReloading = true;
            }
        }
    }

    public void Reload()
    {
        bulletShot = 0;
        reloaded = true;
        isReloading = false;
    }

    public void Shoots()                    // сам Выстрел
    {
        et.EShoot();
        if (et.enoughEnergy)
        {
            Vector3 bulletStartPosition = tr.position + (tr.forward * offset.x) + (tr.up * offset.y);
            GameObject copyBullet = Instantiate(bullet, bulletStartPosition, tr.rotation);
            copyBullet.GetComponent<Rigidbody>().velocity = tr.forward * bulletSpeed;
        }
    }
}