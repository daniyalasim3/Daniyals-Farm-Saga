using UnityEngine;



[CreateAssetMenu(menuName = "Inventory System/Inventory Item")]
public class InventoryItemData: ScriptableObject
{
    public string DisplayName;
    public Sprite icon;
    public int MaxStackSize;
}
