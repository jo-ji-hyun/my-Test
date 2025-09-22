using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public int id;

    public Image image;
    public TextMeshProUGUI nametext;
    public TextMeshProUGUI descriptiontext;
    public TextMeshProUGUI atk;

    private void Start()
    {
        SetData();
    }

    public void SetData()
    {
        ItemDBs item = DataBase.Instance.ItemDB.Get(id);

        var pathsprite = Resources.Load<Sprite>(item.image_path);

        image.sprite = pathsprite;

        nametext.text = item.name;

        descriptiontext.text = item.description;

        atk.text = item.attack.ToString();
    }
}
