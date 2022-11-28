using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ToolTip toolTip;
    ItemManager itemManager;

    private void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
        toolTip.gameObject.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        if(itemManager.hasItem != null)
        {
            toolTip.gameObject.SetActive(true);
            toolTip.SetUpToolTip(itemManager.hasItem.itemName, itemManager.hasItem.itemDescription);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.gameObject.SetActive(false);
    }
}
