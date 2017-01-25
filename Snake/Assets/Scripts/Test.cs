using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("shit", 0.3f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void shit()
    {
        StartCoroutine(coroutine());
    }

    IEnumerator coroutine()
    {
        Debug.Log("开始："+Time.realtimeSinceStartup);
        yield return new WaitForSeconds(2f);
        Debug.Log("结束:"+ Time.realtimeSinceStartup);
    }
}
