using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class WinScreenScript : MonoBehaviour{
    public AudioClip winMusic;
    private AudioSource audioSrc;
    public Animator playerAnimator;
    public GameObject person;
    public GameObject UI;
    public TextMeshProUGUI timeText;

    void Start(){
        audioSrc = GetComponent<AudioSource>();
        timeText.text = "Time: " + TimerScript.GetFormattedTime(GameManager.Instance.timeLeft);
        StartCoroutine(AnimatePlayer());
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

    private IEnumerator AnimatePlayer(){
        if(UI != null){
             UI.SetActive(false);
        }
        
        playerAnimator.SetTrigger("isMoving");
        yield return new WaitForSeconds(2.3f);
        audioSrc.clip = winMusic;
        audioSrc.Play();
        ChangePlayerColor();
        yield return new WaitForSeconds(0.5f);

        UI.SetActive(true);
    }

    private void ChangePlayerColor(){
        foreach(Transform child in person.transform){
            SpriteRenderer rend = child.GetComponent<SpriteRenderer>();
            if(rend != null){
                rend.color = Color.white;
            }
        }
    }
}
