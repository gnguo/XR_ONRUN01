using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private static CameraShake instance;
    public static CameraShake Instance => instance;

    private float shakeTime;
    private float shakeIntensity;

    public bool IsCamShake;

    public Transform tPlayer;

    public CameraShake()
    {
        instance = this;

    }

    private void Start()
    {
        tPlayer = GameObject.Find("Player").transform;

    }

    /// <summary>
    /// �ܺ�ȣ��޼ҵ�
    /// OnShakeCamera(1); 1�ʰ� 0.1�� ����� ����
    /// OnShakeCamera(0.5f,1) 0.5�ʰ� 1�� ����� ��鸲
    /// </summary>
    /// <param name="shakeTime"></param> ī�޶� ��鸲 ���ӽð�
    /// <param name="shakeIntensity"></param>   ��鸲 ����
    public void OnShakeCamera(float shakeTime = 1.0f, float shakeIntensity = 0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StartCoroutine(ShakeByPosition());
    }

    private IEnumerator ShakeByPosition()
    {
        IsCamShake = true;

        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y);

        while(shakeTime >0f)
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            float z = tPlayer.transform.position.z + -5.47f;

            //�ʱ� ��ġ�κ��� �� ����(size1 ) * shakeIntensity�� �����ȿ��� ī�޶� ��ġ����
            Vector2 pos = startPosition + new Vector2(x,y) * shakeIntensity;

            this.transform.position = new Vector3(pos.x,pos.y, z);
            
            shakeTime -= Time.deltaTime;
            Debug.Log("ī�޶� ���==============");

            yield return null;  
        }

        transform.position = startPosition;

        yield return new WaitForSeconds(shakeTime);

        IsCamShake = false;
    }
}
