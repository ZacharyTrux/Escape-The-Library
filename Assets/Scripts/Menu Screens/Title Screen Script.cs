using UnityEngine;

public class TitleScreenScript : MonoBehaviour{
    //public AudioClip titleMusic;
    private static AudioClip audioSrc;

    void Start(){
        audioSrc = GetComponent<AudioClip>();
        //audioSrc.Play(titleMusic);
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
