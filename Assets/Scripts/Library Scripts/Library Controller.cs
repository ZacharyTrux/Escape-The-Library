using UnityEngine;

public class LibraryMusicScript : MonoBehaviour{
    public GameObject horrorBook;
    public GameObject fantasyBook;
    public AudioClip libraryMusic;
    private AudioSource audioSrc;

    void Start(){
        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = libraryMusic;
        audioSrc.Play();

        CheckBooks(); // see if books should be disabled for completion
    }

    private void CheckBooks(){
        if(GameManager.Instance != null){
            if(GameManager.Instance.fantasyCompleted){
                if(fantasyBook != null){
                    fantasyBook.SetActive(false);
                }
            }
            if(GameManager.Instance.horrorCompleted){
                if(horrorBook != null){
                    horrorBook.SetActive(false);
                }
            }
        }
    }
}