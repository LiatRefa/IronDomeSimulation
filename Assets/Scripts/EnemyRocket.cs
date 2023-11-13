using System.Collections;
using UnityEngine;

public class EnemyRocket : Rocket
{
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float startTime;
    public float curveHeight = 5f; // Adjust this value to control the height of the curve

    public float rotationSpeed = 5f;
    // public Transform targetTransform;

    // Call this method to initialize the rocket's movement
    public void Launch(Vector3 start, Vector3 target)
    {
        startPosition = start;
        targetPosition = target;
        startTime = Time.time;

        // Set the initial position of the rocket
        transform.position = start;
        Vector3 targetDirection = targetPosition - transform.position;
        Ray ray = new Ray(transform.position, targetDirection.normalized);

        // You can now cast the ray or perform other operations
        // For example, drawing the ray in the scene view:
        Debug.DrawRay(ray.origin, Vector3.forward, Color.red, 5);
    }

    // Override the Move method to implement the parabolic trajectory
    public override void Movement()
    {
        float progress = (Time.time - startTime) / speed;

        if (progress < 1f)
        {
            // Calculate the current position based on the quadratic equation
            float yPos = Mathf.Lerp(startPosition.y, targetPosition.y, progress);
            float xPos = Mathf.Lerp(startPosition.x, targetPosition.x, progress);
            float curve = curveHeight * Mathf.Sin(progress * Mathf.PI);
            
            transform.position = new Vector3(xPos, yPos + curve, transform.position.z);
            transform.LookAt(targetPosition, Vector3.left);



        }
        else
        {
            // Rocket has reached the target, so explode or handle accordingly
            Explosion();
        }
    }


    private void FixedUpdate()
    {
        Movement();
    }
    
    
}
