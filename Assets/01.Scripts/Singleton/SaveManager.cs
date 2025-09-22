using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    public UserData UserData;
    public QuestData QuestData;
    protected override bool IsDestroy => false;

    private string _filePath;
    private string _questFilePath;

    protected override void Awake()
    {
        base.Awake();

        _filePath = Path.Combine(Application.persistentDataPath, "TestData.json");
        _questFilePath = Path.Combine(Application.persistentDataPath, "QuestData.json");

        LoadData();

        LoadQuestData();
    }

    public void LoadData()
    {
        // === 파일 존재시 ===
        if (File.Exists(_filePath))
        {
            var loadData = File.ReadAllText(_filePath);

            UserData = JsonUtility.FromJson<UserData>(loadData);
        }
        else // === 없으면 새로만듬 ===
        {
            UserData = new UserData
            {
                items = DataBase.Instance.itemSO.Itemsheet,
                npcs = DataBase.Instance.npcSO.NpcSheet,
                dialogList = DataBase.Instance.dialogSO.DialogSheet,
                logList = new List<int> { }
            };

            string json = JsonUtility.ToJson(UserData);

            File.WriteAllText(_filePath, json);

            SaveData(UserData);
        }
    }

    // === 분리하는법 공부를 위해 억지로 분리함(나중엔 합쳐서 쓰기)===
    public void LoadQuestData()
    {
        // === 파일 존재시 ===
        if (File.Exists(_questFilePath))
        {
            var loadData = File.ReadAllText(_questFilePath);

            QuestData = JsonUtility.FromJson<QuestData>(loadData);
        }
        else // === 없으면 새로만듬 ===
        {
            QuestData = new QuestData
            {
                quests = DataBase.Instance.questSO.QuestSheet
            };

            string json = JsonUtility.ToJson(QuestData);

            File.WriteAllText(_questFilePath, json);

            SaveQuestData(QuestData);
        }
    }

    public void SaveData(UserData data)
    {
        var saveData = JsonUtility.ToJson(data);

        File.WriteAllText(_filePath, saveData);
    }

    public void SaveQuestData(QuestData data)
    {
        var saveData = JsonUtility.ToJson(data);

        File.WriteAllText(_questFilePath, saveData);
    }
}
