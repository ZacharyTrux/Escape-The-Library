using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoseScreenScript : MonoBehaviour{
    public AudioClip loseMusic;
    public AudioClip playerScream;
    private AudioSource audioSrc;
    public Animator bookAnimator;
    public GameObject UI;

    void Start(){
        audioSrc = GetComponent<AudioSource>();
        StartCoroutine(AnimateBook());
    }

    public void RestartGame(){
        if(GameManager.Instance != null){
            Destroy(GameManager.Instance.gameObject);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("Library (Main Room)");
    }

    public void MoveTitleScreen(){
        if(GameManager.Instance != null){
            Destroy(GameManager.Instance.gameObject);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title Screen");
    }

    private IEnumerator AnimateBook(){
        if(UI != null){
            UI.SetActive(false);
        }
        bookAnimator.SetTrigger("CloseBook");
        yield return new WaitForSeconds(1f);
        audioSrc.PlayOneShot(playerScream);
        yield return new WaitForSeconds(2f);

        audioSrc.clip = loseMusic;
        audioSrc.Play();
        UI.SetActive(true);
    }
}
