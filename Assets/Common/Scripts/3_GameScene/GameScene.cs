using MHomiLibrary;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameScene : HSingleton<GameScene>
{

    protected GameScene() { }

    public bool IsPause = false;

    //public GameObject pausePanel;
    //public GameObject playerDeadPanel;
    //public GameObject OptionPanel;
    //public GameObject ReStartPanel;
    //
    //public GameObject StartTimeImg;
    //
    public float StartdelayT;
    public bool IsStartDelay = false;

    /// <summary>
    /// UI text모음
    /// </summary>
    //public TextMeshProUGUI coinT;
    //public TextMeshProUGUI coinT_die;
    // public TextMeshProUGUI distance_text;
    // public TextMeshProUGUI distance_text_die;
    // public TextMeshProUGUI score_text;
    // public TextMeshProUGUI score_text_die;
    // public TextMeshProUGUI time_text;
    // public TextMeshProUGUI time_text_die;

    //public TextMeshProUGUI StartTimeT;
    //public GameObject StartPanel;

    //ItemCtrl itemctrl;
    public GameInstance gameInstance;

    /// <summary>
    /// UI타이머 설정
    /// </summary>
    public GameObject player;
    public float startTime;


    public float timeT = 3;

    public float sec;
    public float min;


    private void Awake()
    {
        //itemctrl = GameObject.FindGameObjectWithTag("Items").GetComponent<ItemCtrl>();
        gameInstance = GameObject.Find("GameInstance").GetComponent<GameInstance>();
        player = GameObject.Find("Player");
    }

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void StartStages()
    {
        GotoLobbyScene();

        player = GameObject.Find("Player");

        gameInstance.stage01Score = 0;

    }


    //[사용자 정의함수]===================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================

    public void StarAlphaCtrl(List<Image> Starimgs)
    {
        for (int i = 0; i < 3; i++)
        {
            Color color = Starimgs[i].GetComponent<Image>().color;
            color.a = 0f;
            Starimgs[i].GetComponent<Image>().color = color;
        }


    }

    public void StartDelayTime(GameObject StartTimeImg)
    {
        StartdelayT -= Time.deltaTime * 1f; //시작시 타이머 3210

        if (StartdelayT > 0)
        {
            IsStartDelay = true;

            StartTimeImg.SetActive(true);
        }
        else if (StartdelayT <= 0)
        {
            IsStartDelay = false;
            StartTimeImg.SetActive(false);
        }


    }

    private void GotoLobbyScene()
    {
        if (GameObject.Find("GameInstance") == null)
            SceneManager.LoadScene("0_IntroScene");
    }

    public void GamePause()
    {
        //gamePause시 공통사항들...sound 등
        IsPause = true;

        Time.timeScale = 0;
    }

    public void PlayerDie(GameObject playerDeadPanel)
    {
        GamePause();

        print("PlayerDie실행됨"); //x
        playerDeadPanel.SetActive(true);
        //gameover 결과 추가....
    }

    public void GamePauseBtn(GameObject pausePanel)
    {
        GamePause();
        pausePanel.SetActive(true);      
    }
    
    public void GoToGameBtn(GameObject ReStartPanel, GameObject optionPanel, GameObject pausePanel)
    {
        if (IsPause)
        {
            Time.timeScale = 1;
            IsPause = false; 
            
            if (ReStartPanel)
            {
                ReStartPanel.SetActive(false);
            }
            pausePanel.SetActive(false);
            optionPanel.SetActive(false);
            return;
        }
    }

    public void RestartQBtn(GameObject ReStartPanel)
    {
        ReStartPanel.SetActive(true);
    }

    public void GoToReGameBtn()
    {
            IsPause = false;
        gameInstance.Stage01Start = false;
        gameInstance.magnetIndex = 0;

        Time.timeScale = 1;
        //fade in fade out? 넣어야할듯 , UI초기화도 필요
        SceneManager.LoadScene("2_LobbyScene");  //3_GameScene
        
    }

    public void GoToOptionBtn(GameObject optionPanel, GameObject pausePanel)
    {
        optionPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void GoToBackBtn(GameObject optionPanel, GameObject reStartPanel, GameObject pausePanel)
    {
        optionPanel.SetActive(false);
        reStartPanel.SetActive(false);
        pausePanel.SetActive(true);
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
