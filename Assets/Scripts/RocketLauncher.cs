using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform targetLocation; // Assign this in the inspector
    public float radius = 50f; // Radius around the target location
    public float initialSpeed = 30f; // Adjust this value to control the speed
    public float height;

    // This method can be called by a UI button
    public void LaunchRocket()
    {
        Vector3 randomTargetPoint = GetRandomPointInRadius(targetLocation.position, radius);
        FireRocket(transform.position, randomTargetPoint, initialSpeed, height);
    }

    Vector3 GetRandomPointInRadius(Vector3 center, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection.y = 0; // Assuming you want to stay on the same horizontal plane
        return center + randomDirection;
    }

    private void FireRocket(Vector3 startPoint, Vector3 endPoint, float speed, float height)
    {
        GameObject rocketInstance = Instantiate(rocketPrefab, startPoint, Quaternion.identity);
        RocketBehaviour rocketScript = rocketInstance.GetComponent<RocketBehaviour>();
        rocketScript.Launch(startPoint, endPoint, speed, height);
    }
}
