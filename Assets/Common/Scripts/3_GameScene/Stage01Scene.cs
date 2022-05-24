using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using MHomiLibrary;

public class Stage01Scene : HSingleton<Stage01Scene>
{
    protected Stage01Scene() { }

    public GameObject pausePanel;
    public GameObject playerDeadPanel;
    public GameObject OptionPanel;
    public GameObject ReStartPanel;


    public GameObject StartTimeImg;

    /// <summary>
    /// UI text모음
    /// </summary>
    public TextMeshProUGUI coinT;
    public TextMeshProUGUI coinT_die;

    public TextMeshProUGUI distance_text;
    public TextMeshProUGUI distance_text_die;
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI score_text_die;
    public TextMeshProUGUI time_text;
    public TextMeshProUGUI time_text_die;

    public TextMeshProUGUI StartTimeT;
    public GameObject StartPanel;

    public GameScene gameScene;
    public AudioManager audioManager;

    public List<Image> StarImgs;

    private void Awake()
    {
        gameScene = GameObject.Find("GameScene").GetComponent<GameScene>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        gameScene.StartStages();

        gameScene.StarAlphaCtrl(StarImgs);

        StartCoroutine(UI_Time());

        audioManager.backgroundAudio[1].Play();

        Invoke("InvokeStartT", 3.1f);
        gameScene.timeT = 3;
    }

    // Update is called once per frame

    public void Update()
    {
        GameStartTimer();

        coinT.text = gameScene.gameInstance.coinScore.ToString();
        coinT_die.text = coinT.text;

        gameScene.gameInstance.stage01Distance = Mathf.RoundToInt((gameScene.player.GetComponent<PlayerCtrl>().transform.position.z + 12.2f)) / 20;
        gameScene.gameInstance.stage01Score = (gameScene.gameInstance.stage01Distance * 10) + (int)(Time.deltaTime + 100);

        if (gameScene.gameInstance.stage01BestScore < gameScene.gameInstance.stage01Score)
        {
            gameScene.gameInstance.stage01BestScore = gameScene.gameInstance.stage01Score;

        }
        //(distance * 5) + (int)(Time.deltaTime + 100);

        distance_text.text = gameScene.gameInstance.stage01Distance.ToString() + "M";
        distance_text_die.text = gameScene.gameInstance.stage01Distance.ToString() + "M";

        score_text.text = gameScene.gameInstance.stage01Score.ToString();
        score_text_die.text = gameScene.gameInstance.stage01Score.ToString();

        gameScene.gameInstance.Stage01Star(StarImgs);
    }

    //[사용자 정의함수]===================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================

    void GameStartTimer()
    {

        if (!gameScene.gameInstance.Stage01Start && !gameScene.player.GetComponent<PlayerCtrl>().PlayerDie)
        {
            StartPanel.SetActive(true);

            if (Mathf.Floor(gameScene.timeT) <= 0)
                return;

            else
            {
                gameScene.timeT -= Time.deltaTime;

                StartTimeT.text = Mathf.Floor(gameScene.timeT + 1).ToString();

            }
        }
    }

    IEnumerator UI_Time()
    {
        while (true)
        {
            gameScene.startTime += Time.deltaTime;
            gameScene.sec = (int)(gameScene.startTime % 60);
            gameScene.min = (int)(gameScene.startTime / 60 % 60);

            time_text.text = string.Format("{0:00}:{1:00}", gameScene.min, gameScene.sec);
            time_text_die.text = string.Format("{0:00}:{1:00}", gameScene.min, gameScene.sec);


            yield return null;
        }
    }

    public void StartDelayTime01()
    {
        gameScene.StartDelayTime(StartTimeImg);
    }

    public void GamePauseBtn01()
    {
        audioManager.soundEffectAudio[0].Play();

        gameScene.GamePauseBtn(pausePanel);
    }

    public void GoToGameBtn01()
    {
        gameScene.GoToGameBtn(ReStartPanel, OptionPanel, pausePanel);

        if(gameScene.IsPause)
            audioManager.soundEffectAudio[0].Play();

    }

    public void RestartQ01Btn()
    {
        gameScene.RestartQBtn(ReStartPanel);
        audioManager.soundEffectAudio[0].Play();

    }

    public void InvokeStartT()
    {
        gameScene.gameInstance.Stage01Start = true;
        StartPanel.SetActive(false);
    }

    public void GoToReGameBtn01()
    {
        audioManager.soundEffectAudio[0].Play();
        gameScene.GoToReGameBtn();
        audioManager.backgroundAudio[1].Stop();

    }

    public void GoToOptionBtn01()
    {
        gameScene.GoToOptionBtn(OptionPanel, pausePanel);
        audioManager.soundEffectAudio[0].Play();

    }


    public void GoToBackBtn01()
    {
        audioManager.soundEffectAudio[0].Play();

        gameScene.GoToBackBtn(OptionPanel, ReStartPanel, pausePanel);
    }

}
