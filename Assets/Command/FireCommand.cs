using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCommand : Command
{
    public override void Execute(Actor actor)
    {
        Player player = actor as Player;
        if (player != null)
        {
            player.Fire();
        }
    }

}
