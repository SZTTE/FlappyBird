using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScrpit : MonoBehaviour
{
    public bool shouldMove = true; 
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
        _rigidbody2D.velocity = new Vector2(-GameObject.Find("YB").GetComponent<BirdScript>().xSpeed,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (_transform.position.x <= -5.69)
        {
            Vector3 positionForNewGround = _transform.position;
            positionForNewGround.x += (float)(2*3.3563);
            GameObject ground = Instantiate(groundOringin, positionForNewGround, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
