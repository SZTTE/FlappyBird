using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float xSpeed;
    private int score = 0;

    public void ScoreAdd()
    {
        score++; 
        Debug.Log("Score = "+score);
    }

    //------------------------------------------------------------------------------------------------------------------事件函数
    void Awake()
    {
        if (Instance == null) Instance = this;//确保场上只有一个实例存在，并且接收类的记录
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SkyScript.instance.ResetTime();
        BirdScript.Instance.GotoBeginPosition();
        PipesManager.instance.Stop();
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && BirdScript.Instance.state == BirdScript.BirdState.SelfControl) //如果按下鼠标，鸟切换为玩家控制
        {
            BirdScript.Instance.LetPlayerControl();
            GameObject.Find("GetReadyUI").GetComponent<Animator>().SetTrigger("fade");
            PipesManager.instance.Move();
        }
        if (Input.GetMouseButtonDown(0))//for test
        {
            
        }

    }
}
