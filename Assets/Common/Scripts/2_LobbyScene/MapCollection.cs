using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MHomiLibrary;

public class MapCollection : HSingleton<LobbyScene>
{
    protected MapCollection() { }

    public GameInstance gameInstance;

    public GameObject[] rockPanels;

    public GameObject[] starPanels;
    public RectTransform CanvasTM;

    // Start is called before the first frame update
    private void Awake()
    {
        gameInstance = GameObject.Find("GameInstance").GetComponent<GameInstance>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenNextStage(int BextScore, int NextScore)
    {
        if (BextScore >= NextScore)
        {
               rockPanels[0].SetActive(false);
               starPanels[0].SetActive(true);
        }
    }
}
