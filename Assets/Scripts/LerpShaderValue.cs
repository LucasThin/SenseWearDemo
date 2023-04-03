using UnityEngine;

public class LerpShaderValue : MonoBehaviour
{
    [SerializeField] Material targetMaterial;
    [SerializeField] string propertyName = "_YourShaderProperty";
    [SerializeField] float startValue = -0.8f;
    [SerializeField] float endValue = 0.6f;
    [SerializeField] float lerpDuration = 1f;
    [SerializeField] private Subtitles _switchSubtitles;
    [SerializeField] TriggerAudio _triggerAudio;
    private float lerpStartTime;
    private bool isLerping = false;
    
    
    private void Start()
    {
        targetMaterial.SetFloat(propertyName, startValue); //on start, set the shader to start value 
    }

    public void StartLerping()
    {
        lerpStartTime = Time.time; //when animation event calls this function, start a timer
        isLerping = true; //set isLerping to true to execute the lerping in Update()
        Debug.Log("Starting lerp");
    }

    private void Update()
    {
        if (isLerping)
        {
            float timeElapsed = Time.time - lerpStartTime; //calculate how much time has elapsed since the timer started.
                                                           //There's two timers, the one started in Update which is one frame slower and the one started in StartLerping()
                                                           //Minusing them gives how much time started. E.g. lerpStartime is 5sec and time.time is 5.02 seconds
            float t = timeElapsed / lerpDuration; //dividing time elapsed over the total time of animation gives a percentage of how far the animation is at, 0 being not started and 1 being done

            if (t >= 1f) //if timer is more than 1,it means the animation is over. so set it as 1 and stop lerping
            {
                t = 1f;
                isLerping = false;
            }

            float currentValue = Mathf.Lerp(startValue, endValue, t); //lerp the value from start to end based on the percentage of the animation
            targetMaterial.SetFloat(propertyName, currentValue);

            if (!isLerping)
            {
                //Debug.Log("Lerp completed");
               _triggerAudio.PlayAudio();
            }
        }
    }
}