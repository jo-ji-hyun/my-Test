using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum QuestFlags
{
    None = 0,          // 0000
    isAccept= 1 << 0,  // 0001
    isClear = 1 << 1,  // 0010 
}

[Serializable]
public class QuestDBs
{
    public int Id;
    public string Name;
    public string Description;
    public QuestFlags Flags;
    public int Request_Id;
}
