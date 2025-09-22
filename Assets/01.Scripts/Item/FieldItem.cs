using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    public static event Action OnAcquired;

    public int Id;
    private bool _playerInRange = false;

    private void OnTriggerEnter2D()
    {
        _playerInRange = true;
    }

    private void OnTriggerExit2D()
    { 
        _playerInRange = false;
    }

    private void Update()
    {
        if (_playerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach(var item in SaveManager.Instance.UserData.items)
                {
                    if (item.id == Id && GameManager.Instance.TotalWeight + (item.Width * item.Length) <= 16)
                    {
                        item.Flags = ItemFlags.isAcquired;
                        Destroy(gameObject);

                        OnAcquired?.Invoke();
                    }
                }
            }
        }
    }
}
