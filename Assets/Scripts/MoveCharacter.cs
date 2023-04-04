using System;
using UnityEngine;
using DG.Tweening;

public class MoveCharacter : MonoBehaviour
{
    public float moveDuration = 1f;
    public Ease easeType = Ease.Linear;

    [SerializeField] private Vector3 destination;

    private Tween moveTween;

    public event Action OnPaused;
    public event Action OnResumed;
    public event Action OnReachedEnd;

    private void Start()
    {
        destination = transform.position + transform.forward * 10; // 10 feet in front
        MoveToDestination();
    }

    private void MoveToDestination()
    {
        moveTween = transform.DOMove(destination, moveDuration)
            .SetEase(easeType)
            .SetAutoKill(false) // Don't kill the tween when completed
            .Pause() // Pause the tween initially
            .OnComplete(() => OnReachedEnd?.Invoke()); // Invoke OnReachedEnd when completed

        moveTween.OnRewind(() => OnResumed?.Invoke());
        Resume(); // Start the movement by resuming the tween
    }

    public void Pause()
    {
        if (moveTween != null && moveTween.IsPlaying())
        {
            moveTween.Pause();
            OnPaused?.Invoke();
        }
    }

    public void Resume()
    {
        if (moveTween != null && !moveTween.IsPlaying())
        {
            moveTween.Play();
            OnResumed?.Invoke();
        }
    }
}