using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public Image icon;
    public TMP_Text itemName;
    public TMP_Text itemCost;
    public TMP_Text itemStats;
    public TMP_Text itemClass;

    //private InventoryItem currentItem;


    public void SetItem(InventoryItem item)
    {
        icon.sprite = item.icon;
        itemName.text = item.itemName;
        itemCost.text = $"Стоимость: {item.cost}";
        itemStats.text = $"{item.classofitem}";
        itemClass.text = $"{item.stats}";
   }

   /*// Метод для проверки, занят ли слот
    public bool IsOccupied()
    {
        return currentItem != null; // Предполагаем, что currentItem хранит ссылку на предмет в слоте
    }

    // Метод для установки слоту пустого состояния
    public void SetEmpty()
    {
        currentItem = null; // Сбрасываем ссылку на предмет
    }*/
}