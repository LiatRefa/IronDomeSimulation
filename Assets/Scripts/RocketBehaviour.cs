using UnityEngine;
using System.Collections;

public class RocketBehaviour : MonoBehaviour
{
    public void Launch(Vector3 startPoint, Vector3 endPoint, float speed, float height)
    {
        StartCoroutine(MoveAlongParabola(startPoint, endPoint, speed, height));
    }

    private IEnumerator MoveAlongParabola(Vector3 startPoint, Vector3 endPoint, float speed, float height)
    {
        float elapsedTime = 0;
        Vector3 previousPosition = transform.position;

        while (elapsedTime < speed)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / speed; 

            float currentHeight = 4 * height * t * (1 - t);

            Vector3 newPosition = startPoint + (endPoint - startPoint) * t + Vector3.up * currentHeight;
            transform.position = newPosition;

            ApplyRotationBasedOnTrajectory(previousPosition, newPosition);

            previousPosition = newPosition;

            yield return null;
        }

        transform.position = endPoint;
    }

    private void ApplyRotationBasedOnTrajectory(Vector3 previousPosition, Vector3 newPosition)
    {
        Vector3 directionOfTravel = (newPosition - previousPosition).normalized;
        if (directionOfTravel != Vector3.zero)
        {
            float angle = Mathf.Atan2(directionOfTravel.y, directionOfTravel.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90); 
        }
    }
}
