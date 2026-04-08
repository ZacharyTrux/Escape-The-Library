using UnityEngine;
using StarterAssets;
using System.Collections;
public class MyPlayerController : FirstPersonController
{
    private StarterAssetsInputs _inputs;

    // Update is called once per frame
    public override void Start(){
        base.Start();
        _inputs = GetComponent<StarterAssetsInputs>();
        StartCoroutine(PlayFootsteps());
    }

    private IEnumerator PlayFootsteps() {
        while (true) {
            if (_inputs != null && _inputs.move != Vector2.zero) {
                SoundManager.Play(SoundType.WALKING);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}


