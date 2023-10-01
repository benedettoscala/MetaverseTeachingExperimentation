
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Animazione : UdonSharpBehaviour
{
    public GameObject bloccoVideo;
    public GameObject canvas;
    public UdonBehaviour videoPlayer;
    public UdonBehaviour udonBehaviour;
    private float waitTime = 1.0f; // Time to wait in seconds
    private float timer;
    
    private float waitTimeVideo = 2.0f; // Time to wait in seconds
    private float timerVideo;
    private bool isWaitingToPlayAnimation = false;

    private bool isWaitingToPlayVideo = false;
    private Vector3 position;

    private Animator animator;
    public AudioSource audioSource;

    private bool lessonStarted = false;


    void Start()
    {
        //save this gameobject position
        position = this.transform.position;
        animator = GetComponent<Animator>();
        //ferma l'animazione
        animator.enabled = false;
        //ferma l'audio
        audioSource.Stop();
        //make the gameobject invisibile without using set
        //transalte it away from the scene
        this.transform.position = new Vector3(100, 100, 100);

    }

    void Update()
    {
        //se il giocatore preme spazio
        if (Input.GetKeyDown(KeyCode.X))
        {
            //play animation
            PlayAnimation();
        }
        // Check if the timer has reached the wait time
        if (isWaitingToPlayAnimation)
        {
            this.gameObject.SetActive(true);
            if (Time.time >= timer)
            {
                isWaitingToPlayAnimation = false;
                ExecuteDelayedActions();
            }
        }
        if (isWaitingToPlayVideo)
        {
            if (Time.time >= timerVideo)
            {
                isWaitingToPlayVideo = false;
                udonBehaviour.SendCustomEvent("OnPlayButtonPress");
            }
        }

        /*
        if(!lessonStarted)
        {
            udonBehaviour.SendCustomEvent("restartVideo");
        }
        */
    }

    public void PlayVideoDelayed()
    {
        Debug.Log("PlayVideoDelayed");
        StartWaitingToPlayVideo();
    }

    void StartWaitingToPlayVideo()
    {
        isWaitingToPlayVideo = true;
        timerVideo = Time.time + waitTimeVideo;
    }

    public void PlayAnimation()
    {
        Debug.Log("PlayAnimation");
        StartWaitingToPlayAnimation();
    }

    void StartWaitingToPlayAnimation()
    {
        isWaitingToPlayAnimation = true;
        timer = Time.time + waitTime;
    }

    void ExecuteDelayedActions()
    {
        //translate it back to the original position
        this.transform.position = position;
        bloccoVideo.SetActive(false);
        lessonStarted = true;
        udonBehaviour.SendCustomEvent("restartVideo");
        
        // Replay animation from the start
        animator.Play("anim_lezione", 0, 0);
        animator.enabled = true;
        //make the canvas invisible
        //canvas.SetActive(false);

        // Start the audio
        audioSource.Play();
        //udonBehaviour.SendCustomEvent("OnPlayButtonPress");

    }

    /*
    public void PlayAnimation(){
        //wait
        Debug.Log("PlayAnimation");
        //avvia l'animazione
        //replay animation from the start
        animator.Play("anim_lezione", 0, 0);
        animator.enabled = true;
        //avvia l'audio
        audioSource.Play();
    }
    */
}
