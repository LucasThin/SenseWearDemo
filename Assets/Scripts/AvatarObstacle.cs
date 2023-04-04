using UnityEngine;
using System.Collections;

public class AvatarObstacle : MonoBehaviour
{
    [SerializeField]
    private float moveDistance = 8f;
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private float delay = 1.5f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float startTime;

    private void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + transform.forward * moveDistance;

        StartCoroutine(StartMovingAfterDelay(delay));
    }

    private IEnumerator StartMovingAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        startTime = Time.time;
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        float journeyLength = Vector3.Distance(startPosition, targetPosition);

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            float timeSinceStarted = Time.time - startTime;
            float percentageComplete = timeSinceStarted / (journeyLength / moveSpeed);

            transform.position = Vector3.Lerp(startPosition, targetPosition, percentageComplete);
            yield return null;
        }

        transform.position = targetPosition;
        Destroy(gameObject);
    }
}