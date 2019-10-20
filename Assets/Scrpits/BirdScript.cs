using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    //公共字段
    public float xSpeed;
    //这个游戏对象的其他组件
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        //使脚本内组件变量指向外面的组件实例
        animator = transform.Find("YellowBird").GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        //指令
        rigidbody2D.simulated = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("isPlaying",true);
            animator.SetTrigger("wave");
            rigidbody2D.simulated = true;
            rigidbody2D.AddForce(Vector2.up * 5.5f,ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (rigidbody2D.velocity.y > 4)
        {
            rigidbody2D.velocity = Vector2.up * 4;
        }
        if (rigidbody2D.velocity.y < -4)
        {
            rigidbody2D.velocity = Vector2.up * -4;
        }
    }
}
