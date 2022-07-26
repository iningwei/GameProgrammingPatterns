using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandLogic : MonoBehaviour
{
    InputHandler inputHandler;

    Player player;

    [SerializeField]
    public  List<Command> moveCmdList;
    int moveCmdIndex = -1;

    void Start()
    {
        player = new Player(this.gameObject);
        inputHandler = new InputHandler();
        moveCmdList = new List<Command>();
    }

    void Update()
    {
        Command cmd = inputHandler.HandleInput();
        if (cmd != null)
        {
            cmd.Execute(player);

            if (cmd is MoveForwardCommand)
            {
                moveCmdList.Add(cmd);
                moveCmdIndex = moveCmdList.Count - 1;
            }
            else
            {
                if (moveCmdList != null)
                {
                    moveCmdList = null;
                    moveCmdList = new List<Command>();
                    moveCmdIndex = -1;
                }
            }



        }


        //  undo and redo
        //编辑器下ctrl+z和ctrl+shift+z 和编辑器自己冲突，不利于调试
        //故用其它键进行调试
        //if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
        if (Input.GetKey(KeyCode.RightShift)&&Input.GetKeyDown(KeyCode.Z))
        {
            //Debug.Log("left ctrl+z");
            if (moveCmdList != null && moveCmdIndex >= 0 && moveCmdIndex < moveCmdList.Count)
            { 
                moveCmdList[moveCmdIndex].Undo();
                moveCmdIndex--;
            }
        }
        //if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Z))
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Z))
        {
            //Debug.Log("left ctrl+shift+z");
            if (moveCmdList != null && moveCmdIndex < moveCmdList.Count - 1)
            {
                moveCmdIndex++;
                moveCmdList[moveCmdIndex].Redo();
               
            }
        }
    }
}
