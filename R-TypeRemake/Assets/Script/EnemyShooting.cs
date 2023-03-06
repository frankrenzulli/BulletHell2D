using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float nextFire;
    public float fireRate;

    [SerializeField] float timer;
    void Start()
    {
       
    }

    void Update()
    {

        if (Time.time > nextFire)
        {

            Shoot();
        }
    }

    void Shoot()
    {
        nextFire = Time.time + fireRate;
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
