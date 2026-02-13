using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventorySystem
{
    [SerializeField] private List<InventorySlot> inventorySlots;

    public List<InventorySlot> InventorySlots => inventorySlots;

    public int InventorySize => InventorySlots.Count;

    public UnityAction<InventorySlot> OnInventorySlotChanged;
    public UnityAction<string> OnError;
    [SerializeField] private NotificationUI notification;
    public InventorySystem(int size)
    {
        inventorySlots = new List<InventorySlot>(size);

        for (int i = 0; i < size; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

   public bool AddToInventory(InventoryItemData item, int amount)
    {
    if (item == null) return false;

    Debug.Log($"Adding item: {item.name}");
    var slot = new InventorySlot();

    if(ContainsItem(item, out slot))
        {
            Debug.Log("Item ALREADY EXISTS!");
            slot.AddToStack(amount);                 // ✅ mutate existing slot
        }
        else
        {
            if(FindEmpty(item, out slot))
            {
                slot.UpdateInventorySlot(item, amount);
            }
            else
            {
                Debug.Log("cant find empty or contains slot");
                OnError?.Invoke("Inventory Full");
                return false; 
            }
        }
    OnInventorySlotChanged?.Invoke(slot);        // ✅ tell UI
    return true;
    ;}
    
    public bool ContainsItem(InventoryItemData  itemToAdd, out InventorySlot invSlot)
    {
        Debug.Log("Searching for item");
        foreach (var slot in inventorySlots)
    {
        if (slot.ItemData == itemToAdd)
        {
            Debug.Log($"Item found");
            invSlot = slot;
            return true;
        }
    }
    invSlot = null;
    return false;
    }


    public bool FindEmpty(InventoryItemData itemToAdd, out InventorySlot invSlot)
    {
        Debug.Log("Searching for Empty Slot");

        foreach (var slot in inventorySlots)
        {
            if(slot.ItemData ==null)
            {
                invSlot = slot;
                return true;
            }
        }

    invSlot = null;
    return false;
    }
    

}
