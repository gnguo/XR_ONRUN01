using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPlayerCollisionCtrl : MonoBehaviour
{
    public PlayerStage01 player;
    private GameScene gameScene;
    //private Stage02Scene stage02Scene;

    private void Awake()
    {
        gameScene = GameObject.Find("GameScene").GetComponent<GameScene>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
            switch (other.tag)
            {
                case "Obstacle":
                    player.HitObstacle();
                    Debug.Log("Player HIT!!!!!!!!!!!!!!!!!!");

                break;

            case "Obstacles":
                if(!player.playerctrl.IsSlied)
                {
                    player.HitObstacle();
                    Debug.Log("Player HIT!!!!!!!!!!!!!!!!!!");
                }
                break;
        }

    }
}
