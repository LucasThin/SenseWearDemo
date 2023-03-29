using UnityEngine;

public class CopyPositionAndYRotation : MonoBehaviour
{
    public Transform source;
    private Transform target;

    void Start()
    {
        target = transform;
    }

    void Update()
    {
        CopyTransform();
    }

    void CopyTransform()
    {
        // Copy position
        target.position = source.position;

        // Copy only the Y rotation
        float yRotation = source.eulerAngles.y;
        target.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}