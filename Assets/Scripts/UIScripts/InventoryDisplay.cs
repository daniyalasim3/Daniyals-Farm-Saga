using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseInventoryItem;
    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary;
    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlot_UI, InventorySlot> SlotDictionary => slotDictionary;
    public abstract void AssignSlot(InventorySystem invToDisplay);

    public InventoryDisplay ParentDisplay { get; private set; }
    
    protected virtual void Start()
    {
        
    }
    protected virtual void UpdateSlot(InventorySlot updatedSlot)
    {
        foreach (var slot in SlotDictionary)
        {
            if(slot.Value == updatedSlot)
            {
                slot.Key.UpdateUISlot(updatedSlot);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
}
