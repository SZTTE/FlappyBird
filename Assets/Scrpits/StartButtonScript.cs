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

    void EnterNextScene()
    {
        SceneManager.LoadScene("PlaySceneScene");
    }

    void ResetBird()
    {
        BirdScript.Instance.ResetBird();
    }

    private void OnMouseDown()
    {
        //在游戏场景中
        if (pushable && GameManager.Instance != null)
        {
            WhiteScript.instance.GetComponent<Animator>().SetTrigger("BlackFlash");
            Invoke("EnterNextScene",0.5f);//零点五秒后才切换场景
            Invoke("ResetBird",0.5f);
            Input.ResetInputAxes();
            pushable = false;
            PlayerPrefs.Save();
        }
        
        //在封面场景中
        if (GameManager.Instance == null)
        {
            WhiteScript.instance.GetComponent<Animator>().SetTrigger("BlackFlash");
            Invoke("EnterNextScene",0.5f);
            pushable = false;
        }
    }
}
