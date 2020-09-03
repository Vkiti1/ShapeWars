using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyScript : Enemy
{
    float fireRate = 1f, timePassed;
    public GameObject bullet;
    public Transform firePoint;
    //Vector3 bulletPosition;

    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        base.Update();

        timePassed += Time.deltaTime;

        transform.LookAt(player.transform.position);

        if (timePassed >= fireRate)
        {
            Shoot();
            timePassed = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, transform.rotation);
    }
}
