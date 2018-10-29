using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class x360_GamepadInput : PlayerInput{

    private bool dashTrigger = false;
    private bool jumpTrigger = false;
    private bool attackTrigger = false;

    public void Update(){ 
        // reset triggers when button released
        dashTrigger   = !InputManager.GetButton(nPlayer, InputManager.button.DASH) || dashTrigger;
        jumpTrigger   = !InputManager.GetButton(nPlayer, InputManager.button.JUMP) || jumpTrigger;
        attackTrigger = !InputManager.GetButton(nPlayer, InputManager.button.ATTACK) || attackTrigger;
    }

    override public bool GetDash(){
        if (dashTrigger && InputManager.GetButton(nPlayer, InputManager.button.DASH)){
            dashTrigger = false;
            return true;
        }

        return false;
    }

    override public bool GetJump(){
        Debug.Log(jumpTrigger);
        if (jumpTrigger && InputManager.GetButton(nPlayer, InputManager.button.JUMP)){
            jumpTrigger = false;
            return true;
        }

        return false;
    }

    override public bool GetAttack(){
        if (attackTrigger && InputManager.GetButton(nPlayer, InputManager.button.ATTACK)){
            attackTrigger = false;
            return true;
        }

        return false;
    }

    override public bool GetSkill1(){
        return false;
    }

    override public bool GetSkill2(){return false;}

    override public bool GetSkill3(){return false;}

    override public float GetHorizontal(){
        return InputManager.GetAxis(nPlayer, InputManager.axis.HORIZONTAL);
    }

    override public float GetVertical(){
        return InputManager.GetAxis(nPlayer, InputManager.axis.VERTICAL);
    }
}