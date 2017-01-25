using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 负责管理蛇头以后的节点的生成
/// 和运动
/// </summary>
public class SnakeMannager : Singleton<SnakeMannager> {
    #region PUBLIC_VARIABLES

    public Transform head;
    public int initTailCount=3;
    public float spriteSize = 1.4f;
    public Transform tailNodePrefab;
    [SerializeField]
    private float _speed = 1f;
    #endregion

    Vector2 headDir;
     List<Transform> body = new List<Transform>();
    Movement currentInput;
    float gapTime;

    void Start ()
    {
        currentInput = InputHandler.Instance.GetCurrentInput();
        gapTime = spriteSize / _speed;
        InvokeRepeating("UpdateSnakeHead", 0.3f, gapTime);
        Initialize();
        
    }

    void Initialize()
    {
        body.Add(head);
        head.GetComponent<MoveController>().speed = _speed;
        Vector3 pos = head.position;

        for (int i = 0; i < initTailCount; i++)
        {
            AddTailNode();
            
        }
    }

    bool IfTurn()
    {
        Vector3 latestPos = head.position;
        headDir = head.up;
        //需要转向
        if (currentInput != Movement.NONE)
        {
            Vector2 inputVect2 = InputHandler.Instance.TransMoveToVetor2(currentInput);
            //如果满足Turn条件
            if (!(headDir == inputVect2 || headDir == -inputVect2))
            {
                return true;
            }
        }
        return false;
    }
 
    void AddTailNode()
    {        
        Transform lastTransform= body[body.Count - 1];
        Vector3 pos = lastTransform.position- lastTransform.up*spriteSize;
        Transform g = Instantiate(tailNodePrefab, pos, lastTransform.rotation);
        body.Add(g);
        g.GetComponent<MoveController>().speed = _speed;

    }
    IEnumerator StartTurn(Vector3 angle)
    {
        Vector3 turnPoint = head.position;
        for (int i = 1; i < body.Count; i++)
        {
            yield return new WaitForSeconds(gapTime);
            body[i].position = turnPoint;
            body[i].GetComponent<MoveController>().Turn(angle);
        }
    }

    void UpdateSnakeHead()
    {
        currentInput = InputHandler.Instance.GetCurrentInput();
       
        if (IfTurn())
        {
            Vector3 turnAngle = DirectionUtils.CalTurnAngle(headDir, InputHandler.Instance.TransMoveToVetor2(currentInput));
            head.GetComponent<MoveController>().Turn(turnAngle);
            Vector3 turnPoint = head.position;
            StartCoroutine(StartTurn(turnAngle));
        }
    }

  
} 
