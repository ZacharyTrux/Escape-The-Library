using UnityEngine;

public class HorrorRoom_DoorController : MonoBehaviour
{
    public bool isOpen = false;
    public float openHeight = 3f;
    public float speed = 2f;

    private Vector3 closedPos;
    private Vector3 openPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closedPos = transform.position;
        openPos = closedPos + Vector3.up * openHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
            transform.position = Vector3.Lerp(transform.position, openPos, Time.deltaTime * speed);
        else
            transform.position = Vector3.Lerp(transform.position, closedPos, Time.deltaTime * speed);
    }

    public void OpenDoor()
    {
        isOpen = true;
    }
}
