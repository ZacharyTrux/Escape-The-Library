using UnityEngine;

public class HorrorRoom_PuzzleManager : MonoBehaviour
{   
    public enum PuzzleState
    {
        Idle,
        Step1,
        Step2,
        Solved,
        Failed
    }

    public PuzzleState currentState = PuzzleState.Idle;
    public HorrorRoom_DoorController door;

    public HorrorRoom_ButtonScript[] buttons;

    public void PressButton(int buttonID, HorrorRoom_ButtonScript button)
    {
        switch (currentState)
        {
            case PuzzleState.Idle:
                if (buttonID == 1)
                {
                    currentState = PuzzleState.Step1;
                    button.SetCorrect();
                }
                else
                    Fail(button);
                break;

            case PuzzleState.Step1:
                if (buttonID == 2)
                {
                    currentState = PuzzleState.Step2;
                    button.SetCorrect();
                }
                else
                    Fail(button);
                break;

            case PuzzleState.Step2:
                if (buttonID == 3)
                {
                    button.SetCorrect();
                    Solve();
                }
                    
                else
                    Fail(button);
                break;
        }
    }

    void Solve()
    {
        currentState = PuzzleState.Solved;
        if (door != null) door.OpenDoor();
        Debug.Log("Puzzle Solved!");
    }

    void Fail(HorrorRoom_ButtonScript wrongButton)
    {
        currentState = PuzzleState.Failed;

        if (wrongButton != null) wrongButton.SetWrong();

        Debug.Log("Wrong order! Resetting...");
        Invoke(nameof(ResetPuzzle), 2f);
    }

    void ResetPuzzle()
    {
        currentState = PuzzleState.Idle;

        foreach (var b in buttons)
        {
            b.ResetColor();
        }
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
