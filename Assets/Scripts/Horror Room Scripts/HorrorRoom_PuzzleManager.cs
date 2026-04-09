using UnityEngine;

public class HorrorRoom_PuzzleManager : MonoBehaviour
{
    [Header("Puzzle Settings")]
    public int[] correctOrder = { 2, 1, 3 };

    private int currentIndex = 0;

    [Header("References")]
    public GameObject ExitPortal;
    public Lever[] levers;

    void Start()
    {
        // Ensure portal starts hidden
        if (ExitPortal != null)
        {
            ExitPortal.SetActive(false);
        }
    }

    public void LeverPulled(int id)
    {
        if (id == correctOrder[currentIndex])
        {
            currentIndex++;

            if (currentIndex >= correctOrder.Length)
            {
                ActivatePortal();
            }
        }
        else
        {
            ResetPuzzle();
        }
    }

    void ActivatePortal()
    {
        Debug.Log("Correct sequence!");

        if (ExitPortal != null)
        {
            ExitPortal.SetActive(true);
        }
    }

    void ResetPuzzle()
    {
        Debug.Log("Wrong order!");

        currentIndex = 0;

        foreach (Lever lever in levers)
        {
            lever.ResetLever();
        }
    }
}