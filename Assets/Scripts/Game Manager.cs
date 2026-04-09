using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;

    public bool fantasyCompleted = false;
    public bool horrorCompleted = false; 
    public float timeLeft;
    public float maxTime = 600f;
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
        SoundManager.StopAllMusic();
        SceneManager.LoadScene("Lose Screen");
    }
}
