using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFactory : MonoBehaviour
{
    public GameObject target;
    public EnemyRocket enemyRocket;

    public void spawn_rocket()
    {
        SpawnRocket();
    }

    public void SpawnRocket()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);
        enemyRocket.Launch(spawnPosition, target.transform.position);
    }


}
