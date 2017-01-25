using UnityEngine;
using System.Collections;

public enum Movement
{
    LEFT,
    RIGHT,
    UP,
    DOWN,
    NONE
}

public class InputHandler : Singleton<InputHandler> {
    float h, v;
   Movement currentInput=Movement.NONE;

	// Update is called once per frame
	void Update ()
    {
        currentInput = Movement.NONE;
      h = Input.GetAxisRaw("Horizontal");
      v = Input.GetAxisRaw("Vertical");
        //只有在h,v中只有一个有值的时候有效
        float i = h + v;
       // Debug.Log(h+" "+v+"　"+i);
        if (i <= 1 || i >= -1)
        {
            if (i != 0)
            {
                if (h == 0)
                    currentInput = applyAxisWithMovement(v, false);
                else
                    currentInput = applyAxisWithMovement(h, true);

            }
        }
    }

    Movement applyAxisWithMovement(float axis,bool isHorizental)
    {
        if (isHorizental)
        {
            if (axis > 0)
                return Movement.RIGHT;
            else
                return Movement.LEFT;
        }
        else
        {
            if (axis > 0)
                return Movement.UP;
            else
                return Movement.DOWN;
        }
    }
    public Movement GetCurrentInput()
    {
        return currentInput;
    }
    public Vector2 TransMoveToVetor2(Movement dir)
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

}
