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
            Debug.Log("Attempting to add item to inventory: " + ItemName);
            if(PlayerInventory.InventorySystem.AddToInventory(ItemData, 1))
            {    
                Destroy(gameObject); 
            }
            else
            {
                Debug.Log("Couldn't add object to inventory: " + ItemName);
            }
                       
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