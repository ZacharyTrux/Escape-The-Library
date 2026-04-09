using UnityEngine;

public class LibraryMusicScript : MonoBehaviour{
    public AudioClip libraryMusic;
    private AudioSource audioSrc;

    void Start(){
        audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = libraryMusic;
        audioSrc.Play();
    }
}