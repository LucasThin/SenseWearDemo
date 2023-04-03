using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public List<AudioObject> clipsToPlay = new List<AudioObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vocals.instance.StartConversation(clipsToPlay);
        }
    }
}
