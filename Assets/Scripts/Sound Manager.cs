using System.Collections.Generic;
using UnityEngine;

public enum SoundType{
    TUMBLE,
    PICKUP,
    WALKING,
}

public class SoundCollection{
    private AudioClip[] clips;
    private int lastClipIndex;

    public SoundCollection(string[] clipNames){
        this.clips = new AudioClip[clipNames.Length];
        for(int i = 0; i < clipNames.Length; i++){
            clips[i] = Resources.Load<AudioClip>(clipNames[i]);
            if(clips[i] == null){
                Debug.LogError("Invalid audio clip inserted");
            }
        }
        lastClipIndex = -1;
    }

    public AudioClip GetRandClip(){
        if(clips.Length == 0){
            Debug.LogWarning("Must have at least one clip");
            return null;
        }
        else if(clips.Length == 1){
            return clips[0];
        }
        else{
            int index = lastClipIndex;
            while(index == lastClipIndex)
            {
                index = Random.Range(0, clips.Length);
            } 
            lastClipIndex = index;
            return clips[index];
        }
    }
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour{
    public float mainVolume = 1.0f;
    private Dictionary<SoundType, SoundCollection> sounds;
    private AudioSource audioSrc;

    public static SoundManager Instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake(){
        Instance = this;
        audioSrc = GetComponent<AudioSource>();
        sounds = new() {
            {SoundType.PICKUP, new SoundCollection(new string[] { ""}) },
            {SoundType.TUMBLE, new SoundCollection(new string[] { ""}) },
            {SoundType.WALKING, new SoundCollection(new string[] { ""}) }
        };
    }
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
