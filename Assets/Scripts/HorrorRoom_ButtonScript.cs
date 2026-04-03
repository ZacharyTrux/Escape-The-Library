using UnityEngine;

public class HorrorRoom_ButtonScript : MonoBehaviour
{
    public int buttonID;
    public HorrorRoom_PuzzleManager puzzleManager;

    private Renderer rend;

    public Color idleColor = Color.blue;
    public Color correctColor = Color.green;
    public Color wrongColor = Color.red;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = idleColor;
    }
    void OnMouseDown()
    {
        puzzleManager.PressButton(buttonID, this);
        transform.localScale *= 0.9f;
    }

    public void SetCorrect()
    {
        rend.material.color = correctColor;
    }

    public void SetWrong()
    {
        rend.material.color = wrongColor;
    }

    public void ResetColor()
    {
        rend.material.color = idleColor;
    }

}

