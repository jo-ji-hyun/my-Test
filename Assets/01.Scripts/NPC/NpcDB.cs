using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDB 
{
    private readonly Dictionary<int, NpcDBs> _npcs;

    public NpcDB(Npcs so)
    {
        _npcs = new Dictionary<int, NpcDBs>();
        if (so != null && so.NpcSheet != null)
        {
            foreach (var npc in so.NpcSheet)
            {
                if (npc != null)
                {
                    _npcs[npc.Id] = npc;
                }
            }
        }
    }

    public NpcDBs Get(int id)
    {
        _npcs.TryGetValue(id, out NpcDBs data);

        return data;
    }
}
