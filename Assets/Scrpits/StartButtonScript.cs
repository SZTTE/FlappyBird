using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    private TextMesh scoreText;
    private TextMesh bestText;
    
    public static StartButtonScript instance;
    public bool pushable = false;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<TextMesh>();
        bestText = GameObject.Find("Best").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameManager.Instance.score.ToString();
    }
    
    private void OnMouseDown()
    {
        //在游戏场景中
        if (pushable && GameManager.Instance != null)
        {
            Input.ResetInputAxes();
            SceneManager.LoadScene("PlaySceneScene");
            pushable = false;
            BirdScript.Instance.ResetBird();
        }
        
        //在封面场景中
        if (GameManager.Instance == null)
        {
            SceneManager.LoadScene("PlaySceneScene");
            pushable = false;
        }
    }
}
