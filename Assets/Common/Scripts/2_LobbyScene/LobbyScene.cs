using System.Collections;
using System.Collections.Generic;
using MHomiLibrary;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

//using DG.Tweening;

public class LobbyScene : HSingleton<LobbyScene>


//HSingleton<LobbyScene>
{
    protected LobbyScene() { }

    public RectTransform CanvasTM;

    public GameObject OptionPanel;

    public TextMeshProUGUI coinT;
    public TextMeshProUGUI coinT_Shop;
    public TextMeshProUGUI Stage01BestScoreT;

    public GameObject shopPanel;

    /// <summary>
    ///  스크립트 
    /// </summary>
    private GameInstance gameInstance;
    private AudioManager audioManager;
    public MapCollection mapCollection;
    public CameraZoom camZoom;

    public bool isStage01;
    public bool isStage02;

    public bool isZoom;

    public List<Image> StarImgs01;

    public List<Image> StarImgs02;

    //public List<AudioSource> soundEffectAudio;
    private void Awake()
    {
        gameInstance = GameObject.Find("GameInstance").GetComponent<GameInstance>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }


    void Start()
    {
        GotoIntroScene();

        mapCollection.OpenNextStage(gameInstance.stage01BestScore, 150);

        StageStarsAlphaZero(StarImgs01);
        StageStarsAlphaZero(StarImgs02);

        audioManager.backgroundAudio[0].Play();

        if(gameInstance.stage01BestScore!=0)
        Stage01BestScoreT.text = ": " + gameInstance.stage01BestScore.ToString();
    }

    void StageStarsAlphaZero(List<Image> starImg)
    {

        for (int i = 0; i < 3; i++)
        {
            Color color = starImg[i].GetComponent<Image>().color;
            color.a = 0f;
            starImg[i].GetComponent<Image>().color = color;

        }

    }
    /// <summary>
    /// 로고씬으로 가기^^^ 고고싱
    /// </summary>
    private void GotoIntroScene()
    {
       //if (GameObject.Find("GameInstance") == null)
       //    SceneManager.LoadScene("1_LoginScene");
    }

    void Update()
    {
        coinT.text = gameInstance.coinScore.ToString();
        coinT_Shop.text = gameInstance.coinScore.ToString();

        gameInstance.Stage01Star(StarImgs01);

    }
    //[사용자 정의함수]===================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================

    public void StageBtn01()
    {
        isStage01 = true;

        //camZoom.ZoomActive = true;
        audioManager.soundEffectAudio[0].Play();

        if (isStage02)
            isStage02 = false;

        shopPanel.SetActive(true);
        //스테이지 세부사항판넬 활성화
    }

    //판넬 말고 카메라 확대시 켜져야 할 판넬 새로 만들어서 넣어줌ㅇㅇ 새로운 판넬에 뒤로가기 버튼 만들어서 
    //zoomActive false 할수있게 해줌... 저거 false하면 판넬도 꺼지게 해야함 새로운 판넬에 맵 간단한 정보 + next버튼 만들어서 누르면 상점열리게

    public void StartStage01Btn()
    {
        isZoom = true;
        shopPanel.SetActive(true);
        audioManager.soundEffectAudio[0].Play();

    }

    public void StageBtn02()
    {
        isStage02 = true;

        audioManager.soundEffectAudio[0].Play();

        if (isStage01)
            isStage01 = false;

        shopPanel.SetActive(true);
    }

    /// <summary>
    /// 게임씬으로고고싱
    /// </summary>
    public void GotoGameScene()
    {
        StartCoroutine(GoToGameSceneCoroutine());
    }

    IEnumerator GoToGameSceneCoroutine()
    {
        if (isStage01)
        {
            //SoundManager.Play(E_SOUNLIST.E_SHOTBULLET);

            if (GameInstance.I.CreatePopupLoading(CanvasTM))
            {
                Debug.Log("개개개개개개개개개");
            }

            yield return new WaitForSeconds(0.5f);

            SceneManager.LoadScene("3_GameScene");

            isStage01 = false;
            //SoundManager.AStop();
            audioManager.backgroundAudio[0].Stop();
        }

        else if (isStage02)
        {
            //SoundManager.Play(E_SOUNLIST.E_SHOTBULLET);

            if (GameInstance.I.CreatePopupLoading(CanvasTM))
            {
                Debug.Log("개개개개개개개개개");
            }

            yield return new WaitForSeconds(0.5f);

            SceneManager.LoadScene("4_GameScene");

            isStage02 = false;
            audioManager.backgroundAudio[0].Stop();
        }

    }

    public void GoToOptionBtn()
    {
        audioManager.soundEffectAudio[0].Play();
        //soundEffectAudio[0].Play();     
        OptionPanel.SetActive(true);
       
    }
    public void GoToBackBtn()
    {
        audioManager.soundEffectAudio[0].Play();
        OptionPanel.SetActive(false);
        
    }

    public void GoToLobbyScene()
    {
        audioManager.soundEffectAudio[0].Play();
        shopPanel.SetActive(false);
    }

    public void GoToQuitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
