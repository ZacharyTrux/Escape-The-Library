using UnityEngine;

public class TitleScreenScript : MonoBehaviour{
    public AudioClip titleMusic;
    private AudioSource audioSrc;

    void Start(){
        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = titleMusic;
        audioSrc.Play();
    }

    public void StartGame(){
        if(GameManager.Instance != null){
            Destroy(GameManager.Instance.gameObject);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("Library (Main Room)");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
