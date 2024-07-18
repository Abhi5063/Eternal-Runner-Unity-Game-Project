using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera will follow
    public Vector3 offset;   // Offset position of the camera relative to the target
    public float smoothSpeed = 0.125f; // How smoothly the camera follows the target

    void LateUpdate()
    {
        // Define the desired position based on the target's position and the offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between the current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position to the smoothed position
        transform.position = smoothedPosition;

        // Optionally, you can make the camera look at the target
        // transform.LookAt(target);
    }
}
