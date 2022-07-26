using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    public Player(GameObject obj) : base(obj)
    {

    }

    public void Jump()
    {
        Debug.Log("player jump");
    }
    public void Fire()
    {
        Debug.Log("player fire");
    }

    public void MoveForward()
    {
        if (this.obj != null)
        {
            var pos = this.obj.transform.position;
            this.obj.transform.position = new Vector3(pos.x, pos.y, pos.z + 1);
        }
    }

}
