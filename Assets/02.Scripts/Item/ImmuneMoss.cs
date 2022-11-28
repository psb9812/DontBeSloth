using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;



//5초 동안 장애물 한번 피격 무시 아이템
public class ImmuneMoss : Item
{
    //PlayerControl 컴포넌트 변수
    PlayerControl playerCtrl;
    //무적 시간
    float immunTime = 5f;

    //생성자
    public ImmuneMoss()
    {
        playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        base.itemType = ItemType.ImmunMoss;
        base.itemName = "면역 이끼";
        base.itemDescription = "나무늘보의 등쪽 털에 서식하여 나무늘보의 면역력을 키워주는 이끼이다." +
        " 아이템을 사용하면 5초 동안 장애물에 대한 피격에 면역된다.";
    }

    public override void UseItem()
    {
        playerCtrl.StartCoroutine(ImmunDuration());
    }

    IEnumerator ImmunDuration()
    {
        Debug.Log("start");
        playerCtrl.isImmun = true;
        yield return new WaitForSeconds(immunTime);
        playerCtrl.isImmun = false;
        Debug.Log("End");
    }
}
