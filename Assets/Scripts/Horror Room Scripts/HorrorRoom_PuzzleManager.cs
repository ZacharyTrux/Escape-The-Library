using UnityEngine;

public enum PuzzleState { Waiting, InProgress, Completed }

public class HorrorRoom_PuzzleManager : MonoBehaviour
{
    [Header("Puzzle Settings")]
    public int[] correctOrder = { 1, 2, 3 };

    [Header("References")]
    public GameObject exitPortal;
    public Lever[] levers;

    private int currentIndex = 0;
    private PuzzleState state = PuzzleState.Waiting;

    void Start()
    {
        state = PuzzleState.Waiting;
        currentIndex = 0;

        // Reset all levers
        foreach (var lever in levers)
            lever.ResetLever();

        // Make portal invisible
        if (exitPortal != null)
            exitPortal.SetActive(false);
    }

    public void LeverPulled(int leverID)
    {
        if (state == PuzzleState.Completed)
            return;

        // Check if lever matches expected in sequence
        if (leverID == correctOrder[currentIndex])
        {
            currentIndex++;
            state = PuzzleState.InProgress;

            // Sequence complete
            if (currentIndex >= correctOrder.Length)
            {
                state = PuzzleState.Completed;
                ActivatePortal();
            }
        }
        else
        {
            // Wrong lever: reset everything
            ResetPuzzle();
        }
    }

    void ActivatePortal()
    {
        if (exitPortal != null){
            exitPortal.SetActive(true);
        }
        Debug.Log("Puzzle completed! Portal activated.");
    }

    void ResetPuzzle()
    {
        Debug.Log("Wrong order! Resetting puzzle...");

        currentIndex = 0;
        state = PuzzleState.Waiting;

        // Reset lever positions
        foreach (var lever in levers)
        {
            lever.ResetLever();
        }
    }
}