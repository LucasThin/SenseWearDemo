using UnityEngine;

public class MatchCameraHeight : MonoBehaviour
{
    public GameObject objectToMatchHeight;
    public Transform cameraTransform;

    void Update()
    {
        // Update the object's position to match the camera's height
        Vector3 newPosition = objectToMatchHeight.transform.position;
        newPosition.y = cameraTransform.position.y;
        newPosition.x = cameraTransform.position.x;
        objectToMatchHeight.transform.position = newPosition;
        
        LookAtCamera();
    }

    private void LookAtCamera()
    {
        // Calculate the direction vector from the object to the target (camera)
        Vector3 direction = cameraTransform.position - transform.position;

        // Remove any vertical rotation so the object doesn't tilt up or down
        direction.y = 0f;

        // Calculate the rotation needed to face the target
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        
        // Add 180 degrees of rotation around the Y-axis
        targetRotation *= Quaternion.Euler(0f, 180f, 0f);

        // Update the object's rotation to face the target (camera)
        transform.rotation = targetRotation;
    }
}