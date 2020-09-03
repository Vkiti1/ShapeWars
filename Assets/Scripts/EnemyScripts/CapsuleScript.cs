using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScript : Enemy
{
    [SerializeField] float jumpForce = 10f;

    [SerializeField] Rigidbody rb;
    float movementSpeed = 10f;
    float timeToJump = 1f, timePassed = 0f;
    bool isJumping = false;    
    new void Start()
    {
        base.Start();

        Rigidbody rb = GetComponent<Rigidbody>();
        agent.enabled = false;
    }

    new void Update()
    {
        base.Update();

        timePassed += Time.deltaTime;

        if (timePassed >= timeToJump && isJumping == false)
        {
            isJumping = true;
            Jump();
            timePassed = 0f;
        }

        transform.LookAt(player.transform.position);
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isJumping = false;
            rb.velocity = Vector3.zero;
        }
    }


    void Jump()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(0f, jumpForce, 0f, ForceMode.VelocityChange);
        timeToJump = Random.Range(3f, 5f);
    }
}
