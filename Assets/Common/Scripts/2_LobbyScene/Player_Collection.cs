using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collection : MonoBehaviour
{
    public List<GameObject> PlayerGam;

    public List<GameObject> OffsetList;
    public List<GameObject> ParticleList;


    void Start()
    {
    }


    void Update()
    {

    }
    //[����� �����Լ�]===================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================


    public void EnablePlayer(int nIndex)
    {
        if (ParticleList == null)
            return;

        foreach (GameObject p in ParticleList)
        {
            p.SetActive(false);
        }

        //ParticleList[nIndex].SetActive(true);
    }

}
