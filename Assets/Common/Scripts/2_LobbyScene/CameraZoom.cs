using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public bool ZoomActive;

    public Vector3[] Target;

    public Camera Cam;

    public float Speed;

    public LobbyScene lobbyScene;

    private void Start()
    {
        Cam = Camera.main;
    }

    public void LateUpdate()
    {
        if (ZoomActive)
        {
            if(lobbyScene.isStage01)
            {
                Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 3, Speed);

                //카메라 위치
                Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                Input.mousePosition.y, -Camera.main.transform.position.z));
                //나중에 버튼들 가운데 위치로 point 값 조정

                Target[1] = point;

                Cam.transform.position = Vector3.Lerp(Cam.transform.position, Target[1], Speed);
            }

            else if(lobbyScene.isStage02)
            {
                Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 3, Speed);

                //카메라 위치
                Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                Input.mousePosition.y, -Camera.main.transform.position.z));
                //나중에 버튼들 가운데 위치로 point 값 조정
                Target[2] = point;

                Cam.transform.position = Vector3.Lerp(Cam.transform.position, Target[1], Speed);

            }
        }
        else
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 5, Speed);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, Target[0], Speed);

        }
    }
}
