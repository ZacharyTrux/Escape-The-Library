using UnityEngine;
using System.Collections;

public class FinalDoorScript : MonoBehaviour{
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        animator = GetComponent<Animator>();
        if(GameManager.Instance != null){
            StartCoroutine(DelayedOpen());
        }
    }

    private IEnumerator DelayedOpen() {
        yield return new WaitForEndOfFrame();
        Debug.Log("Fantasy Completed: " + GameManager.Instance.fantasyCompleted);
        Debug.Log("Horror Completed: " + GameManager.Instance.horrorCompleted);

        if (GameManager.Instance.fantasyCompleted && GameManager.Instance.horrorCompleted) {
            SoundManager.Play(SoundType.DOOR, GetComponent<AudioSource>());
            animator.SetTrigger("OpenDoor");
            Debug.Log("Trigger Sent: OpenDoor");
        }
    }
}
