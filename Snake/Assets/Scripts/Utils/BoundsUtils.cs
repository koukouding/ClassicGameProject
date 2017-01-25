using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 获取Transform相关的sprite、Collider大小
/// </summary>
public class BoundsUtils : MonoBehaviour {


    public static Vector3 GetSpriteSize(Transform spriteTransform)
    {
        Sprite renderer = spriteTransform.GetComponent<SpriteRenderer>().sprite;
        return renderer.bounds.size;
    }

    public static Vector3 Get2DColliderSize(Transform colliderTransform)
    {
        var collider  = colliderTransform.GetComponent<Collider2D>();
        return collider.bounds.size;
    }
    public static Vector3 GetColliderSize(Transform colliderTransform)
    {
        var collider = colliderTransform.GetComponent<Collider>();
        return collider.bounds.size;
    }
}
