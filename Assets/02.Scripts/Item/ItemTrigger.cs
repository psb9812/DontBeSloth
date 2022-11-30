using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemTrigger : MonoBehaviour
{
    ItemManager itemManager;
    public ItemType thisItemType;


    // Start is called before the first frame update
    void Start()
    {
        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //현재 가지고 있는 아이템이 없는 경우
        if (itemManager.hasItem == null)
        {
            //itemManager에 hasItme 갱신
            switch (thisItemType)
            {
                case ItemType.BosstMoss:
                    itemManager.hasItem = new BoostMoss();
                    break;
                case ItemType.ImmunMoss:
                    itemManager.hasItem = new ImmuneMoss();
                    break;
            }
            //삭제
            Destroy(gameObject);
        }
        else
        {
            //아이템이 있는 경우
        }
    
    }
}
