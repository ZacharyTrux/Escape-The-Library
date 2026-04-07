using UnityEngine;
using UnityEngine.UI;

public class CustomCursor : MonoBehaviour {
  public Sprite sprHover;
  public Color clrHover;

  private InputSystem_Actions input;
  private Sprite sprDefault;
  private Color clrDefault;
  private Image img;

  private void Awake() {
    img = GetComponent<Image>();
    sprDefault = img.sprite;
    clrDefault = img.color;
    input = new();
    input.Enable();
    input.UI.Enable();
  }

  private void Update() {
    img.sprite = sprDefault;
    img.color = clrDefault;

    var ray = Camera.main.ScreenPointToRay(transform.position);
    if (Physics.Raycast(ray, out RaycastHit hit, 100)) {

      if (hit.collider.CompareTag("Interactable") || hit.collider.CompareTag("Grabbable")) {
        img.sprite = sprHover;
        img.color = clrHover;
      }

      if(input.UI.Click.WasPressedThisFrame()){
        if(hit.collider.CompareTag("Interactable")){
          hit.collider.gameObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
        }
        else if(hit.collider.CompareTag("Grabbable")){
          hit.collider.gameObject.SendMessage("Grab", SendMessageOptions.DontRequireReceiver);
        }
      }
    }
  }
}
