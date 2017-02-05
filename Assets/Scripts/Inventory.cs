using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour {

    public List<ItemInventory> items = new List<ItemInventory>();
    public GameObject gameObjectshow;
    public GameObject InventoryMainObject;
    public int MaxCount;
    public InventoryDataBase data;
    public Camera InvCam;
    public EventSystem EventSys;
    public int CurrentID;
    public ItemInventory CurrentItem;
    public RectTransform MovingObject;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        if (items.Count == 0)
            AddGraphics();

        //testing
        for(int i = 0; i < MaxCount; i++)
        {
            AddItem(i, data.items[Random.Range(0, data.items.Count)], Random.Range(1, 99), 100);
        }
        UpdateInventory();

	}
	
	// Update is called once per frame
	void Update () {
        if (CurrentID != -1)
            MoveObject();
	}

    public void AddItem(int ID, Item item, int count, float health)
    {
        items[ID].ID = item.ID;
        items[ID].health = health;
        items[ID].count = count;
        items[ID].ItemgameObject.GetComponent<Image>().sprite = item.image;
        if(count > 1 && item.ID != 0)
            items[ID].ItemgameObject.GetComponent<Text>().text = count.ToString();
        else
            items[ID].ItemgameObject.GetComponent<Text>().text = "Empty";
    }
    public void AddInventoryItem(int ID, ItemInventory inv_item)
    {
        items[ID].ID = inv_item.ID;
        items[ID].health = inv_item.health;
        items[ID].count = inv_item.count;
        items[ID].ItemgameObject.GetComponent<Image>().sprite = data.items[inv_item.ID].image;
        if (inv_item.count > 1 && inv_item.ID != 0)
            items[ID].ItemgameObject.GetComponent<Text>().text = inv_item.ToString();
        else
            items[ID].ItemgameObject.GetComponent<Text>().text = "Empty";
    }
    public void AddGraphics()
    {
        for(int i = 0; i < MaxCount; i++)
        {
            GameObject newItem = Instantiate(gameObjectshow, InventoryMainObject.transform) as GameObject;
            newItem.name = i.ToString();
            ItemInventory II = new ItemInventory();
            II.ItemgameObject = newItem;
            RectTransform RT = newItem.GetComponent<RectTransform>();
            RT.localPosition = new Vector3(0, 0, 0);
            RT.localScale = new Vector3(1, 1, 1);
            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);

            Button tempButton = newItem.GetComponent<Button>();
            tempButton.onClick.AddListener(delegate { SelectObject(); });

            items.Add(II);
        }
    }

    public void UpdateInventory()
    {
        //Change ID and count of item
        for(int i = 0; i < MaxCount; i++)
        {
            //Show Count
            if(items[i].ID != 0 && items[i].count > 1)
            {
                items[i].ItemgameObject.GetComponentInChildren<Text>().text = items[i].count.ToString();
            }
            else
            {
                items[i].ItemgameObject.GetComponentInChildren<Text>().text = "Empty";
            }

            items[i].ItemgameObject.GetComponent<Image>().sprite = data.items[items[i].ID].image;

        }
    }

    public void SelectObject()
    {
        if(CurrentID == -1)
        {
            CurrentID = int.Parse(EventSys.currentSelectedGameObject.name);
            CurrentItem = CopyInventoryItem(items[CurrentID]);
            MovingObject.gameObject.SetActive(true);
            MovingObject.GetComponent<Image>().sprite = data.items[CurrentItem.ID].image;

            AddItem(CurrentID, data.items[0], 0, 0);
        }
        else
        {
            AddInventoryItem(CurrentID, items[int.Parse(EventSys.currentSelectedGameObject.name)]);
            AddInventoryItem(int.Parse(EventSys.currentSelectedGameObject.name), CurrentItem);
            CurrentID = -1;
            MovingObject.gameObject.SetActive(false);
        }
    }

    public void MoveObject()
    {
        //Get position of mouse to Inventory object, if too close get exactly where mouse is
        Vector3 pos = Input.mousePosition + offset;
        pos.z = InventoryMainObject.GetComponent<RectTransform>().position.z;
        MovingObject.position = InvCam.ScreenToWorldPoint(pos);
    }

    public ItemInventory CopyInventoryItem(ItemInventory old)
    {
        ItemInventory New = new ItemInventory();
        New.ID = old.ID;
        New.ItemgameObject = old.ItemgameObject;
        New.health = old.health;
        New.count = old.count;
        New.ID = old.ID;
        New.ID = old.ID;
        New.ID = old.ID;

        return New;
    }
}

[System.Serializable]
public class ItemInventory
{
    public int ID;
    public GameObject ItemgameObject;
    public float health;
    public int count;
}