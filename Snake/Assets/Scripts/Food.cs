using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Singleton<Food>
{
    Vector3 stageDimensions ;
   public GameObject foodPrefab;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn",0.3f,3);
        stageDimensions =Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawn()
    {
        float x = Random.Range(-stageDimensions.x, stageDimensions.x);
        float y = Random.Range(-stageDimensions.y,stageDimensions.y);
        //Debug.Log(x+" "+y);
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }

}
