using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float distance = 5.0f; // The distance from the target
    public float height = 2.0f; // The height of the camera
    public float smoothSpeed = 10.0f; // The smoothness of camera movement
    public float rotationSpeed = 5.0f; // The speed of rotation

    private float mouseX; // Mouse X-axis input
    private float mouseY; // Mouse Y-axis input

    private Vector3 offset; // The initial offset from the target

    void Start()
    {
        // Calculate and store the initial offset from the target
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Get mouse input
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -80f, 80f); // Clamp the Y-axis rotation to prevent flipping

        // Rotate the camera and the target around the Y-axis
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        target.rotation = Quaternion.Euler(0, mouseX, 0);
        transform.position = target.position - (rotation * offset);

        // Set the camera's rotation to look at the target
        transform.LookAt(target.position + Vector3.up * height);
    }
}
