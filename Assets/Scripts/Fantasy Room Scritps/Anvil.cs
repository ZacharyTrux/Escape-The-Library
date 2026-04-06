using UnityEngine;
using TMPro;
using System.Collections;

public class Anvil : MonoBehaviour{
    private int fragmentsNeeded = 3;
    private GameObject repairEffect;
    private float hintDuration = 2.0f;
    private Coroutine hintCoroutine;

    public GameObject hintMessage;

    public void Interact(){
        Debug.Log("Interacting with anvil");
        Inventory inventory = Inventory.Instance;

        if(inventory.slots.Count >= fragmentsNeeded && false){
            RepairSword(inventory);
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

    private void RepairSword(Inventory inventory){
        return;
    }
}
