using MHomiLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    [Header("[������Ʈ��]")]
    [Space(10f)]
    /// <summary>
    /// ����Ʈ ����Ʈ
    /// </summary>
    public List<ParticleSystem> EffectList;

    [SerializeField]
    private float dragDistance = 14.0f;
    private float dragDistanceY = 20;
    private float dragDistanceDownY = -20;

    private Vector3 touchStart;
    private Vector3 touchEnd;

    /// <summary>
    /// ���� ���� ���� ����
    /// </summary>
    public int nShield;

    private SkinnedMeshRenderer[] meshs;
    private PlayerTouchMovement movement;

    private GameScene gameScene;
    public GameInstance gameInstance;
    public Stage01Scene stage01Scene;
    public Item_Collection itemCollection;

    public Animator anim;

    public HSpawnManager spawnManager;
    public CapsuleCollider capsuleCol;
    public AudioManager audioManager;

    public bool IsHit = false;
    public bool PlayerDie = false;
    public bool IsSlied = false;

    [SerializeField]
    private Slider hpbar;

    private void Awake()
    {
        movement = GetComponent<PlayerTouchMovement>();
        meshs = GetComponentsInChildren<SkinnedMeshRenderer>();
        gameScene = GameObject.Find("GameScene").GetComponent<GameScene>();
        gameInstance = GameObject.Find("GameInstance").GetComponent<GameInstance>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        
        stage01Scene = GameObject.Find("Stage01Scene").GetComponent<Stage01Scene>();
    }

    void Start()
    {
        //gameScene.StartDelayTime();

        Init();

    }

    void Update()
    {
        HPHandle();

        WaitAnim();

        //hpLerpColor.LerpColor();


        if (!PlayerDie && !CameraShake.Instance.IsCamShake)
        {
            //if(!gameScene.IsStartDelay)
            //{

            if (Application.isMobilePlatform)
            {
                OnMobilePlatform();
            }

            else
            {
                OnPCPlatform();
            }
        }
    }

    //[����� ���� �Լ�]==================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================
    //====================================================================================

    void Init()
    {
        PlayerDie = false;
        hpbar.value = gameInstance.curHp / gameInstance.maxHp;
        movement.moveSpeed = 30;

        gameInstance.curHp = gameInstance.maxHp;
    }

    void WaitAnim()
    {
        if (!gameInstance.Stage01Start)
            anim.SetBool("IsIdle", true);
        else
            anim.SetBool("IsIdle", false);
    }

    void OnMobilePlatform()
    {
        if (Input.touchCount == 0)
            return;
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            touchStart = touch.position;
        }

        else if (touch.phase == TouchPhase.Moved)
        {
            touchEnd = touch.position;

            OnDragXY();

        }
    }

    private void OnPCPlatform()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            touchEnd = Input.mousePosition;

            if (!PlayerDie)
                OnDragXY();
        }
    }

    private void OnDragXY()
    {

        if (Mathf.Abs(touchEnd.x - touchStart.x) >= dragDistance && !movement.isJump && !IsSlied)
        {
            movement.MoveToX((int)Mathf.Sign(touchEnd.x - touchStart.x));
            return;
        }

        if (touchEnd.y - touchStart.y >= dragDistanceY)
        {
            movement.MoveToY();
            StartCoroutine(JumpOrDownTouchCoroutine());
            return;
        }

        if (touchEnd.y - touchStart.y <= dragDistanceDownY )
        {
            StartCoroutine(JumpOrDownTouchCoroutine());
            return;
        }
    }

    private void HPHandle()
    {
        //?????? ?????? hp???? ???????? ???????? ????
        hpbar.value = Mathf.Lerp(hpbar.value, gameInstance.curHp / gameInstance.maxHp, Time.deltaTime * 10);
    }



    public void HitObstacle()
    {
        if (gameInstance.curHp > 0 && !itemCollection.bPowerUp)
        {

            StartCoroutine(HitObstacleICoroutine());
            CameraShake.Instance.OnShakeCamera(0.3f, 0.1f);

            if (gameInstance.curHp <= 0)
            {

                StartCoroutine(PlayerDeadCoroutine());
            }

        }
    }

    IEnumerator PlayerDeadCoroutine()
    {
        anim.SetTrigger("dieT");

        PlayerDie = true;

        yield return new WaitForSeconds(3.5f);

        gameScene.PlayerDie(stage01Scene.playerDeadPanel);

        //gameoverUI start.
        //gameStop
    }

    IEnumerator HitObstacleICoroutine()
    {
        IsHit = true;
        gameInstance.curHp -= 10;

        if (IsHit)
        {
            foreach (SkinnedMeshRenderer mesh in meshs)
            {
                mesh.material.color = Color.red;
                audioManager.soundEffectAudio[2].Play();
            }
            movement.moveSpeed = 17f;

        }

        yield return new WaitForSeconds(0.1f);

        IsHit = false;

        if (!IsHit)
        {
            foreach (SkinnedMeshRenderer mesh in meshs)
            {
                mesh.material.color = Color.white;
            }
            movement.moveSpeed = 30;
        }

    }


    IEnumerator JumpOrDownTouchCoroutine()
    {
        IsSlied = true;
        //capsuleCol.enabled = false;

        if (movement.isJump)
        {
            //start Jumpanim trigger
            anim.SetBool("IsJump", true);
        }
        else
        {
            anim.SetBool("IsSlide", true);
        }

        yield return new WaitForSeconds(0.2f);

        if (anim.GetBool("IsSlide") == true)
        {
            anim.SetBool("IsSlide", false);
        }


        yield return new WaitForSeconds(0.3f);


        if (anim.GetBool("IsJump") == true)
        {
            //start Jumpanim trigger
            anim.SetBool("IsJump", false);
        }

        yield return new WaitForSeconds(0.31f);

        //capsuleCol.enabled = true;
        Debug.Log(capsuleCol.enabled);

        yield return new WaitForSeconds(0.5f);
        IsSlied = false;


    }

}
