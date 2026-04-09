using System.Collections.Generic;
using UnityEngine;

public enum SoundType {
  PICKUP,
  PIPE,
  WALKING,
  NPC,
  PORTAL,
  ANVIL,
  DOOR,
}

public class SoundCollection {
  private AudioClip[] clips;
  private int lastClipIndex;

  public SoundCollection(params string[] clipNames) {
    this.clips = new AudioClip[clipNames.Length];
    for (int i = 0; i < clipNames.Length; i++) {
      clips[i] = Resources.Load<AudioClip>(clipNames[i]);
      if (clips[i] == null) {
        Debug.LogError("you gave me an invalid clip");
      }
    }
    lastClipIndex = -1;
  }

  public AudioClip GetRandClip() {
    if (clips == null || clips.Length == 0) {
      Debug.LogWarning("must have at least one clip");
      return null;
    }
    // If there is only one clip, just return it! 
    // This prevents the while loop from running forever.
    if (clips.Length == 1) {
      return clips[0];
    }
    
    int index = lastClipIndex;
    while (index == lastClipIndex) {
      index = Random.Range(0, clips.Length);
    }
    lastClipIndex = index;
    return clips[index];
  }
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {
  public float mainVolume = 1.0f;
  private Dictionary<SoundType, SoundCollection> sounds;
  private AudioSource audioSrc;

  public static SoundManager Instance { get; private set; }

  private void Awake() {
    if(Instance == null){
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else{
        Destroy(gameObject);
    }
    audioSrc = GetComponent<AudioSource>();
    sounds = new() {
      {SoundType.PICKUP, new SoundCollection("pickup_sound") },
      {SoundType.WALKING, new SoundCollection("walking") },
      {SoundType.NPC, new SoundCollection("npc_sound") },
      {SoundType.PIPE, new SoundCollection("pipe_sound") },
      {SoundType.PORTAL, new SoundCollection("portal") },
      {SoundType.ANVIL, new SoundCollection("anvil_hammer") },
      {SoundType.DOOR, new SoundCollection("door_open") },
    };
  }

  public static void Play(SoundType type, AudioSource audioSrc = null, float pitch = -1) {
    if(Instance.sounds.ContainsKey(type)) {
      audioSrc ??= Instance.audioSrc;
      audioSrc.volume = Random.Range(0.7f, 1.0f) * Instance.mainVolume;
      audioSrc.pitch = pitch >= 0 ? pitch : Random.Range(0.75f, 1.25f);
      audioSrc.clip = Instance.sounds[type].GetRandClip();
      audioSrc.Play();

    }
  }

  public static void StopAllMusic(){
    Instance.audioSrc.Stop();
  }
}