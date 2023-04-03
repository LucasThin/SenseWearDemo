using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.PoseDetection;
using UnityEngine;

public class DialogueScenesManager : MonoBehaviour
{
    private GameObject _dialogueScenes;
    private void Awake()
    {
        for(int i =0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            TriggerAudio triggerAudio = child.GetComponent<TriggerAudio>();

            // Check if the child GameObject has a TriggerAudio component
            if (triggerAudio != null)
            {
                // Set the GameObject with the TriggerAudio component as inactive
                child.SetActive(false);
            }
        }
    }
}
