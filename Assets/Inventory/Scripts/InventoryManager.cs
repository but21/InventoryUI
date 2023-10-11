using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;

    public Inventory myBag;

    public GameObject slotGrid;

    // public Slot slotPrefab;
    public GameObject emptySlot;
    public Text itemInformation;

    public List<GameObject> slots = new List<GameObject>();

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    private void OnEnable()
    {
        RefreshItem();
        _instance.itemInformation.text = "";
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        _instance.itemInformation.text = itemDescription;
    }

    /*public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(_instance.slotPrefab, _instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(_instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }*/

    public static void RefreshItem()
    {
        for (int i = 0; i < _instance.slotGrid.transform.childCount; i++)
        {
            if (_instance.slotGrid.transform.childCount == 0)
            {
                break;
            }

            Destroy(_instance.slotGrid.transform.GetChild(i).gameObject);
            _instance.slots.Clear();
        }

        for (int i = 0; i < _instance.myBag.itemList.Count; i++)
        {
            // CreateNewItem(t);
            _instance.slots.Add(Instantiate(_instance.emptySlot));
            _instance.slots[i].transform.SetParent(_instance.slotGrid.transform);
            _instance.slots[i].GetComponent<Slot>().slotID = i;
            _instance.slots[i].GetComponent<Slot>().SetupSlot(_instance.myBag.itemList[i]);
        }
    }
}