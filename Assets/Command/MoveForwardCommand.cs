using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class MoveForwardCommand : MoveCommand
{

    public override void Execute(Actor actor)
    {
        player = actor as Player;

        if (player != null)
        {
            pos = player.obj.transform.position;
            player.obj.transform.position = new Vector3(pos.x, pos.y, pos.z + 1);
        }
    }

    public override void Undo()
    {
        if (player != null)
        {
            Debug.Log("undo move forward");
            player.obj.transform.position = pos;
        }

    }

    public override void Redo()
    {
        if (player != null)
        {
            Debug.Log("redo move forward");
            player.obj.transform.position = new Vector3(pos.x, pos.y, pos.z + 1);
        }
    }


}
