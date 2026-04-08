using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public static GameManager Instance;

    public bool fantasyCompleted = false;
    public bool horrorCompleted = false; 
    public float timeLeft;
    private float maxTime = 1200f;
    private bool isTimerRunning = true;
    public Animator doorAnimator;



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
            if(fantasyCompleted && horrorCompleted){
                OpenFinalDoor();
            }
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

    private void OpenFinalDoor(){
        doorAnimator.SetBool("OpenDoor", true);
    }

    private void Lose(){
        SceneManager.LoadScene("Lose Screen");
    }
}
