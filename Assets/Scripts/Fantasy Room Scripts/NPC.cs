using UnityEngine;
using TMPro;
using System.Collections;

public class NPC : MonoBehaviour{
    public GameObject hintMessage;
    public Animator doorAnimator;
    private float hintDuration = 2.0f;
    private Coroutine hintCoroutine;
    private Inventory inventory;

    private void Awake(){
        inventory = Inventory.Instance;
    }

    public void Interact(){
        Debug.Log("Interacting with NPC");
        

        if(inventory.HasItem("Completed Sword_0")){
            GiveSword();
            GiveHint($"Thank you for returning my sword, continue forward on your journey!");
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
        inventory.ClearAll();
        doorAnimator.SetTrigger("OpenDoor");
    }
}
