using System;
using UnityEngine;
using Oculus;
using UnityEditor.Animations;

public class TriggerWalk : MonoBehaviour
{
    private Animator playerAnimator; // Reference to the Animator component

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void OnTriggerStay(Collider other)
    {
        OVRManager ovrManager = other.GetComponent<OVRManager>();

        if (ovrManager != null)
        {
            playerAnimator.SetBool("IsWalking", true);
           //Debug.Log("Is walking");
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
}