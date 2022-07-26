using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    public Command HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            return new JumpCommand(); ;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            return new FireCommand();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            return new MoveForwardCommand();
        }


        return null;
    }
}
