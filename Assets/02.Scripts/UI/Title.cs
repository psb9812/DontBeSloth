using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

/*
 * 타이틀 화면 관련 스크립트입니다.
 * 2022.10.20 박성빈
 */

public class Title : MonoBehaviour
{
    ////싱글턴 인스턴스
    //public static Title titleInstance;

    //private void Awake()
    //{
    //    if(titleInstance == null)
    //    {
    //        titleInstance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
        
    //}

    //뒤로가기 버튼을 누를 때 현재 어떤 메뉴에 있는지 파악하기 위한 열거형 타입
    enum OptionFlag
    {
        MainMenu = 0,
        OptionMenu = 1,
        TutorialMenu = 2
    }

    OptionFlag flag;
    public string sceneName = "GameScene";
    public GameObject OptionPanel;  //옵션화면
    public GameObject MainPanel;    //메인화면
    public GameObject TutorialPanel;  //조작법 화면

    public AudioMixer masterMixer;   //마스터 오디오 믹서
    public Slider BGMSlider;        //BGM오디오 슬라이더 UI
    public Slider SFXSlider;        //SFX오디오 슬라이더 UI


    private void Start()
    {
        OptionPanel.SetActive(false);
        TutorialPanel.SetActive(false);
        flag = OptionFlag.MainMenu;
    }

    public void ClickStart()
    {
        //메인 게임 씬으로 넘어갑니다.
        SceneManager.LoadScene(sceneName);
    }

    public void ClickTutorial()
    {
        TutorialPanel.SetActive(true);
        flag = OptionFlag.TutorialMenu;
    }

    public void ClickOption()
    {
        OptionPanel.SetActive(true);
        flag = OptionFlag.OptionMenu;
    }

    public void ClickExit()
    {

        Debug.Log("Exit");
        Application.Quit();
    }

    public void ClickBack()
    {

        if( flag == OptionFlag.OptionMenu)
        {
            OptionPanel.SetActive(false);
            flag = OptionFlag.MainMenu;
        }  else if (flag == OptionFlag.TutorialMenu)
        {
            TutorialPanel.SetActive(false);
            flag = OptionFlag.OptionMenu;
        }

  
    }

    //소리를 컨트롤 하는 함수
    public void AudioControl()
    {
        Debug.Log("asdf");
        float BGMSound = BGMSlider.value;
        float SFXSound = SFXSlider.value;
        //배경음 조절
        if (BGMSound == -40f)
        {
            masterMixer.SetFloat("BGM", -80);
        }
        else
        {
            masterMixer.SetFloat("BGM", BGMSound);
        }
        //효과음 조절
        if (SFXSound == -40f)
        {
            masterMixer.SetFloat("SFX", -80);
        }
        else
        {
            masterMixer.SetFloat("SFX", SFXSound);
        }
    }
}
