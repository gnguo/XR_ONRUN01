using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public enum Coin_Type { GOID, SILVER, BLONZE };
    public Coin_Type coinType;

    public float moveSpeed = 7;
    public GameObject player;
    public GameInstance gameInstance;

    public AudioManager audioManager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameInstance = GameObject.Find("GameInstance").GetComponent<GameInstance>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

    }

    private void OnDisable()
    {

        Invoke("CoinActiveTrueInvoke", 2.5f);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Coin_Detector")
        {
            //coinMoveScript.enabled = true;
            MoveCoins();
        }

        if (other.gameObject.tag == "Player_Bubble")
        {
            audioManager.soundEffectAudio[4].Play();

            //Add count or give points etc etc.
            switch (coinType)
            {
                case Coin_Type.GOID:
                    gameInstance.coinScore += 3;

                    break;

                case Coin_Type.SILVER:
                    gameInstance.coinScore += 2;

                    break;

                case Coin_Type.BLONZE:
                    gameInstance.coinScore++;
                    this.gameObject.SetActive(false);

                    break;
            }

        }
    }

    void CoinActiveTrueInvoke()
    {

        if(this.gameObject.activeSelf ==false)
        {
            this.gameObject.SetActive(true);
            if(this.transform.position.y!=1)
            {
                this.transform.position = new Vector3(this.transform.position.x,1,this.transform.position.z);

            }
        }

    }

    void MoveCoins()
    {
        Vector3 YPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1f);
        transform.position = Vector3.MoveTowards(player.transform.position, YPos, moveSpeed * Time.deltaTime);
    }
}
