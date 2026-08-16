using UnityEngine;

public class Jump : MonoBehaviour
{
    public AudioSource jumpSound;
    private bool isHoldingSpace = false;

    void Update()
    {
        if (Input.GetKeyDown("space") && !isHoldingSpace)
        {
            isHoldingSpace = true;
            StartCoroutine(PlayJumpSoundWhileHeld());
        }
        
        if (Input.GetKeyUp("space"))
        {
            isHoldingSpace = false;
            StopCoroutine(PlayJumpSoundWhileHeld());
        }
    }

    System.Collections.IEnumerator PlayJumpSoundWhileHeld()
    {
        while (isHoldingSpace)
        {
            jumpSound.Play();
            yield return new WaitForSeconds(0.7f); // Wait for 0.7 seconds before replaying
        }
    }
}