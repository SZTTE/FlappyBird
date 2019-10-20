using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public GameObject pipeOringin;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //x坐标自减xspeed
        _transform.Translate(new Vector3(- GameObject.Find("YB").GetComponent<BirdScript>().xSpeed,0));
        if (_transform.position.x <= -5)
        {
            Vector3 positionForNewPipe = _transform.position;
            positionForNewPipe.x += (float) (2 * 3.3563);
            GameObject pipe = Instantiate(pipeOringin, positionForNewPipe, Quaternion.identity);
            Debug.Log("runToHere");
            Destroy(gameObject);
            
        }
    }
}
