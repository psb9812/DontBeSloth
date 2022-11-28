using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemManager : MonoBehaviour
{
    public List<Sprite> itemImages;
    public Image itemImageUI;
    bool isImageApply = false;
    [HideInInspector]
    public Item hasItem;

    AudioSource itemAudio;
    public AudioClip getItemAudio;
    public AudioClip useItemAudio;

    private void Start()
    {
        hasItem = null;
        itemImageUI.sprite = null;
        itemAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        ItemAction();
        ImageApplyToUI();
    }

    //아이템 작용 하는 함수
    public void ItemAction()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hasItem == null)
            {
                //아이템이 없을 떄 할 일
            }
            else
            {
                hasItem.UseItem();
                itemAudio.PlayOneShot(useItemAudio);
                //아이템은 한 번 쓰면 null;
                hasItem = null;
                //이미지 초기화
                itemImageUI.sprite = null;
                isImageApply = false;
            }
        }
    }

    public void ImageApplyToUI()
    {
        if(hasItem != null && !isImageApply)
        {
            itemAudio.PlayOneShot(getItemAudio);
            itemImageUI.sprite = itemImages[(int)hasItem.itemType];
            isImageApply = true;
        }
    }
}
