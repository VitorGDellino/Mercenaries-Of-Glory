using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class x360_GamepadInput : PlayerInput{

    private bool dashTrigger = false;
    private bool jumpTrigger = false;
    private bool attackTrigger = false;
    private bool skill1Trigger = false;
    private bool skill2Trigger = false;
    private bool skill3Trigger = false;


    public void Update(){ 
        // reset triggers when button released
        dashTrigger   = !InputManager.GetButton(nPlayer, InputManager.button.DASH) || dashTrigger;
        jumpTrigger   = !InputManager.GetButton(nPlayer, InputManager.button.JUMP) || jumpTrigger;
        attackTrigger = !InputManager.GetButton(nPlayer, InputManager.button.ATTACK) || attackTrigger;
        skill1Trigger = !InputManager.GetButton(nPlayer, InputManager.button.SKILL1) || skill1Trigger;
        skill2Trigger = !InputManager.GetButton(nPlayer, InputManager.button.SKILL2) || skill2Trigger;
        skill3Trigger = !InputManager.GetButton(nPlayer, InputManager.button.SKILL3) || skill3Trigger;
    }

    override public bool GetDash(){
        if (dashTrigger && InputManager.GetButton(nPlayer, InputManager.button.DASH)){
            dashTrigger = false;
            return true;
        }

        return false;
    }

    override public bool GetJump(){
        //Debug.Log(jumpTrigger);
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
        if (skill1Trigger && InputManager.GetButton(nPlayer, InputManager.button.SKILL1)){
            skill1Trigger = false;
            return true;
        }

        return false;
    }

    override public bool GetSkill2(){
        if (skill2Trigger && InputManager.GetButton(nPlayer, InputManager.button.SKILL2)){
            skill2Trigger = false;
            return true;
        }
        return false;
    }

    override public bool GetSkill3(){
        if (skill2Trigger && InputManager.GetButton(nPlayer, InputManager.button.SKILL2)){
            skill2Trigger = false;
            return true;
        }

        return false;
    }

    override public float GetHorizontal(){
        return InputManager.GetAxis(nPlayer, InputManager.axis.HORIZONTAL);
    }

    override public float GetVertical(){
        return InputManager.GetAxis(nPlayer, InputManager.axis.VERTICAL);
    }
}