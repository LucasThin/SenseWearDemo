using System;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    private Animator playerAnimator; // Reference to the Animator component

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void OnTriggerStay(Collider other)
    {
        playerAnimator.SetBool("IsWalking", true);
        
    }

    void OnTriggerExit(Collider other)
    {
       playerAnimator.SetBool("IsWalking", false);
    }
}