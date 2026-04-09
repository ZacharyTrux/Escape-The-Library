using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

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

    void Start(){
        Cursor.lockState = CursorLockMode.Locked; // Locks cursor to the center of the screen
        Cursor.visible = false; // Hides the cursor
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
        if(SceneManager.GetActiveScene().name == "Win Screen" || SceneManager.GetActiveScene().name == "Lose Screen"){
            isTimerRunning = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        HandleDebug();
    }

    private void HandleDebug(){
        if(Keyboard.current.digit7Key.wasPressedThisFrame){
            fantasyCompleted = true;
            Debug.Log("Fantasy world marked as completed.");
        }
        if(Keyboard.current.digit8Key.wasPressedThisFrame){
            horrorCompleted = true;
            Debug.Log("Horror world marked as completed.");
        }
        if(Keyboard.current.digit9Key.wasPressedThisFrame){
            timeLeft = 10f;
            Debug.Log("Timer set to 10 seconds.");
        }
    }

    private void Lose(){
        SoundManager.StopAllMusic();
        SceneManager.LoadScene("Lose Screen");
    }
}
