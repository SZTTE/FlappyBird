using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;


public class BirdScript : MonoBehaviour
{
    //公共字段
    public float xSpeed;

    public bool Alive = true;
    //这个游戏对象的其他组件
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        //使脚本内组件变量指向外面的组件实例
        animator = transform.Find("YellowBird").GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        //指令
        rigidbody2D.simulated = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("space") && Alive)//按下空格向上加速
        {
            animator.SetBool("isPlaying",true);
            animator.SetTrigger("wave");
            rigidbody2D.simulated = true;
            rigidbody2D.AddForce(Vector2.up * 5.5f,ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        //转鸟
        double finalAngle = Mathf.Atan2(rigidbody2D.velocity.y/2 , xSpeed); //最终角
        _transform.localEulerAngles = new Vector3(0,0,(float)finalAngle* Mathf.Rad2Deg );
        //规范鸟的数值速度
        if (rigidbody2D.velocity.y > 4)
        {
            rigidbody2D.velocity = Vector2.up * 4;
        }
        if (rigidbody2D.velocity.y < -4)
        {
            rigidbody2D.velocity = Vector2.up * -4;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)//要是装上扳机碰撞体
    {
        
        if (other.CompareTag("Pipe"))
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
            Alive = false;
        }
        if (other.CompareTag("Ground"))
        {
            rigidbody2D.simulated = false;
            Debug.Log("here!");
        }
        
    }
    
}
