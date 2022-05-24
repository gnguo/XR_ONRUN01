using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchMovement : MonoBehaviour
{
    private float moveXWidth = 3.6f;
    private float moveTimeX = 0.1f;
    private bool isXMove = false;

    private float originY = 0.4f;
    private float gravity = -10.81f;
    private float moveTimeY = 0.5f;
    public bool isJump = false;

    [SerializeField]
    public float moveSpeed = 20.0f;

    private float limitY = -2.0f;

    private Rigidbody rd;

    PlayerCtrl playerCtrl;
    private AudioManager audioManager;

    private void Awake()
    {
        rd = GetComponent<Rigidbody>();
        playerCtrl = GetComponent<PlayerCtrl>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if(playerCtrl.gameInstance.Stage01Start)
        {
            if (!playerCtrl.PlayerDie)
            {
                transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

                //transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
            }

            if (transform.position.y < limitY)
            {
                Debug.Log("gameover");
                playerCtrl.PlayerDie = true;
            }

        }
    }

    public void MoveToX(int x)
    {
        if (isXMove == true)
            return;

        if(x >0 && transform.position.x < moveXWidth)
        {
            StartCoroutine(OnMoveToX(x));
        }

        else if( x < 0 && transform.position.x > -moveXWidth)
        {
            StartCoroutine(OnMoveToX(x));
        }

    }

    public void MoveToY()
    {
        if (isJump == true)
            return;

        StartCoroutine(OnMoveToY());
    }

    private IEnumerator OnMoveToX(int direction)
    {
        float current = 0;
        float percent = 0;
        float start = transform.position.x;
        float end = transform.position.x + direction * moveXWidth;

        isXMove = true;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTimeX;

            float x = Mathf.Lerp(start, end, percent);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);

            yield return null;

        }
        isXMove = false;
    } 
    


    private IEnumerator OnMoveToY()
    {
        float current = 0;
        float percent = 0;
        float v0 = -gravity;

        isJump = true;
        rd.useGravity = false;
        audioManager.soundEffectAudio[1].Play();


        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTimeY;

            float y = originY + (v0 * percent) + (gravity * percent * percent);
            transform.position = new Vector3(transform.position.x,Mathf.Clamp(y,0,7), transform.position.z);

            yield return null;

        }

        yield return new WaitForSeconds(0.2f);
        rd.useGravity = true;

        //this.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 endPos = new Vector3(transform.position.x, 0, transform.position.z);
        this.transform.position = endPos;

        isJump = false;

    }
}
