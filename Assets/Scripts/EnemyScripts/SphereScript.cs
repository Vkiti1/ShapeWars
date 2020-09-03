using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SphereScript : Enemy
{
    new void Start()
    {
        base.Start();
    }

    new void Update()
    {
        base.Update();
        agent.speed += 0.02f;
    }
}
