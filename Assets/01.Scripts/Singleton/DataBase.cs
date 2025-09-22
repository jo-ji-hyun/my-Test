using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : Singleton<DataBase>
{
    public Item itemSO;
    public Quests questSO;
    public Npcs npcSO;
    public Dialog dialogSO;

    // === �ܺο��� ������ �� �ִ� �����ͺ��̽� �ν��Ͻ� ===
    public ItemDB ItemDB { get; private set; }
    public QuestDB QuestDB { get; private set; }
    public NpcDB NpcDB { get; private set; }
    public DialogDB DialogDB { get; private set; }

    protected override bool IsDestroy => false;

    protected override void Awake()
    {
        base.Awake();

        ItemDB = new ItemDB(Instantiate(itemSO));
        QuestDB = new QuestDB(Instantiate(questSO));
        NpcDB = new NpcDB(Instantiate(npcSO));
        DialogDB = new DialogDB(Instantiate(dialogSO));
    }
}
