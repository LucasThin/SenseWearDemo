using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public List<AudioObject> clipsToPlay = new List<AudioObject>();
    [SerializeField] private EventInvoker _eventInvoker;

    private void Start()
    {
        Vocals.instance.AllClipsPlayed += OnAllClipsPlayed;
    }
    
    private void OnDestroy()
    {
        // Unsubscribe from the AllClipsPlayed event when the object is destroyed
        Vocals.instance.AllClipsPlayed -= OnAllClipsPlayed;
    }

    private void OnAllClipsPlayed()
    {
        if(_eventInvoker != null)
            _eventInvoker.CallFunction();
    }

    public void PlayAudio()
    {
        Vocals.instance.StartConversation(clipsToPlay);
    }
}
