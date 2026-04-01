using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagement : MonoBehaviour
{
    // set this in inspector
    public List<InventorySlot> slots; // this should be changed!!
    private int invIndex;
    private bool inInventoryMenu;
    [SerializeField] private GameObject inventoryMenu;

    public Image img;
    public static InventoryManagement Instance { get; private set; }
    private InputSystem_Actions input;

    private void Awake() {
    Instance = this;
        input = new();
        input.Enable();
        input.UI.Enable();
    }

    private void Start()
    {
        inInventoryMenu = false;
    }

    private void Update() {
        if (input.UI.UseInventoryItem.WasPressedThisFrame()) {
            UseItem();
        }
    }

    public void Add()
    {
        invIndex = slots.Count;
    }

    void OnCycleItem()
    {
        invIndex++;
        invIndex %= slots.Count;
    }

    private void UseItem() {
        slots[invIndex].item.Use();
    }

    private void OnOpenInventory()
    {
        if (!inInventoryMenu) {
            inInventoryMenu = true;
            inventoryMenu.SetActive(true);
        }
    }

    // public bool Add(InventoryItem item) {
    //     for (int i = 0; i < slots.Count; i++) {
    //         if (slots[i].item == null) {
    //             slots[i].item = item;
    //             slots[i].img.gameObject.SetActive(true);
    //             slots[i].img.sprite = item.sprHud;
    //             return true;
    //         }
    //     }
    //     return false;
    // }
}