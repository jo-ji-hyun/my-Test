using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    public TextMeshProUGUI QuestName;
    public TextMeshProUGUI QuestDescription;
    public TextMeshProUGUI QuestRequst;

    private SaveManager _save;

    private void Start()
    {
        _save = SaveManager.Instance;

        DataCheck();

        DialogPanel.OnQuestStart += DataCheck;
    }

    private void DataCheck()
    {
        foreach (var quest in _save.QuestData.quests)
        {
            if (quest.Flags == QuestFlags.isAccept)
            {
                QuestName.text = quest.Name;
                QuestDescription.text = quest.Description;
                QuestRequst.text = Item_Find(quest.Request_Id);
            }
            else if(quest.Flags == QuestFlags.isClear)
            {
                QuestName.text = "";
                QuestDescription.text = "";
                QuestRequst.text = "";
            }
        }
    }

    private string Item_Find(int index)
    {
        foreach (var item in _save.UserData.items)
        {
            if (item.id == index)
            {
                return item.name;
            }
        }

        return "??";
    }
}
