using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonPlayer<InventoryManager>
{
    private Dictionary<int, ItemDetails> itemDetailsDictionary;
    [SerializeField] private So_itemList itemList = null;

    private void Start()
    {
        CreateItemDetailsDictionary();
    }
    private void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();
        foreach (ItemDetails itemDetails in itemList.itemDetails)
        {

            itemDetailsDictionary.Add(itemDetails.itemCode, itemDetails);

        }

    }
    public ItemDetails GetItemDetails(int itemCode)
    {

        ItemDetails itemDetails;
        if (itemDetailsDictionary.TryGetValue(itemCode, out itemDetails))
        {
            Debug.Log("itemcode" + itemCode);
            Debug.Log("ItemDetails" + itemDetails);
            return itemDetails;
        }
        else
        {
            return null;
        }
    }
}
