using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class x360_GamePadMenu : MonoBehaviour{

    private bool backTrigger = false;
    private bool leftTrigger = false;
    private bool rightTrigger = false;
    private bool okTrigger = false;

    void Update(){ 
        backTrigger  = !InputManager.GetMenuButton(InputManager.menu.BACK) || backTrigger;
        okTrigger   = !InputManager.GetMenuButton(InputManager.menu.SUBMIT) || okTrigger;
        leftTrigger = !InputManager.GetMenuButton(InputManager.menu.LEFT) || leftTrigger;
        rightTrigger = !InputManager.GetMenuButton(InputManager.menu.RIGHT) || rightTrigger;
    }

    public bool GetBack(){
        if (backTrigger && InputManager.GetMenuButton(InputManager.menu.BACK)){
            backTrigger = false;
            return true;
        }

        return false;
    }

    public bool GetSubmit(){
        if (okTrigger && InputManager.GetMenuButton(InputManager.menu.SUBMIT)){
            okTrigger = false;
            return true;
        }

        return false;
    }

    public bool GetLeft(){
        if (leftTrigger && InputManager.GetMenuButton(InputManager.menu.LEFT)){
            Debug.Log("nao era pra entrar aqui");
            leftTrigger = false;
            return true;
        }

        return false;
    }

    public bool GetRight(){
        if (rightTrigger && InputManager.GetMenuButton(InputManager.menu.RIGHT)){
            rightTrigger = false;
            return true;
        }

        return false;
    }

}