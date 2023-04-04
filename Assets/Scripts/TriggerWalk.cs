using System;
using UnityEngine;
using Oculus;

public class TriggerWalk : MonoBehaviour
{
    private Animator playerAnimator;
    private MoveCharacter moveCharacter;
    private ColorChanger colorChanger;

    private bool canWalk = true;
    private bool isPlayerBodyInTrigger = false;
    private bool isObstacleInTrigger = false;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        moveCharacter = GetComponent<MoveCharacter>();
        colorChanger = GetComponent<ColorChanger>();
        moveCharacter.OnReachedEnd += OnReachedEnd;
        moveCharacter.OnPaused += OnPaused;
        moveCharacter.OnResumed += OnResumed;
    }

    private void OnDestroy()
    {
        if (moveCharacter != null)
        {
            moveCharacter.OnReachedEnd -= OnReachedEnd;
            moveCharacter.OnPaused -= OnPaused;
            moveCharacter.OnResumed -= OnResumed;
        }
    }

    void OnTriggerStay(Collider other)
    {
        
        CopyPositionAndYRotation PlayerBody = other.GetComponent<CopyPositionAndYRotation>();

        if (PlayerBody != null)
        {
            isPlayerBodyInTrigger = true;
        }

        if (other.CompareTag("Obstacle"))
        {
            isObstacleInTrigger = true;
            colorChanger.ChangeToAlertColor();
        }

        if (canWalk && isPlayerBodyInTrigger && !isObstacleInTrigger)
        {
            playerAnimator.SetBool("IsWalking", true);
            moveCharacter.Resume();
        }
        else
        {
            playerAnimator.SetBool("IsWalking", false);
            moveCharacter.Pause();
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        CopyPositionAndYRotation PlayerBody = other.GetComponent<CopyPositionAndYRotation>();

        if (PlayerBody != null)
        {
            isPlayerBodyInTrigger = false;
            playerAnimator.SetBool("IsWalking", false);
            moveCharacter.Pause();
        }

        if (other.CompareTag("Obstacle"))
        {
            isObstacleInTrigger = false;
            colorChanger.ChangeToOriginalColor();

            if (isPlayerBodyInTrigger && canWalk)
            {
                moveCharacter.Resume();
            }
        }
    }

    private void OnPaused()
    {
        Debug.Log("Paused");
    }

    private void OnResumed()
    {
        Debug.Log("Resumed");
    }

    private void OnReachedEnd()
    {
        playerAnimator.SetBool("IsWalking", false);
        canWalk = false;
    }
}
