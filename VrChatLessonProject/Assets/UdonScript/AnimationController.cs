
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AnimationController : UdonSharpBehaviour
{
    private Animator animator;
    public string animationName;
    //audio source
    public AudioSource audioSource;
    void Start()
    {
        //get the animator component
        animator = GetComponent<Animator>();
        
    }

    //make a button event to call this function
    public void PlayAnimation()
    {
        Debug.Log("Playing animation");
        //play the animation
        animator.Play(animationName);
        //rimetto da capo l'audio
        audioSource.time = 0;
        //play the audio
        audioSource.Play();
    }
}
