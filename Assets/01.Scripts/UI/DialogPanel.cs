using System;
using TMPro;
using UnityEngine;

public class DialogPanel : MonoBehaviour
{
    public static event Action OnQuestStart;

    public TextMeshProUGUI Speaker;
    public TextMeshProUGUI Text;
    public GameObject SuccessBtn;
    public TextMeshProUGUI SuccessTxt;
    public TextMeshProUGUI RejectTxt;
    [Header("Recall")]
    public GameObject RecallTextBox;

    private DataBase _data;
    private QuestDBs _quests;
    private ItemDBs _request;
    private int _index_Id;

    public void Start()
    {
        _data = DataBase.Instance;

        gameObject.SetActive(false);
        RecallTextBox.SetActive(false);
    }

    private void OnEnable()
    {
        Interaction.OnStartDialogued += Display_Data;
    }

    private void OnDisable()
    {
        Interaction.OnStartDialogued -= Display_Data;
    }


    public void Display_Data(int index)
    {
        _index_Id = index;
        
        if(!SaveManager.Instance.UserData.logList.Contains(_index_Id))
        {
            SaveManager.Instance.UserData.logList.Add(_index_Id);
        }

        foreach (var quest in SaveManager.Instance.QuestData.quests)
        {
            if (quest.Id == _index_Id)
            {
                _quests = quest;
            }
        }

        foreach (var item in SaveManager.Instance.UserData.items)
        {
            if (item.id == _quests.Request_Id)
            {
                _request = item;
            }
        }

        // === 퀘스트 클리어 확인 ===
        if (_quests.Flags.HasFlag(QuestFlags.isClear))
        {
            _index_Id = _data.DialogDB.Get(_index_Id).Clear_Id;

            var dialogdata = _data.DialogDB.Get(_index_Id);

            Speaker.text = _data.NpcDB.Get(dialogdata.NPC_Id).Name;
            Text.text = dialogdata.Text;
            SuccessBtn.SetActive(false);
            RejectTxt.text = dialogdata.Choice2;
        }
        else if (_request.Flags == ItemFlags.isAcquired)
        {
            _index_Id = _data.DialogDB.Get(_index_Id).Clear_Id;

            _quests.Flags = QuestFlags.isClear;
            _request.Flags = ItemFlags.isBroken;

            var dialogdata = _data.DialogDB.Get(_index_Id);

            Speaker.text = _data.NpcDB.Get(dialogdata.NPC_Id).Name;
            Text.text = dialogdata.Text;
            SuccessBtn.SetActive(false);
            RejectTxt.text = dialogdata.Choice2;
        }
        else if (_quests.Flags.HasFlag(QuestFlags.isAccept))
        {
            _index_Id = _data.DialogDB.Get(_index_Id).Choice1_Next_Id;

            Display_Change(_index_Id);

            SuccessBtn.SetActive(false);
        }
        else
        {
            Display_Change(_index_Id);
        }
    }

    // === 텍스트 변경 ===
    public void Display_Change(int index)
    {
        var dialogdata = _data.DialogDB.Get(index);

        SuccessBtn.SetActive(true);

        Speaker.text = _data.NpcDB.Get(dialogdata.NPC_Id).Name;

        if (dialogdata.State.HasFlag(OptionState.isAccept))
        {
            Text.text = Replace_Text(dialogdata.Text);
        }
        else
        {
            Text.text = dialogdata.Text;
        }

        if (dialogdata.State.HasFlag(OptionState.isReject))
        {
            SuccessBtn.SetActive(false);
        }
        else
        {
            SuccessTxt.text = dialogdata.Choice1;
        }

        RejectTxt.text = dialogdata.Choice2;
    }

    // === 퀘스트 내용 들고오기 ===
    public string Replace_Text(string originalText)
    {
        var questData = _data.QuestDB.Get(_data.DialogDB.Get(_index_Id).Quest_Id);

        string replaceText = originalText.Replace("{Quest_Name}", questData.Name);
        replaceText = replaceText.Replace("{Quest_Goal}", questData.Description);

        return replaceText;
    }

    // === 첫번째 버튼 ===
    public void OnSuccessChoice()
    {
        var dialogdata = _data.DialogDB.Get(_index_Id);

        int nextID = dialogdata.Choice1_Next_Id;

        if (nextID != 0)
        {
            Display_Data(nextID);
        }
        else
        {
            foreach (var quest in SaveManager.Instance.QuestData.quests)
            {
                if (quest.Id == _index_Id)
                {
                    _quests = quest;
                }
            }

            _quests.Flags = QuestFlags.isAccept;
            OnQuestStart?.Invoke();
            gameObject.SetActive(false);
        }
    }

    // === 두번째 버튼 ===
    public void OnRejectChoice()
    {
        var dialogdata = _data.DialogDB.Get(_index_Id);

        int nextID = dialogdata.Choice2_Next_Id;

        if (nextID != 0)
        {
            Display_Data(nextID);
        }
        else
        {
            OnQuestStart?.Invoke();
            gameObject.SetActive(false);
        }
    }

    // === 대화 로그 ===
    public void OnRecallText()
    {
        RecallTextBox.SetActive(true);
    }
}
