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
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //x坐标自减xspeed
        _transform.Translate(new Vector3(- GameObject.Find("YB").GetComponent<BirdScript>().xSpeed,0));
        if (_transform.position.x <= -5.69)
        {
            Vector3 positionForNewGround = _transform.position;
            positionForNewGround.x += (float)(2*3.3563);
            GameObject ground = Instantiate(groundOringin, positionForNewGround, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
