using System.Collections.Generic;
using UnityEngine;
using MHomiLibrary;
using System.Text;
using System.Runtime.InteropServices;
using System;

[Serializable]
public class HPlayerInfo
{
    /// <summary>
    /// �������� ���� �α��� ���̵�! Ȥ�� ���� �Է��� ���̵�
    /// </summary>
    public string sID;

    /// <summary>
    /// �������� ���� ���� ���� ���� ���̵�
    /// </summary>
    public int nUID;

    /// <summary>
    /// ������ ĳ���� ����
    /// </summary>
    public short nPlayerType;

    public int nResult;

    public int nFirst;

    public string sOTP;

    /// <summary>
    /// �÷��̾� ó�� ���� ��ġ
    /// </summary>
    public Vector3 SpawnVec3;

    /// <summary>
    /// �� �÷��̾ , ����? �ʳ�? AI ��
    /// </summary>    
    public E_PLAYER ePlayer;

    public void Init()
    {
        sID = string.Empty;
        nUID = 0;
        nPlayerType = 0;
        nResult = 0;
        nFirst = 0;
        sOTP = string.Empty;
        SpawnVec3 = Vector3.zero;
        ePlayer = E_PLAYER.ME;
    }

    void Start()
    {

    }

    public object Clone()
    {
        HPlayerInfo playerInfo = new HPlayerInfo();

        playerInfo.sID = sID;
        playerInfo.nUID = nUID;
        playerInfo.nPlayerType = nPlayerType;
        playerInfo.nResult = nResult;
        playerInfo.nFirst = nFirst;
        playerInfo.sOTP = sOTP;
        playerInfo.SpawnVec3 = SpawnVec3;
        playerInfo.ePlayer = ePlayer;

        return playerInfo;
    }
}
/// <summary>
/// �������� ���� �÷��̾� ���� ���� Ŭ����
/// </summary>
[Serializable]
public class GameData : MonoBehaviour
{

    [Header("[��������]")]
    [Space(10f)]
    /// <summary>
    /// TCP ���� ������
    /// </summary>
    public string sTCPIp;

    /// <summary>
    /// TCP������Ʈ
    /// </summary>
    public int nTCPPort;

    /// <summary>
    /// UDP ����� ��Ʈ�� �������� �޾� �����մϴ�.
    /// �̳� �� ������ Ŭ���̾�Ʈ���� ����� �ȵǿ�! "���"
    /// </summary>
    public int nUDPPort;

    [Header("[��������]")]
    [Space(4f)]
    public HPlayerInfo PlayerInfo;

}
