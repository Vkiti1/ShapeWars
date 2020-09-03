using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDie : MonoBehaviour
{
    [SerializeField] float lifetime;
    float timePassed = 0f;

    void Update()
    {
        timePassed += Time.deltaTime;

        if(timePassed > lifetime)
        {
            Destroy(this.gameObject);
            timePassed = 0f;
        }
    }
}
