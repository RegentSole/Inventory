using UnityEngine;

public abstract class InventoryItem : ScriptableObject
{
    public Sprite icon;
    public string itemName;
    public int cost;
    public string classofitem;
    public string stats;
}

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class Weapon : InventoryItem
{
    public int damage;
}

[CreateAssetMenu(fileName = "New Armor", menuName = "Inventory/Armor")]
public class Armor : InventoryItem
{
    public int defense;
}

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : InventoryItem
{
    public int healthRestore;
}

[CreateAssetMenu(fileName = "New Material", menuName = "Inventory/Material")]
public class Material : InventoryItem
{
    public int durability;
}/**/