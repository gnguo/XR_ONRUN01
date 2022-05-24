using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGame_Collection : MonoBehaviour
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

}
