using UnityEngine;
using TMPro;

public class ItemCountDisplay : MonoBehaviour
{
    public TextMeshProUGUI itemCountText;

    void Update()
    {
        // Update the item count text with the total count of items in the inventory
        UpdateItemCount();
    }

    void UpdateItemCount()
    {
        int totalCount = 0;

        foreach (Item item in Inventory.instance.items)
        {
            totalCount += item.count;
        }

        // Update the UI text with the total count
        itemCountText.text = "Coins: " + totalCount.ToString();
    }
}