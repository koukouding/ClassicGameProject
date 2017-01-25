using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveController : MonoBehaviour {
    Movement currentInput;
    private Vector2 _currentDir;
    public Vector2 currentDir
    {
        get { return _currentDir; }
    }
    [HideInInspector]
    public float speed=0f;
   // public float spriteSize=1.4f;
    private Rigidbody2D _rigidBody2D;

    void Start ()
    {
        _currentDir = Vector2.up;
        currentInput = Movement.NONE;
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }
	
    void Update()
    {
        Move();
        _currentDir = transform.up;
      
    }

    Vector2 TransMoveToVetor2(Movement dir)
    {
        switch (dir)
        {
            case Movement.UP:
                return Vector2.up;
            case Movement.DOWN:
                return Vector2.down;
            case Movement.LEFT:
                return Vector2.left;
            case Movement.RIGHT:
                return Vector2.right;
            case Movement.NONE:
                return Vector2.zero;

        }
        return Vector2.zero;
    }



    /// <summary>
    //协程模式实现
    //朝着Y轴方向运动
    /// </summary>
    //IEnumerator 
    void Move()
    {
       transform.position += (speed* Time.deltaTime) * transform.up;
    }
    public Vector2 GetVelocity()
    {
        return _rigidBody2D.velocity;
    }

    public float getSpeed()
    {
        return (_rigidBody2D.velocity.x != 0) ? _rigidBody2D.velocity.x : _rigidBody2D.velocity.y;
    }
    public void Turn(Vector3 angle)
    {
        transform.Rotate(angle);
    }

    public void setSpeed(float v)
    {
        speed = v;
    }
}
