using UnityEngine;
using UnityEngine.SceneManagement;

public class BookDimensionScript : MonoBehaviour{
    public string targetScene;
    public int targetSpawnPointID;

    public void OnInteract(){
        SceneManager.LoadScene(targetScene);
    }
}
