using UnityEngine;
using UnityEngine.Events;

public class InventoryHolder : MonoBehaviour
{
    [SerializeField] public int inventorySize;
    [SerializeField] protected InventorySystem inventorySystem;

    public InventorySystem InventorySystem => inventorySystem;
    public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;
    
    [SerializeField] private NotificationUI notificationUI;

    private void Awake()
    {
        Debug.Log($"[InventoryHolder Awake] on: {gameObject.name}  id={gameObject.GetInstanceID()}");
        inventorySystem = new InventorySystem(inventorySize);
        if (notificationUI == null)
    {
        var all = Resources.FindObjectsOfTypeAll<NotificationUI>();
        if (all != null && all.Length > 0)
            notificationUI = all[0];
    }
    }

    public bool TryAddToInventory(InventoryItemData item, int amount)
    {
        bool added = inventorySystem.AddToInventory(item, amount);

        if (!added)
        {
        if (notificationUI != null)
            notificationUI.Show("Can not pick up item! Inventory full");
    }
        else
        {
            notificationUI.Show($"Item added: {item.DisplayName}");
        }
            

        return added;
    }
}

