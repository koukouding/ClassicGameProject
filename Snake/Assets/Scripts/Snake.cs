using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {

    public GameObject tailPrefab;
    public GameObject food;
    public Transform rBorder;
    public Transform lBorder;
    public Transform tBorder;
    public Transform bBorder;
    public ScreenEdgeDetect edgeDetect;
    private float speed = 0.1f;

    Vector2 vector = Vector2.up;
    Vector2 moveVector;

    public List<Transform> tail = new List<Transform>();

    bool eat = false;
    bool vertical = false;
    bool horizontal = true;

    void Start() {
        
        InvokeRepeating("Movement", 0.3f, speed);
        InvokeRepeating("UpdateInput", 0.3f, speed);

    }

    void Update() {

        if (IfOutOfBorder())
        {
            Debug.Log("You Dead");
        }
    }

    void UpdateInput()
    {
        Vector2 lastVector = vector;
        if (Input.GetKey(KeyCode.RightArrow) && horizontal)
        {
            horizontal = false;
            vertical = true;
            vector = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.UpArrow) && vertical)
        {
            horizontal = true;
            vertical = false;
            vector = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && vertical)
        {
            horizontal = true;
            vertical = false;
            vector = -Vector2.up;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && horizontal)
        {
            horizontal = false;
            vertical = true;
            vector = -Vector2.right;
        }
        moveVector = vector * 0.17f * 10;
    }


    void Movement() {

        Vector2 ta = transform.position;
        transform.Translate(moveVector);
        if (eat) {
            if (speed > 0.002) {
                speed = speed - 0.002f;
            }
            GameObject g = (GameObject)Instantiate(tailPrefab, ta, Quaternion.identity);

            tail.Insert(0, g.transform);
            Debug.Log(speed);
            eat = false;
        }
        else if (tail.Count > 0) {
            tail.Last().position = ta;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
        
    }

    void OnTriggerEnter2D(Collider2D c) {

        if (c.name.StartsWith("food")) {
        eat = true;
        Destroy(c.gameObject);
        }
        else {
            if(c.transform!=tail[0])
            Debug.Log("Dead by:"+c.name);
        }
    }

    bool IfOutOfBorder()
    {
        if (edgeDetect.ifOutOfX || edgeDetect.ifOutOfY)
            return true;
        else
        {
            return false;
        }

    }
}
