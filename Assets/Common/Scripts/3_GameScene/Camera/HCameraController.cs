using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HCameraController : MonoBehaviour
{
    public Transform tPlayer;

    //카메라 위치
    private float yOffset = 2.5f;
    private float zOffset = -5.47f;


    void Start()
    {
        //tPlayer = GameObject.Find("Player").transform;
    }


    void LateUpdate()
    {
        if(!CameraShake.Instance.IsCamShake)
        {
            Vector3 pos = new Vector3(tPlayer.position.x,
                                 tPlayer.position.y + yOffset,
                                 tPlayer.position.z + zOffset);

            this.transform.position = pos;

        }
    }
}

