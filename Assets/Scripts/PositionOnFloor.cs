using UnityEngine;
using Oculus;

public class PositionOnFloor : MonoBehaviour
{
    public GameObject objectToPlace;

    void Start()
    {
        // Get the tracking space's floor height using OVRManager
        OVRManager.Boundary.GetFloorHeight(out float floorHeight);
        OVRManager.Floor

        // Update the object's position to match the floor height
        Vector3 newPosition = objectToPlace.transform.position;
        newPosition.y = floorHeight;
        objectToPlace.transform.position = newPosition;
    }
}