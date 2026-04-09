using UnityEngine;
using StarterAssets;
using System.Collections;
public class MyPlayerController : FirstPersonController
{
    private StarterAssetsInputs _inputs;
    private AudioSource audioSrc;
    private Coroutine footstepCoroutine;

    // Update is called once per frame
    public override void Start(){
        base.Start();
        audioSrc = GetComponent<AudioSource>();
        _inputs = GetComponent<StarterAssetsInputs>();
        footstepCoroutine = StartCoroutine(PlayFootsteps());
    }

    private IEnumerator PlayFootsteps() {
        while (true) {
            if (_inputs != null && _inputs.move != Vector2.zero) {
                if(SoundManager.Instance != null){
                    SoundManager.Play(SoundType.WALKING, audioSrc);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}


