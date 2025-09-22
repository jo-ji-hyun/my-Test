using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<ItemDBs> Inventory;

    public void Start()
    {
        Inventory.Clear();

        WeightCheck();

        FieldItem.OnAcquired += WeightCheck;
    }

    public void WeightCheck()
    {
        GameManager.Instance.TotalWeight = 0;

        foreach (var item in SaveManager.Instance.UserData.items)
        {
            if (item.Flags == ItemFlags.isAcquired)
            {
                Inventory.Add(item);
                GameManager.Instance.TotalWeight += item.Width * item.Length;
            }
        }
    }
}
