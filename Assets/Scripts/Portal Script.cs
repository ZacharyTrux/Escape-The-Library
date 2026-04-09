using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour{
    public Object scene;
    public bool isCompletionPortal = false;

    public void Interact(){
        if(isCompletionPortal){
            UpdateGameManager();
        }

        if(SoundManager.Instance != null){
            SoundManager.StopAllMusic();
            SoundManager.Play(SoundType.PORTAL);
        }
        SceneManager.LoadScene(scene.name);
    }

    private void UpdateGameManager(){
        string currSceneName = SceneManager.GetActiveScene().name;
        if(currSceneName == "Fantasy World"){
            GameManager.Instance.fantasyCompleted = true;
        }
        else{
            GameManager.Instance.horrorCompleted = true;
        }
    }

   
}

