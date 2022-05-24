using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pllayer_Collection : MonoBehaviour
{

    /// <summary>
    /// �÷��̾� ����Ʈ
    /// </summary>
    public List<PlayerCtrl> PlayerList;


    private void Awake()
    {
        PlayerList = new List<PlayerCtrl>();

        int nCount = transform.childCount;

        for (int i = 0; i < nCount; i++)
        {
            Transform PlayerTm = transform.GetChild(i);
            PlayerList.Add(PlayerTm.GetComponent<PlayerCtrl>());
        }

    }

    //[����� ���� �Լ�]==================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    /// <summary>
    /// �� ���Ⱑ ĳ���� ����°��̾�~~~ ���⿩�� ***
    /// </summary>
    /// <param name="spawnV3"></param>
    public void EnablePlayer(Vector3 spawnV3)
    {
        if (PlayerList != null)
        {  //
           // foreach (PlayerCtrl Obj in PlayerList)
           // {
           //     if (Obj.gameObject.activeSelf == false)
           //     {
           //         Obj.gameObject.SetActive(true);
           //
           //         Obj.EnablePlayer(spawnV3);
           //         Obj.EnableMesh(GameInstance.I.GData.PlayerInfo.nPlayerType);
           //
           //         return;
           //     }
           // }
        }
    }

    /// <summary>
    /// �÷��̾� ��Ȱ��ȭ
    /// </summary>
    /// <param name="nIndex"></param>
    public void DisablePlayer(int nIndex)
    {
        if (PlayerList != null)
        {
            PlayerList[nIndex].gameObject.SetActive(false);

            PlayerCtrl Player = PlayerList[nIndex].GetComponent<PlayerCtrl>();

            //Player.DisablePlayer();
        }
    }

}
