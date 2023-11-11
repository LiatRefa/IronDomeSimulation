using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rocket : MonoBehaviour
{
    public bool Hit = false;
    public GameObject RocketPrefab;
    public float FlightDuration; 
    public float Height;

    public virtual void Movement(Vector3 startPoint, Vector3 endPoint, float speed, float height)
    {
    }

    public virtual void Launch()
    {

    }

    public virtual void Explosion()
    {
        // need to add here animation, destruction, etc..
    }
}
