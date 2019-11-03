using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{

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

    }

    // Update is called once per frame
    void Update()
    {

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
            PlayerPrefs.Save();
        }
        
        //在封面场景中
        if (GameManager.Instance == null)
        {
            SceneManager.LoadScene("PlaySceneScene");
            pushable = false;
        }
    }
}
