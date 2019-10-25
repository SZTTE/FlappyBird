using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScript : MonoBehaviour
{

    public Sprite dayPicture;
    public Sprite nightPicture;
    private SpriteRenderer _spriteRenderer;
    public static SkyScript instance;

    public void ResetTime()
    {
        if (Random.value >= 0.5)
            _spriteRenderer.sprite = dayPicture;
        else
            _spriteRenderer.sprite = nightPicture;
    }

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
