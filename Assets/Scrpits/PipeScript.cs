using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public GameObject pipeOringin;
    public Sprite redPipeUp;
    public Sprite redPipeDown;
    public bool ShouldMove = true;
    private Transform _transform;
    private Rigidbody2D _rigidbody2D;
    private Collider2D[] _collider2Ds;
    private SpriteRenderer[] _pipeRenderers;

    public double XPosition
    {
        get => _transform.position.x;
    }

    public void ResetPosition()
    {
        _transform.Translate(Vector3.right*(float) (2 * 3.3563));
        _transform.position = new Vector3(1.72f,-0.01f);
        _transform.Translate(Vector3.up * 1.96f * Random.value);
    }

// Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2Ds = GetComponentsInChildren<Collider2D>();
        _pipeRenderers = GetComponentsInChildren<SpriteRenderer>();
        
        //设置速度为公用速度
        _rigidbody2D.velocity = new Vector2(-GameManager.xSpeed,0);
        
        //设置随机y坐标0.52-2.48
        _transform.Translate(Vector3.up * 1.96f * Random.value);
        
        if (PipesManager.instance.pipeIsRed)
        {
            _pipeRenderers[0].sprite = redPipeUp;
            _pipeRenderers[1].sprite = redPipeDown;
        }
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
