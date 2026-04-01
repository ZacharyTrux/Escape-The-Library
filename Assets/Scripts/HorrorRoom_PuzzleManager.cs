using Tripolygon.UModelerX.Runtime;
using Unity.VisualScripting.Antlr3.Runtime;
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

    public void PressButton(int buttonID)
    {
        switch (currentState)
        {
            case PuzzleState.Idle:
                if (buttonID == 1)
                {
                    currentState = PuzzleState.Step1;
                }
                else
                    Fail();
                break;

            case PuzzleState.Step1:
                if (buttonID == 2)
                {
                    currentState = PuzzleState.Step1;
                }
                else
                    Fail();
                break;

            case PuzzleState.Step2:
                if (buttonID == 3)
                    Solve();
                else
                    Fail();
                break;
        }
    }

    void Solve()
    {
        currentState = PuzzleState.Solved;
        door.OpenDoor();
        Debug.Log("Puzzle Solved!");
    }

    void Fail()
    {
        currentState = PuzzleState.Failed;
        Debug.Log("Wrong order! Resetting...");
        Invoke(nameof(ResetPuzzle), 2f);
    }

    void ResetPuzzle()
    {
        currentState = PuzzleState.Idle;
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
