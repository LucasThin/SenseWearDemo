using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vocals : MonoBehaviour
{
    private AudioSource source;
    public static Vocals instance;
    public event Action AllClipsPlayed;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    public void StartConversation(List<AudioObject> clips)
    {
        StartCoroutine(PlayAudioSequence(clips));
    }
    
    private IEnumerator PlayAudioSequence(List<AudioObject> clips)
    {
        // Loop through each audio object in the list
        foreach (var audioObject in clips)
        {
            // If the audio source is currently playing, stop it
            if (source.isPlaying) source.Stop();

            // Set the audio source's clip to the current audio object's clip
            source.clip = audioObject.clip;
            // Play the audio clip
            source.Play();

            // Set the subtitle and its duration based on the audio object's subtitle and clip length
            Subtitles.instance.SetSubtitle(audioObject.subtitle, audioObject.clip.length);

            // Wait for the duration of the audio clip before moving on to the next one
            yield return new WaitForSeconds(audioObject.clip.length);
        }
        
        AllClipsPlayed?.Invoke();
    }
}
