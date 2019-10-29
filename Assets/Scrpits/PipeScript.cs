using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public GameObject pipeOringin;
    public bool ShouldMove = true;
    private Transform _transform;

    private Rigidbody2D _rigidbody2D;
    private Collider2D[] _collider2Ds;

    public double XPosition
    {
        get => _transform.position.x;
    }

    public void ResetPosition()
    {
        _transform.Translate(Vector3.right*(float) (2 * 3.3563));
    }

// Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2Ds = GetComponentsInChildren<Collider2D>();
        //设置速度为公用速度
        _rigidbody2D.velocity = new Vector2(-GameManager.xSpeed,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (ShouldMove)
        {
            _rigidbody2D.velocity = new Vector2(-GameManager.xSpeed, 0);
            _collider2Ds[0].enabled = true;
            _collider2Ds[1].enabled = true;
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
            _collider2Ds[0].enabled = false;
            _collider2Ds[1].enabled = false;

        }
    }
}
