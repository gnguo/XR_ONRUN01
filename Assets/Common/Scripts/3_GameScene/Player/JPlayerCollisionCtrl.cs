using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPlayerCollisionCtrl : MonoBehaviour
{
    public PlayerCtrl player;
    private GameScene gameScene;
    //private Stage02Scene stage02Scene;

    private void Awake()
    {
        gameScene = GameObject.Find("GameScene").GetComponent<GameScene>();
       // stage02Scene = GameObject.Find("Stage02Scene").GetComponent<Stage02Scene>();
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
                if(!player.IsSlied)
                {
                    player.HitObstacle();
                    Debug.Log("Player HIT!!!!!!!!!!!!!!!!!!");
                }
                break;
        }

    }
}
