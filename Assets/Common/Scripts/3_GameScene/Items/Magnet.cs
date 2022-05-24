using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Magnet : MonoBehaviour
{    public TextMeshProUGUI MagnetCoinT;

    public GameObject coinDetectorObj;
    public PlayerCtrl player;    public GameInstance gameInstance;

    public bool isMagnet;    private void Awake()
    {
        gameInstance = GameObject.Find("GameInstance").GetComponent<GameInstance>();        MagnetCoinT.text = gameInstance.magnetIndex.ToString();
    }

    public void ActivateCoin()
    {        if (gameInstance.magnetIndex > 0)        {            gameInstance.magnetIndex--;            if (!isMagnet)            {                player.audioManager.soundEffectAudio[5].Play();                player.EffectList[1].Play();                MagnetCoinT.text = gameInstance.magnetIndex.ToString();                StartCoroutine(ActivateCoinCoroutine());            }        }
    }

    IEnumerator ActivateCoinCoroutine()
    {
        isMagnet = true;

        coinDetectorObj.SetActive(true);

        yield return new WaitForSeconds(3.8f);

        player.EffectList[1].Stop();

        yield return new WaitForSeconds(4f);
        coinDetectorObj.SetActive(false);

        isMagnet = false;
    }

}
