using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour{
    private TextMeshPro timerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        timerText = GetComponentInChildren<TextMeshPro>();        
    }

    // Update is called once per frame
    void Update(){
        if(GameManager.Instance != null){
            timerText.text = GetFormattedTime(GameManager.Instance.timeLeft);
        }
        else{
            timerText.text = "00:00";
        }
        
    }

    public static string GetFormattedTime(float timeLeft){
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
