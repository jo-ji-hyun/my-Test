using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDB 
{
    private readonly Dictionary<int, DialogDBs> _dialogs;

    public DialogDB(Dialog so)
    {
        _dialogs = new Dictionary<int, DialogDBs>();
        if (so != null && so.DialogSheet != null)
        {
            foreach (var dialog in so.DialogSheet)
            {
                if (dialog != null)
                {
                    _dialogs[dialog.Id] = dialog;
                }
            }
        }
    }

    public DialogDBs Get(int id)
    {
        _dialogs.TryGetValue(id, out DialogDBs data);

        return data;
    }
}
