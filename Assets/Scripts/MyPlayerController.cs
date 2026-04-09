using UnityEngine;
using StarterAssets;
using System.Collections;
public class MyPlayerController : FirstPersonController
{
    private StarterAssetsInputs _inputs;
    private AudioSource audioSrc;

    // Update is called once per frame
    public override void Start(){
        base.Start();
        audioSrc = GetComponent<AudioSource>();
        _inputs = GetComponent<StarterAssetsInputs>();
        StartCoroutine(PlayFootsteps());
    }

    private IEnumerator PlayFootsteps() {
        while (true) {
            if (_inputs != null && _inputs.move != Vector2.zero) {
                SoundManager.Play(SoundType.WALKING, audioSrc);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}


