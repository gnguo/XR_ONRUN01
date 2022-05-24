using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lerpColor : MonoBehaviour
{
    public GameInstance gameInstance;

    public Color startColor = Color.red;
    public Color endColor = Color.yellow;

    [Range(0, 10)]
    public float speed = 1f;

    public Image hpFillImg;

    private void Awake()
    {
        hpFillImg = GetComponent<Image>();
        gameInstance = GameObject.Find("GameInstance").GetComponent<GameInstance>();

    }

    private void Update()
    {
        if (gameInstance.bItemHpUse)
            LerpColor();

    }
    public void LerpColor()
    {
        hpFillImg.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
    }
}
