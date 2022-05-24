using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class ShopManager : MonoBehaviour
{
    public LobbyScene lobbyScene;

    GameInstance gameInstance;

    public TextMeshProUGUI hpCoinT;
    public TextMeshProUGUI PowerUpCoinT;
    public TextMeshProUGUI magnetCoinT;

    public int hpCoin;
    public int powerUpCoin;
    public int magnetCoin;

    public GameObject[] BuyComPanels;


    private void Awake()
    {
        gameInstance = GameObject.Find("GameInstance").GetComponent<GameInstance>();
        magnetCoinT.text = gameInstance.magnetIndex.ToString();
    }

    private void Start()
    {
        gameInstance.magnetIndex = 0;

    }
    //[?????? ????????]===================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================

    public void HealthUPItem()
    {
        hpCoin = 250;
        gameInstance.maxHp += gameInstance.maxHp * 0.2f;

        ShopBuyLimit(hpCoin, 0, gameInstance.bItemHpUse = true);

        hpCoinT.text = hpCoin.ToString();

    }

    //???????????? ????????????
    public void PowerUpItem()
    {
        powerUpCoin = 250;  
        gameInstance.powerUpTime += gameInstance.powerUpTime + 2f;

        ShopBuyLimit(powerUpCoin, 1, gameInstance.bItemPowerUpUse);

        PowerUpCoinT.text = powerUpCoin.ToString();
    }

    public void MagnetItem()
    {
        magnetCoin = 100;

        if( gameInstance.magnetIndex <= 2)
        {
            if (gameInstance.coinScore >= magnetCoin)
            {
                //????~
                gameInstance.coinScore -= magnetCoin;

                gameInstance.magnetIndex++;
                magnetCoinT.text = gameInstance.magnetIndex.ToString();

                if(gameInstance.magnetIndex ==3)
                    BuyComPanels[2].SetActive(true);

            }
        }

        return;
    }

    //?????? ???????? ?????? ???????????? ???????? 
    void ShopBuyLimit(int price, int num, bool IsUse)
    {
        IsUse = false;

        if (gameInstance.coinScore >= price)
        {
            //????~
            gameInstance.coinScore -= price;

            //????????????
            BuyComPanels[num].SetActive(true);

            IsUse = true;
        }
        else
            return;

    }
}
