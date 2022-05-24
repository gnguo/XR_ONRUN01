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
    /// 외부호출메소드
    /// OnShakeCamera(1); 1초간 0.1의 세기로 ㅇㅇ
    /// OnShakeCamera(0.5f,1) 0.5초간 1의 세기로 흔들림
    /// </summary>
    /// <param name="shakeTime"></param> 카메라 흔들림 지속시간
    /// <param name="shakeIntensity"></param>   흔들림 세기
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

            //초기 위치로부터 구 범위(size1 ) * shakeIntensity의 범위안에서 카메라 위치변동
            Vector2 pos = startPosition + new Vector2(x,y) * shakeIntensity;

            this.transform.position = new Vector3(pos.x,pos.y, z);
            
            shakeTime -= Time.deltaTime;
            Debug.Log("카메라 흔들어여==============");

            yield return null;  
        }

        transform.position = startPosition;

        yield return new WaitForSeconds(shakeTime);

        IsCamShake = false;
    }
}
