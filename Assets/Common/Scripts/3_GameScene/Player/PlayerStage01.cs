using MHomiLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStage01 : MonoBehaviour
{
    private SkinnedMeshRenderer[] meshs;
    public PlayerTouchMovement movement2;

    public PlayerCtrl playerctrl;
    public Stage01Scene stage01Scene;

    private void Awake()
    {
        meshs = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    public void HitObstacle()
    {
        if (playerctrl.gameInstance.curHp > 0 && !playerctrl.itemCollection.bPowerUp)
        {

            StartCoroutine(HitObstacleICoroutine());
            CameraShake.Instance.OnShakeCamera(0.3f, 0.1f);

            if (playerctrl.gameInstance.curHp <= 0)
            {

                StartCoroutine(PlayerDeadCoroutine());
            }

        }
    }

    IEnumerator PlayerDeadCoroutine()
    {
        playerctrl.anim.SetTrigger("dieT");

        playerctrl.PlayerDie = true;

        yield return new WaitForSeconds(3.5f);

        playerctrl.gameScene.PlayerDie(stage01Scene.playerDeadPanel);

        //gameoverUI start.
        //gameStop
    }

    IEnumerator HitObstacleICoroutine()
    {
        playerctrl.IsHit = true;
        playerctrl.gameInstance.curHp -= 10;

        if (playerctrl.IsHit)
        {
            foreach (SkinnedMeshRenderer mesh in meshs)
            {
                mesh.material.color = Color.red;
                playerctrl.audioManager.soundEffectAudio[2].Play();
            }
            movement2.moveSpeed = 17f;

        }

        yield return new WaitForSeconds(0.1f);

        playerctrl.IsHit = false;

        if (!playerctrl.IsHit)
        {
            foreach (SkinnedMeshRenderer mesh in meshs)
            {
                mesh.material.color = Color.white;
            }
            movement2.moveSpeed = 30;
        }

    }
}
