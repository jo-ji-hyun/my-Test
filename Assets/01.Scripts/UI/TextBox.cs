using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    public int Number;
    public TextMeshProUGUI SpeakerName;
    public TextMeshProUGUI SpeakerText;

    private DialogDBs _data;

    private void Start()
    {
        _data = DataBase.Instance.DialogDB.Get(Number);

        if (_data.State == OptionState.isAccept)
        {
            string replaceText = _data.Text.Replace("{Quest_Name}", DataBase.Instance.QuestDB.Get(_data.Quest_Id).Name);
            replaceText = replaceText.Replace("{Quest_Goal}", DataBase.Instance.QuestDB.Get(_data.Quest_Id).Description);

            SpeakerText.text = replaceText;
            SpeakerName.text = DataBase.Instance.NpcDB.Get(_data.NPC_Id).Name;

        }
        else
        {
            SpeakerText.text = _data.Text;
            SpeakerName.text = DataBase.Instance.NpcDB.Get(_data.NPC_Id).Name;
        }
    }

}
