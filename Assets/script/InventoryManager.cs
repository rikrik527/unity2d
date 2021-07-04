using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonPlayer<InventoryManager>
{
    private Dictionary<int, ItemDetails> itemDetailsDictionary;

    public List<InventoryItem>[] inventoryLists;

    [HideInInspector] public int[] inventoryListCapacityIntArray; // the index of the array is the inventory list (from the InventoryLocation enum), and the value is the capacity of that inventory list

    [SerializeField] private So_itemList itemList = null;
    protected override void Awake()
    {


        base.Awake();
        // Create Inventory Lists
        CreateInventoryLists();

        CreateItemDetailsDictionary();
    }
    private void CreateInventoryLists()
    {
        inventoryLists = new List<InventoryItem>[(int)InventoryLocation.count];

        for (int i = 0; i < (int)InventoryLocation.count; i++)
        {
            Debug.Log("inventorylists" + inventoryLists[i]);
            inventoryLists[i] = new List<InventoryItem>();
        }

        // initialise inventory list capacity array
        inventoryListCapacityIntArray = new int[(int)InventoryLocation.count];

        // initialise player inventory list capacity
        inventoryListCapacityIntArray[(int)InventoryLocation.player] = SettingsStats.playerInitialInventoryCapacity;
    }
    /// <summary>
    /// Add an item to the inventory list for the inventoryLocation
    /// </summary>
    //public void AddItem(InventoryLocation inventoryLocation, Item item)
    //{
    //    int itemCode = item.ItemCode;
    //    List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];

    //    // Check if inventory already contains the item
    //    int itemPosition = FindItemInInventory(inventoryLocation, itemCode);

    //    if (itemPosition != -1)
    //    {
    //        AddItemAtPosition(inventoryList, itemCode, itemPosition);
    //    }
    //    else
    //    {
    //        AddItemAtPosition(inventoryList, itemCode);
    //    }

    //    //  Send event that inventory has been updated
    //    EventHandle.CallInventoryUpdatedEvent(inventoryLocation, inventoryLists[(int)inventoryLocation]);
    //}

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
