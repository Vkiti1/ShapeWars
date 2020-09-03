using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float lifetime = 0f;
    float timeFlying;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem hit;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        timeFlying += Time.deltaTime;

        if(timeFlying >= lifetime)
        {
            Destroy(this.gameObject);
            timeFlying = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().health -= damage;
            Destroy(this.gameObject);
            Instantiate(hit, transform.position, Quaternion.identity);
        }
        else if (other.gameObject.tag == "Obstacle")
        {
            Destroy(this.gameObject);
            Instantiate(hit, transform.position, Quaternion.identity);
        }
    }
}
