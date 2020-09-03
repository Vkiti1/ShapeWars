using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed;
    public float lifetime = 5f;
    public float damage = 10f;
    public ParticleSystem hit;
    float timeFlying = 0;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        timeFlying += Time.deltaTime;

        if (timeFlying >= lifetime)
        {
            Destroy(this.gameObject);
            timeFlying = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"|| other.gameObject.tag == "Obstacle")
            Instantiate(hit, transform.position, Quaternion.identity);
            Destroy(this.gameObject);    
    }
}
