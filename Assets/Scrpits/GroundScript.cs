using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public bool ShouldMove = true; 
    public GameObject groundOringin;
    //导入其他组件
    private Transform _transform;

    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        //设置速度为公用速度
        _rigidbody2D.velocity = new Vector2(-GameManager.Instance.xSpeed,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (_transform.position.x <= -5.69)//要是地面太靠左，就删除自己，从右边生成一个新的地面
        {
            Vector3 positionForNewGround = _transform.position;
            positionForNewGround.x += (float)(2*3.345);
            GameObject ground = Instantiate(groundOringin, positionForNewGround, Quaternion.identity);
            Destroy(gameObject);
        }
        
        if (!ShouldMove)//不该动就别动。
            _rigidbody2D.velocity = Vector2.zero;
    }
}
