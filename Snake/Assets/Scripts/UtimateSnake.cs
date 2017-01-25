using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtimateSnake : MonoBehaviour {
    public List<Transform> tail = new List<Transform>();
    public float spriteSize = 1.4f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float speed = 2.0f * Time.deltaTime;

        // move the head to its target location 
        tail[0].transform.localPosition = Vector2.MoveTowards(tail[0].transform.localPosition, tail[0].transform.localPosition + tail[0].transform.up*spriteSize, speed);

        // move last tile to its target position 
        if (tail.Count > 0)
        {
            int last = tail.Count - 1;
            tail[last].transform.localPosition = Vector2.MoveTowards(
                     tail[last].transform.localPosition, tail[last].transform.localPosition + tail[last].transform.up * spriteSize, speed);
        }
    }
}
