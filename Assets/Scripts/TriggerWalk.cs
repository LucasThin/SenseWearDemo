using System;
using UnityEngine;
using Oculus;

public class TriggerWalk : MonoBehaviour
{
    private Animator playerAnimator; // Reference to the Animator component
    private MoveCharacter moveCharacter;

    private bool canWalk = true;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        moveCharacter = GetComponent<MoveCharacter>();
        moveCharacter.OnReachedEnd += OnReachedEnd;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event when the object is destroyed
        if (moveCharacter != null)
        {
            moveCharacter.OnReachedEnd -= OnReachedEnd;
        }
    }

    void OnTriggerStay(Collider other)
    {
        OVRManager ovrManager = other.GetComponent<OVRManager>();

        if (ovrManager != null && canWalk)
        {
            playerAnimator.SetBool("IsWalking", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        OVRManager ovrManager = other.GetComponent<OVRManager>();

        if (ovrManager != null)
        {
            playerAnimator.SetBool("IsWalking", false);
            Debug.Log("Stopped walking");
        }
    }

    // This method will be called when the character reaches the end of the destinations
    private void OnReachedEnd()
    {
        playerAnimator.SetBool("IsWalking", false);
        canWalk = false;
    }
}