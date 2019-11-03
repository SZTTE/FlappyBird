using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Screen.SetResolution((int)(286*1.5),(int)(512*1.5),false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
