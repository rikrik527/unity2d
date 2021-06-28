using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "so_itemList", menuName = "fucking shit/item/shitList")]
public class So_itemList : ScriptableObject
{
    [SerializeField]
    public List<ItemDetails> itemDetails;
}
