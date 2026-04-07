using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour{
    public Object scene;

    public void Interact(){
        SceneManager.LoadScene(scene.name);
    }
}
