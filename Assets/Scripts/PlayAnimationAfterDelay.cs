using System.Collections;
using UnityEngine;

public class PlayAnimationAfterDelay : MonoBehaviour
{
    public Animator animator;
    public string animationTrigger;
    public float delayInSeconds;

    void Start()
    {
        StartCoroutine(PlayAnimationWithDelay());
    }

    IEnumerator PlayAnimationWithDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        animator.SetTrigger(animationTrigger);
    }
}