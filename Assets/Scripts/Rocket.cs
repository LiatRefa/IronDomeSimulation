using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rocket : MonoBehaviour
{

    public float speed;
    public Vector3 starting_point;
    public bool hit = false;

    public virtual void Movement()
    {
    }

    public virtual void Explosion()
    {
        // need to add here animation, destruction, etc..
    }
}
