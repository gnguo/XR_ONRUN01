using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCtrl : MonoBehaviour
{
    public PlayerCtrl playerCtrl;
    public Transform target;
    Vector3 offeset;

    public float moveSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        offeset = transform.position - target.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCtrl.gameInstance.Stage01Start)
        {
            if (!playerCtrl.PlayerDie)
            {
                transform.position = target.position + offeset;
                transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
            }
        }
    }
}
