using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Camera mainCam;  //메인 카메라
    bool isPlayer;          //레이가 플레이어를 맞췄는지 판단하는 변수
    RaycastHit hit;         //Ray에 맞은 오브젝트의 정보를 담은 변수
    public Rigidbody pelvis;//플레이어의 골반 뼈의 Rigidbody
    Vector3 torque;         //골반 뼈에 가할 힘을 지정하는 변수
    public float rotForce = 8f;    //돌리는 힘
    public bool isImmun = false;//플레이어가 무적상태인지 확인하는 변수

    public GameObject[] hinges; //나무늘보의 손톱에 자식으로 달려있는 힌지 조인트의 게임오브젝트

    //오디오 관련 변수
    AudioSource playerAudio;    
    public AudioClip turnSound;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        //회전 힘 값 설정
        torque = new Vector3(0, 20, -30f) * rotForce;
        //부모 오브젝트 때문에 거슬려서 해제
        this.transform.SetParent(null);
    }

    void Update()
    {
        //마우스 눌렀을 때
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            isPlayer = Physics.Raycast(ray, out hit, 30f, LayerMask.GetMask("Player"));
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.black, 5f);

            if (isPlayer)
            {
                ObjectMove();
            }
        }// 마우스 뗐을 때
        else if (Input.GetMouseButtonUp(0))
        {
            ObjectDrop();
        }
    }

    private void ObjectMove()
    {
        // 골반에 힘을 가함
        pelvis.AddForce(transform.InverseTransformDirection(torque));
    }

    private void ObjectDrop()
    {
        //모든 힌지를 비활성화
        foreach(GameObject hinge in hinges)
        {
            hinge.SetActive(false);
        }
        //돌아가는 소리
        playerAudio.PlayOneShot(turnSound);
    }
}
