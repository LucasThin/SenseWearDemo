using System;
using UnityEngine;
using Oculus;

public class TriggerWalk : MonoBehaviour
{
    private Animator playerAnimator;
    private MoveCharacter moveCharacter;

    private bool canWalk = true;
    private bool isOvrManagerInTrigger = false;
    private bool isObstacleInTrigger = false;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        moveCharacter = GetComponent<MoveCharacter>();
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
        OVRManager ovrManager = other.GetComponent<OVRManager>();

        if (ovrManager != null)
        {
            isOvrManagerInTrigger = true;
        }

        if (other.CompareTag("Obstacle"))
        {
            isObstacleInTrigger = true;
        }

        if (canWalk && isOvrManagerInTrigger && !isObstacleInTrigger)
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
        OVRManager ovrManager = other.GetComponent<OVRManager>();

        if (ovrManager != null)
        {
            isOvrManagerInTrigger = false;
            playerAnimator.SetBool("IsWalking", false);
            moveCharacter.Pause();
        }

        if (other.CompareTag("Obstacle"))
        {
            isObstacleInTrigger = false;

            if (isOvrManagerInTrigger && canWalk)
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
