using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class HTweenScaleUp : MonoBehaviour
{
    private Sequence seq;

    public float fDelayTime;
    public float fDuration;
    public Vector3 Scalev3;

    void Start()
    {
        InitDoTween();
    }

    private void OnEnable()
    {
        InitDoTween();

    }

    public void InitDoTween()
    {
        // �����ϱ�
        seq = DOTween.Sequence();

        ScaleTweenAnimation();
       
    }

    public void ScaleTweenAnimation()
    {
        seq.OnStart(() =>
        {
            transform.localScale = Vector3.zero;
        })            

        .Append(transform.DOScale(new Vector3(Scalev3.x, Scalev3.y, Scalev3.z), fDuration)
        .SetDelay(fDelayTime)
        .SetEase(Ease.OutElastic));
    }

    public void OnDestroy()
    {
        DestroyDoTween();
    }

    public void DestroyDoTween()
    {
       seq.Kill();
       seq = null;
    }
}
