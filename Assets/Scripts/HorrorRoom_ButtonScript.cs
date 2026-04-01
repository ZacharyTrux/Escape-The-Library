using UnityEngine;

public class HorrorRoom_ButtonScript : MonoBehaviour
{
    public int buttonID;
    public HorrorRoom_PuzzleManager puzzleManager;

    private void OnMouseDown()
    {
        puzzleManager.PressButton(ID)
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
