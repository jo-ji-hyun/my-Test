using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserData
{ 
    public List<ItemDBs> items;
    public List<NpcDBs> npcs;
    public List<DialogDBs> dialogList;
    public List<int> logList;
}

[Serializable]
public class QuestData
{
    public List<QuestDBs> quests;
}