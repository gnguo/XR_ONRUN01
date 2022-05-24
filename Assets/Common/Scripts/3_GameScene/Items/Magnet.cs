using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Magnet : MonoBehaviour
{

    public GameObject coinDetectorObj;
    public PlayerCtrl player;

    public bool isMagnet;
    {
        gameInstance = GameObject.Find("GameInstance").GetComponent<GameInstance>();
    }

    public void ActivateCoin()
    {
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