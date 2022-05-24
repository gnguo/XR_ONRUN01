using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStage01Ctrl : MonoBehaviour
{
    public Stage01Scene stage01Scene;

    private void Awake()
    {
        stage01Scene = GameObject.Find("Stage01Scene").GetComponent<Stage01Scene>();

    }
}