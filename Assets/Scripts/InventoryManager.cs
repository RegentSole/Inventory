using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    // Список всех возможных предметов
    public List<InventoryItem> allItems;
    
    // UI элементы
    public Transform inventoryGrid;
    public GameObject prefabSlot;
    public TMP_Text itemCostText;
    public TMP_Text itemSpecialValueText;
    public TMP_Text itemNameText;
    public TMP_Text itemTypeText;
    public Image itemIconImage;

    private void Start()
    {
        ClearPanel();
    }

    // Метод для генерации случайного предмета
    public void SpawnRandomItem()
    {
        if (inventoryGrid.childCount >= 10) // Ограничение на количество предметов
            return;
        
        // Проверяем, что список не пуст
        if (allItems == null || allItems.Count == 0)
        {
            Debug.LogError("Список предметов пуст!");
            return;
        }
        
        // Выбираем случайный предмет
        var randomIndex = Random.Range(0, allItems.Count);
        var selectedItem = allItems[randomIndex];
        
        // Создаём слот в инвентаре
        if (prefabSlot != null && inventoryGrid != null)
        {
            var newSlot = Instantiate(prefabSlot, inventoryGrid);
            var slotScript = newSlot.GetComponent<Slot>();
            if (slotScript != null)
            {
                slotScript.SetItem(selectedItem);
            }
            else
            {
                Debug.LogError("Компонент Slot не найден в префабе слота.");
            }
        }
        else
        {
            Debug.LogError("Prefabslot или inventoryGrid не были найдены.");
        }
    }

    // Обновление панели информации
    public void UpdateInfoPanel(InventoryItem item)
    {
        if (item == null)
        {
            ClearPanel(); // Очищаем панель, если предмет не выбран
            return;
        }

        itemCostText.text = $"Стоимость: {item.cost}";
        itemNameText.text = item.itemName;
        itemTypeText.text = item.GetType().ToString();

        if (item is Weapon weapon)
        {
            itemSpecialValueText.text = $"Урон: {weapon.damage}";
        }
        else if (item is Armor armor)
        {
            itemSpecialValueText.text = $"Защита: {armor.defense}";
        }
        else if (item is Consumable consumable)
        {
            itemSpecialValueText.text = $"Восстановление здоровья: {consumable.healthRestore}";
        }
        else if (item is Material material)
        {
            itemSpecialValueText.text = $"Прочность: {material.durability}";
        }

        itemIconImage.sprite = item.icon;
    }

    // Очистка панели информации
    public void ClearPanel()
    {
        itemCostText.text = "";
        itemSpecialValueText.text = "";
        itemNameText.text = "";
        itemTypeText.text = "";
        itemIconImage.sprite = null;
    }
}