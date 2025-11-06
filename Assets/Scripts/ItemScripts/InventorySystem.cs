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
        if (inventorySlots[0].ItemData == null)
        {
            Debug.Log("REEHEEHEEHEE" + item.DisplayName);
            inventorySlots[0] = new InventorySlot(item, 1);
        }
        else
        {
            Debug.Log("yresd daddy");
            inventorySlots[0].stackSize++;
        }        return true;
    }

}
