using System;
using System.Collections;
using System.Collections.Generic;
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
        
        //如果鸟是死的，就切换出GameOverUI，并且启动按钮
        if (BirdScript.Instance.state == BirdScript.BirdState.Dead)
        {
            GameOverUI_Animator.SetBool("Visible",true);
            StartButtonScript.instance.pushable = true;
            BigCounterScript.instance.Disappear();
        }
        else
        {
            GameOverUI_Animator.SetBool("Visible",false);
        }
        
    }
}
