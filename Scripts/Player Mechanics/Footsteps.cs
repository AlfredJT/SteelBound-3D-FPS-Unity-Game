using System.Collections;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject footstep;
    private AudioSource footstepAudio;
    private bool canPlayFootsteps = true;
    public float walkSpeed = 1.0f;  
    public float sprintSpeed = 1.5f; 
    private bool isMoving = false;

    void Start()
    {
        footstep.SetActive(false);
        footstepAudio = footstep.GetComponent<AudioSource>();
    }

    void Update()
    {
        bool isPressingSpace = Input.GetKey("space");
        bool isMovingNow = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d");

        if (isPressingSpace)
        {
            StopFootsteps();
            StartCoroutine(PauseFootsteps());
        }
        else if (canPlayFootsteps && isMovingNow)
        {
            bool isSprinting = Input.GetKey(KeyCode.LeftShift);
            float playbackSpeed = isSprinting ? sprintSpeed : walkSpeed;

            if (!isMoving) 
            {
                footsteps(playbackSpeed);
                isMoving = true;
            }
            else
            {
                footstepAudio.pitch = playbackSpeed; 
            }
        }
        else
        {
            StopFootsteps();
            isMoving = false;
        }
    }

    void footsteps(float speed)
    {
        if (!footstep.activeSelf)
        {
            footstep.SetActive(true);
            footstepAudio.pitch = speed;  
            footstepAudio.Play();
        }
    }

    void StopFootsteps()
    {
        if (footstep.activeSelf)
        {
            footstep.SetActive(false);
            footstepAudio.Stop();
        }
    }

    IEnumerator PauseFootsteps()
    {
        canPlayFootsteps = false;
        yield return new WaitForSeconds(0.7f);
        canPlayFootsteps = true;
    }
}
