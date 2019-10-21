using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public GameObject pipeOringin;
    public bool ShouldMove = true;
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
    void FixedUpdate()
    {
        if (_transform.position.x <= -5)//要是位置超过屏幕左侧，就删除自己，再新建一个管子在屏幕右侧
        {
            Vector3 positionForNewPipe = _transform.position;
            positionForNewPipe.x += (float) (2 * 3.3563);
            GameObject pipe = Instantiate(pipeOringin, positionForNewPipe, Quaternion.identity);
            Destroy(gameObject);
            
        }
        if (!ShouldMove)    _rigidbody2D.velocity = Vector2.zero;
    }
}
