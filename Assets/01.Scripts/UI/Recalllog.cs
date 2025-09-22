using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Recalllog : MonoBehaviour 
{
    public GameObject TextBox;

    private void OnEnable()
    {
        foreach(var index in SaveManager.Instance.UserData.logList)
        {
            GameObject newBox = Instantiate(TextBox, this.transform);

            TextBox textbox = newBox.GetComponent<TextBox>();
            textbox.Number = index;
        }

    }

    private void OnDisable()
    {
        
    }
}
