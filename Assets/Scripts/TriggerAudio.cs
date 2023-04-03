using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public List<AudioObject> clipsToPlay = new List<AudioObject>();

    public void PlayAudio()
    {
        Vocals.instance.StartConversation(clipsToPlay);
    }
}
