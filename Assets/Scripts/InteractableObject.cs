using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string ItemName;
    public bool playerInRange;
    public int MaxStackSize;
    public InventoryItemData ItemData;
    public InventoryHolder PlayerInventory;
    public string GetItemName()
    {
        return ItemName;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && SelectionManager.Instance.cursorPointing)
        {
            Debug.Log("item  HERRO added  to  inventory: " + ItemName);

            PlayerInventory.InventorySystem.AddToInventory(ItemData, 1);
            Destroy(gameObject);            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            PlayerInventory = other.GetComponent<InventoryHolder>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            PlayerInventory = null;
        }
    }
}