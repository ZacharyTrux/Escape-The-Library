using UnityEngine;

public class Lever : MonoBehaviour
{
    [Header("Lever Settings")]
    public int leverID;
    public float rotationAngle = 90f;
    public float speed = 5f;

    [Header("References")]
    public HorrorRoom_PuzzleManager puzzleManager;

    private bool isActivated = false;

    private Quaternion offRotation;
    private Quaternion onRotation;

    private AudioSource audioSource;

    void Start()
    {
        // Store starting rotation
        offRotation = transform.localRotation;

        // Change axis if needed
        onRotation = offRotation * Quaternion.Euler(rotationAngle, 0f, 0f);

        // Reset lever state and position
        ResetLever();
    }

    void Update()
    {
        Quaternion target = isActivated ? onRotation : offRotation;
        transform.localRotation = Quaternion.Lerp(transform.localRotation, target, Time.deltaTime * speed);
    }

    public void Interact()
    {
        if (isActivated) return;

        isActivated = true;

        // Notify puzzle manager
        if (puzzleManager != null)
        {
            puzzleManager.LeverPulled(leverID);
        }
        else
        {
            Debug.LogWarning("PuzzleManager not assigned!");
        }
    }

    public void ResetLever()
    {   
        // Reset lever state
        isActivated = false;

        // Reset lever rotation 
        transform.localRotation = offRotation;
    }
}