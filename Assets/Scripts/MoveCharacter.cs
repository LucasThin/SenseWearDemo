using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCharacter : MonoBehaviour
{
    public List<Transform> destinations;
    public float moveDuration = 1f;
    public float rotationSpeed = 2f;
    public Ease easeType = Ease.OutSine;

    private int currentDestinationIndex = 0;
    
    public event Action OnReachedEnd;

    void Start()
    {
        MoveToNextDestination();
    }

    void Update()
    {
        if (currentDestinationIndex < destinations.Count)
        {
            // Rotate towards the next destination
            Vector3 direction = destinations[currentDestinationIndex].position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
    void MoveToNextDestination()
    {
        if (destinations.Count == 0 || currentDestinationIndex >= destinations.Count)
        {
            OnReachedEnd?.Invoke();
            return;
        }

        Transform target = destinations[currentDestinationIndex];
        transform.DOMove(target.position, moveDuration).SetEase(easeType).OnComplete(() =>
        {
            currentDestinationIndex++;
            MoveToNextDestination();
        });
    }

    // Draw the path in the Unity Editor
    private void OnDrawGizmos()
    {
        if (destinations == null || destinations.Count < 2) return;

        Gizmos.color = Color.green;
        for (int i = 0; i < destinations.Count - 1; i++)
        {
            Transform current = destinations[i];
            Transform next = destinations[i + 1];

            if (current != null && next != null)
            {
                Gizmos.DrawLine(current.position, next.position);
            }
        }
    }

}