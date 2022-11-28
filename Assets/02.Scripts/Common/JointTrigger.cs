using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointTrigger : MonoBehaviour
{
    public bool isGrab = false;
    CamMove camMove;
    
    //여러개가 고정되는 걸 방지하기 위함
    int count;
    //현재 나뭇가지와 접촉해 힌지가 활성화 된 오브젝트
    GameObject activeNail;

    AudioSource catchAudio;
    public AudioClip catchSound;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        activeNail = null;
        camMove = this.GetComponent<CamMove>();
        camMove.enabled = false;
        catchAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6 && count < 1)
        {
            catchAudio.PlayOneShot(catchSound);
            isGrab = true;
            //충돌한 HandAndFoot태그를 가지고있는 오브젝트의 자식(힌지 조인트 컴포넌트를 가지고 있음)을
            //액티브해서 그 순간의 좌표에 힌지 활성화
            other.transform.GetChild(0).gameObject.SetActive(true);
            count++;
            activeNail = other.gameObject;

            camMove.FrontCamMove();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        camMove.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrab = false;
        camMove.enabled = false;
    }

    //한 쪽 접합부가 닿으면 반대편 접합부도 고정되도록 하는 함수
    public void pairing()
    {
        
    }
   

    

}
