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
                // === flag가 1이 아닐때 인벤토리에 띄워줌===
                if (SaveManager.Instance.UserData.items[i].Flags != ItemFlags.None)
                {

                }
                // === flag가 1일때 ===
                else
                {
                    // === 아이템 생성 ===
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

                    // === id를 넘겨줌 ===
                    Interaction Npcinfo = newNpc.GetComponent<Interaction>();

                    Npcinfo.id = npcdata.Id;

                    newNpc.transform.position = new Vector3(npcdata.PosX, npcdata.PosY, 0);
                }
            }
        }
    }

}
