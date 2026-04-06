using UnityEngine;
using TMPro;
using System.Collections;

public class NPC : MonoBehaviour{
    public GameObject hintMessage;
    private float hintDuration = 2.0f;
    private Coroutine hintCoroutine;

    public void Interact(){
        Debug.Log("Interacting with NPC");
        Inventory inventory = Inventory.Instance;

        if(false){
            GiveSword();
        }
        else{
            GiveHint($"Return to me when my sword repair is completed.");
        }
    }

    private void GiveHint(string message){
        if(hintCoroutine != null){
            StopCoroutine(hintCoroutine);
        }

        hintCoroutine = StartCoroutine(HintRoutine(message));
    }

    private IEnumerator HintRoutine(string message){
        var textComp = hintMessage.GetComponent<TMP_Text>();
        textComp.text = message;

        hintMessage.SetActive(true);
        yield return new WaitForSeconds(hintDuration);

        hintMessage.SetActive(false);
        hintCoroutine = null;
    }

    private void GiveSword(){
        return;
    }
}
