using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rocket : MonoBehaviour
{
    public bool Hit = false;
    public GameObject RocketPrefab;
    public float speed; 
    public float Height;

    public virtual void Movement()
    {
    }

    public virtual void Launch()
    {

    }

    public virtual void Explosion()
    {
        // need to add here animation, destruction, etc..
    }
    
    public virtual void Recycle()
    {
        // reset all settings of the missle so we can re-use it
    }
}
