using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesManager : MonoBehaviour
{

    private PipeScript[] pipes;//从左到右分别是0到3号管子
    private Transform _transform;
    public static PipesManager instance;
    //------------------------------------------------------------------------------------------------------------公共函数
    public void Stop()
    {
        for (int i = 0; i <= 3; i++)
            pipes[i].ShouldMove = false;
    }

    public void Move()
    {
        for (int i = 0; i <= 3; i++)
            pipes[i].ShouldMove = true;
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        
        _transform = GetComponent<Transform>();
        pipes = GetComponentsInChildren<PipeScript>();//获取子对象里的所有脚本
        Debug.Log(pipes[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (pipes[0].XPosition <= -5) //要是第一个管子离开屏幕，就把他移动到第三个管子后面，并且重排管子数组
        {
            pipes[0].ResetPosition();
            var temp = pipes[0];
            pipes[0] = pipes[1];
            pipes[1] = pipes[2];
            pipes[2] = pipes[3];
            pipes[3] = temp;

        }
    }
}
