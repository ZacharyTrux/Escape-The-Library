using UnityEngine;

public class TitleScreenScript : MonoBehaviour{
    public AudioClip titleMusic;
    private AudioSource audioSrc;

    void Start(){
        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = titleMusic;
        audioSrc.Play();
        Cursor.lockState = CursorLockMode.Confined; // Locks cursor within the window
        Cursor.visible = true;
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
