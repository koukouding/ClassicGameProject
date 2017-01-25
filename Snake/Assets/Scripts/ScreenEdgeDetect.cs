using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEdgeDetect : MonoBehaviour {

    public Transform target;
    Vector3 stageDimensions;
    private bool outOfX;
    private bool outOfY;
    public  bool ifOutOfX
    {
        get { return outOfX; }
       private set { outOfX = value; }
    }
    public   bool ifOutOfY
    {
        get { return outOfY; }
        private set { outOfY = value; }
    }

    void Start()
    {
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

    }

    // Update is called once per frame
	void Update ()
    {
        if (target.position.x > stageDimensions.x || target.position.x < -stageDimensions.x)
        {
            ifOutOfX = true;
        }
        else
        {
            ifOutOfX = false;
        }
        if (target.position.y > stageDimensions.y || target.position.y < -stageDimensions.y)
        {
            ifOutOfY = true; 
            //Debug.Log("YYYOops");
        }
        else
        {
            ifOutOfY = false;
        }
	}

}
