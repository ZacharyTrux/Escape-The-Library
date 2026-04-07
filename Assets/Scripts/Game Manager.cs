using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;

    public float timeLeft;
    private float maxTime = 1200f;
    private bool isTimerRunning = true;


    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
            timeLeft = maxTime;
        }
        else{
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update(){
        if(isTimerRunning){
            if(timeLeft > 0){
                timeLeft -= Time.deltaTime;
            }
            else{
                timeLeft = 0;
                isTimerRunning = false;
                Lose();
            }
        }
    }

    private void Lose(){
        return;
    }
}
