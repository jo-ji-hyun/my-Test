using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDB 
{
    private readonly Dictionary<int, QuestDBs> _quests;

    public QuestDB(Quests so)
    {
        _quests = new Dictionary<int, QuestDBs>();
        if (so != null && so.QuestSheet != null)
        {
            foreach (var item in so.QuestSheet)
            {
                if (item != null)
                {
                    _quests[item.Id] = item;
                }
            }
        }
    }

    public QuestDBs Get(int id)
    {
        _quests.TryGetValue(id, out QuestDBs data);

        return data;
    }
}
