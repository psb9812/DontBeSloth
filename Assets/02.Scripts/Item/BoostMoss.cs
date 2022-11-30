using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//한 번 부스터로 날아갈 수 있는 아이템
public class BoostMoss : Item
{
    public Rigidbody pelvis;
    Vector3 torque;
    public float boostForce = 200f;
    public Transform playerTr;
    public Sprite itemSprite;

    // Start is called before the first frame update
    public BoostMoss()
    {
        torque = new Vector3(0, 300f, -100f) * boostForce;
        playerTr = GameObject.Find("Player").GetComponent<Transform>();
        pelvis = GameObject.Find("realpelvis").GetComponent<Rigidbody>();
        base.itemType = ItemType.BosstMoss;
        base.itemName = "부스터 이끼";
        base.itemDescription = "나무늘보의 엉덩이 털에 서식하며 나무늘보가 긴급탈출 할 때 사용하는 이끼이다." +
        " 아이템을 사용하면 순식간에 날아갈 수 있다.";
    }

    public override void UseItem()
    {
        pelvis.AddForce(playerTr.InverseTransformDirection(torque));
    }
}
