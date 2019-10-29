using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using Random = System.Random;


public class BirdScript : MonoBehaviour
{
    //公共字段
    public static BirdScript Instance;
    public enum BirdState//鸟的状态
    {
        SelfControl,PlayerControl,Dead
    }
    public BirdState state = BirdState.SelfControl;

    public Sprite redPicture;
    public Sprite yellowPicture;
    public Sprite bluePicture;
    //这个游戏对象的其他组件
    private Animator animator;
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    //私有字段
    

    
    //------------------------------------------------------------------------------公共方法
    public void LetPlayerControl() //给玩家控制权,并且让鸟跳一下
    {
        animator.SetBool("isPlaying",true);
        state = BirdState.PlayerControl;
        _rigidbody2D.simulated = true;
        _rigidbody2D.velocity = Vector2.up*3;
    }

    public void ResetBird()//把鸟还原成刚开始游戏的状态
    {
        animator.SetBool("isPlaying",false);
        animator.SetInteger("color", UnityEngine.Random.Range(0,3));
        animator.SetTrigger("reload");
        state = BirdState.SelfControl;
        transform.position = new Vector3(transform.position.x,-0.1781336f);
    }

    public void GotoBeginPosition()
    {
        transform.position = new Vector3(-3.26f,-0.1781336f);
    }


    //------------------------------------------------------------------------------事件函数
    void Awake()//鸟是单例
    {
        if (Instance == null) Instance = this;//确保场上只有一个实例存在，并且接收类的记录
        else Destroy(gameObject);
    }



    void Start()
    {
        
        //使脚本内组件变量指向外面的组件实例
        animator = transform.Find("YellowBird").GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        //指令
        _rigidbody2D.simulated = false;
        //ResetBird();
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && state == BirdState.PlayerControl && _transform.position.y <= 2.5)//按下空格（并且鸟在控制模式下）向上加速
        {
            //_rigidbody2D.AddForce(Vector2.up * 5.5f,ForceMode2D.Impulse);
            _rigidbody2D.velocity = Vector2.up*3;
        }
    }

    private void FixedUpdate()
    {
        //转鸟
        double finalAngle = Mathf.Atan2(_rigidbody2D.velocity.y/2 , GameManager.Instance.xSpeed); //最终角
        _transform.localEulerAngles = new Vector3(0,0,(float)finalAngle* Mathf.Rad2Deg );
        //规范鸟的数值速度
        if (_rigidbody2D.velocity.y > 4)
        {
            _rigidbody2D.velocity = Vector2.up * 4;
        }
        if (_rigidbody2D.velocity.y < -4)
        {
            _rigidbody2D.velocity = Vector2.up * -4;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)//要是装上扳机碰撞体
    {
        
        if (other.CompareTag("Pipe") || other.CompareTag("Ground"))
        {
            //把管子停下来
            var foundPipeScripts = GameObject.FindObjectsOfType<PipeScript>(); //通过pipeScrpit的类型找到所有附着在管子上的组件。
            foundPipeScripts[0].ShouldMove = false;
            foundPipeScripts[1].ShouldMove = false;
            foundPipeScripts[2].ShouldMove = false;
            foundPipeScripts[3].ShouldMove = false;
            //把地面停下来
            var foundGroundScripts = GameObject.FindObjectsOfType<GroundScript>(); //通过pipeScrpit的类型找到所有附着在管子上的组件。
            foundGroundScripts[0].ShouldMove = false;
            foundGroundScripts[1].ShouldMove = false;
            //把自己停下来
            state = BirdState.Dead;
            animator.SetTrigger("die");
        }
        if (other.CompareTag("Ground"))
        {
            _rigidbody2D.simulated = false;
        }

        if (other.CompareTag("ScoreBox"))
        {
            GameManager.Instance.ScoreAdd();
            BigCounterScript.instance.Print(GameManager.Instance.score);
        }
        
    }
    
}
