using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    //varijable
    [SerializeField] float maxHealth;
    public float health;
    [SerializeField] float pointsToGive;
    public GameObject player;
    [SerializeField] Slider slider;
    public NavMeshAgent agent;
    //metode

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        health = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;
        slider.value = CalculateHealth();
    }
    public void Update()
    {
        agent.destination = player.transform.position;

        slider.value = CalculateHealth();

        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
        player.GetComponent<Player>().points += pointsToGive;
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }
}
