using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject items;
    public GameObject itemSlot;
    public GameObject Npcs;

    public GameObject player;

    public int TotalWeight = 16;

    protected override bool IsDestroy => false;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        SetItem();

        SetNpc();
    }

    public void SetItem()
    {
        if (SaveManager.Instance.UserData.items != null )
        {
            for (int i = 0; i < SaveManager.Instance.UserData.items.Count; i++ )
            {
                // === flag�� 1�� �ƴҶ� �κ��丮�� �����===
                if (SaveManager.Instance.UserData.items[i].Flags != ItemFlags.None)
                {

                }
                // === flag�� 1�϶� ===
                else
                {
                    // === ������ ���� ===
                    ItemDBs item = SaveManager.Instance.UserData.items[i];

                    GameObject newitem = Instantiate(items);

                    FieldItem iteminfo = newitem.GetComponent<FieldItem>();

                    iteminfo.Id = item.id;

                    newitem.transform.position = new Vector3(item.PosX, item.PosY, 0);
                }

            }
        }
    }

    public void SetNpc()
    {
        if(SaveManager.Instance.UserData.npcs != null)
        {
            for(int i = 0; i < SaveManager.Instance.UserData.npcs.Count; i++)
            {
                if (SaveManager.Instance.UserData.npcs[i].Durability > 0)
                {
                    NpcDBs npcdata = SaveManager.Instance.UserData.npcs[i];

                    GameObject newNpc = Instantiate(Npcs);

                    // === id�� �Ѱ��� ===
                    Interaction Npcinfo = newNpc.GetComponent<Interaction>();

                    Npcinfo.id = npcdata.Id;

                    newNpc.transform.position = new Vector3(npcdata.PosX, npcdata.PosY, 0);
                }
            }
        }
    }

}
