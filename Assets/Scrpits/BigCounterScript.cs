using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCounterScript : MonoBehaviour
{
    public Sprite[] bigNumSprites;
    public SpriteRenderer[] bigNumRenderers;
    private Transform[] bigNumTransforms = new Transform[20];
    public GameObject bigNumOringin;
    public static BigCounterScript instance;
    
    public void Print(int numberToPrint)
    {
        //获取待打印数的位数
        int numberOfFigure = 0;
        int temp = numberToPrint;
        while (temp!=0)
        {
            numberOfFigure++;
            temp /= 10;
        }
        
        
        //排列数字容器
        float xPositionForNextNumber = (float) -0.125 * (numberOfFigure - 1);
        for (int i = 0; i <= numberOfFigure - 1; i++)//（10^i）是第i位数字容器的显示位数
        {
            bigNumTransforms[i].localPosition = new Vector3(xPositionForNextNumber,0,0);
            xPositionForNextNumber += 0.23f;
        }
        
        //让容器显示正确的数字
        for (int i = 0; i <= numberOfFigure - 1; i++)//（10^i）是第i位数字容器的显示位数
        {
            int number = numberToPrint;
            number /= (int) Math.Pow(10 , numberOfFigure-1-i);
            number %= 10;
            bigNumRenderers[i].sprite = bigNumSprites[number];
            
        }
        
        //特殊情况：打印0
        if (numberToPrint == 0)
        {
            bigNumTransforms[0].localPosition = Vector3.zero;
            bigNumRenderers[0].sprite = bigNumSprites[0];
        }
    }

    public void Disappear()
    {
        for (int i = 0; i < 20; i++)//（10^i）是第i位数字容器的显示位数
        {
            bigNumTransforms[i].localPosition = new Vector3(0,0,-100);
        }
    }


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bigNumRenderers = new SpriteRenderer[20];
        bigNumTransforms = new Transform[20];
        bigNumRenderers[0] = gameObject.GetComponentInChildren<SpriteRenderer>();
        bigNumTransforms[0] = transform.Find("BigNumber");
        GameObject[] numbers = new GameObject[20];
        for (int i = 1; i < 20; i++)
        {
            numbers[i] = Instantiate(bigNumOringin);
            bigNumRenderers[i] = numbers[i].GetComponentInChildren<SpriteRenderer>();
            bigNumTransforms[i] = numbers[i].GetComponentInChildren<Transform>();
            bigNumTransforms[i].parent = gameObject.GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
