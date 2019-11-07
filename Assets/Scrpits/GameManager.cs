using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static float xSpeed = 1;
    public int score = 0;
    public static int highestScore = 0;
    private Animator GameOverUI_Animator;
    private AudioSource _anotherAudioSource;


    public void ScoreAdd()
    {
        score++;
    }

    public void playSound(AudioClip au)
    {
        _anotherAudioSource.PlayOneShot(au);
    }

    private void EnableStartButton()
    {
        StartButtonScript.instance.pushable = true;
    }

    //------------------------------------------------------------------------------------------------------------------事件函数
    void Awake()
    {
        if (Instance == null) Instance = this;//确保场上只有一个实例存在，并且接收类的记录
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameOverUI_Animator = GameObject.Find("GameOverUI").GetComponent<Animator>();

        SkyScript.instance.ResetTime();
        BirdScript.Instance.GotoBeginPosition();
        BirdScript.Instance.state = BirdScript.BirdState.SelfControl;
        PipesManager.instance.Stop();
        score = 0;
        BigCounterScript.instance.Print(0);
        _anotherAudioSource = GameObject.Find("ExtraAudioSource").GetComponent<AudioSource>();
        highestScore = PlayerPrefs.GetInt("HighestScore");

    }

    private bool preBirdIsDead = false;//使得鸟死脚本只执行依次
    // Update is called once per frame
    void Update()
    {
        if (score > highestScore)
        {
            highestScore = score;
            PlayerPrefs.SetInt("HighestScore",highestScore);
        }
        
        if (Input.GetMouseButtonDown(0) && BirdScript.Instance.state == BirdScript.BirdState.SelfControl) //如果按下鼠标，鸟切换为玩家控制
        {
            BirdScript.Instance.LetPlayerControl();
            GameObject.Find("GetReadyUI").GetComponent<Animator>().SetTrigger("fade");
            PipesManager.instance.Move();
        }
        
        //如果鸟是死的,并且本语句尚未执行依次，就切换出GameOverUI，并且启动按钮
        if (BirdScript.Instance.state == BirdScript.BirdState.Dead && preBirdIsDead== false)
        {
            GameOverUI_Animator.SetBool("Visible",true);
            Invoke("EnableStartButton",1f);
            BigCounterScript.instance.Disappear();
            preBirdIsDead = true;
        }
        if (BirdScript.Instance.state != BirdScript.BirdState.Dead)
        {
            GameOverUI_Animator.SetBool("Visible",false);
        }
        
    }
}
