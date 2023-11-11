using System.Collections;
using UnityEngine;

public class EnemyRocket : Rocket
{
    public Transform targetLocation;
    public float radius = 50f;

    public override void Movement(Vector3 startPoint, Vector3 endPoint, float speed, float height)
    {
        StartCoroutine(MoveAlongParabola(startPoint, endPoint, speed, height));
    }

    public override void Launch()
    {
        Vector3 randomTargetPoint = GetRandomPointInRadius(targetLocation.position, radius);
        FireRocket(transform.position, randomTargetPoint, FlightDuration, Height);
    }

    Vector3 GetRandomPointInRadius(Vector3 center, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection.y = 0; 
        return center + randomDirection;
    }

    private void FireRocket(Vector3 startPoint, Vector3 endPoint, float speed, float height)
    {
        GameObject rocketInstance = Instantiate(RocketPrefab, startPoint, Quaternion.identity);
        RocketBehaviour rocketScript = rocketInstance.GetComponent<RocketBehaviour>();
        rocketScript.Launch(startPoint, endPoint, speed, height);
    }

    private IEnumerator MoveAlongParabola(Vector3 startPoint, Vector3 endPoint, float speed, float height)
    {
        float elapsedTime = 0;
        Vector3 previousPosition = transform.position;

        // Continue the loop until the object has moved for the specified duration
        while (elapsedTime < speed)
        {
            elapsedTime += Time.deltaTime;

            // Calculate normalized time t in the range [0, 1]
            float t = elapsedTime / speed;

            // Calculate the current height of the object using a parabolic formula
            float currentHeight = 4 * height * t * (1 - t);

            // Calculate the new position along the parabola
            Vector3 newPosition = startPoint + (endPoint - startPoint) * t + Vector3.up * currentHeight;
            transform.position = newPosition;

            ApplyRotationBasedOnTrajectory(previousPosition, newPosition);

            previousPosition = newPosition;

            yield return null;
        }

        transform.position = endPoint;
    }

    // Adjusts the rotation of the object to align with its current trajectory.
    private void ApplyRotationBasedOnTrajectory(Vector3 previousPosition, Vector3 newPosition)
    {
        Vector3 directionOfTravel = (newPosition - previousPosition).normalized;

        if (directionOfTravel != Vector3.zero)
        {
            // Calculate rotation angle based on direction of travel and apply to the object
            float angle = Mathf.Atan2(directionOfTravel.y, directionOfTravel.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }

}
