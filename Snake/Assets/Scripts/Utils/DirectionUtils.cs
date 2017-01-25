using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionUtils : MonoBehaviour {


    public static Vector3 CalTurnAngle(Vector2 fromDir, Vector2 toDir)
    {
        Quaternion r = Quaternion.FromToRotation(fromDir, toDir);
        return r.eulerAngles;
    }

    //使用示例
    //void TurnToDirection(Vector2 currentDir, Vector2 inputVect2, Transform node)
    //{

    //    Vector3 angle = CalTurnAngle(currentDir, inputVect2);
    //    node.Rotate(angle);
    //}
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

}
