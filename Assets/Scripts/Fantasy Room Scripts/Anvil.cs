using UnityEngine;
using TMPro;
using System.Collections;

public class Anvil : MonoBehaviour{
    private int fragmentsNeeded = 3;
    private GameObject repairEffect;
    private float hintDuration = 2.0f;
    private Coroutine hintCoroutine;
    private Inventory inventory;

    public GameObject hintMessage;
    public GameObject completedSword; 

    private void Awake(){
        inventory = Inventory.Instance;
    }

    public void Interact(){
        if(inventory.ItemCount() >= fragmentsNeeded){
            RepairSword();
        }
        else{
            GiveHint($"You need {fragmentsNeeded} pieces to forge the sword.");
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

    private void RepairSword(){
        GetComponent<BoxCollider>().enabled = false;
        inventory.ClearAll();
        completedSword.SetActive(true);
    }
}
