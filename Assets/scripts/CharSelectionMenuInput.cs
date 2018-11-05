using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharSelectionMenuInput : MonoBehaviour{
    public x360_GamePadMenu inputMenu;
    public int player;

    private bool startTrigger;
    private bool leftTrigger;
    private bool rightTrigger;
    private bool submitTrigger;
    private bool backTrigger; 

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update(){
        startTrigger = !InputManager.GetMenuButton(player, InputManager.menu.START) || startTrigger;
        leftTrigger = !InputManager.GetMenuButton(player, InputManager.menu.LEFT) || leftTrigger;
        rightTrigger = !InputManager.GetMenuButton(player, InputManager.menu.RIGHT) || rightTrigger;
        submitTrigger = !InputManager.GetMenuButton(player, InputManager.menu.SUBMIT) || submitTrigger;
        backTrigger = !InputManager.GetMenuButton(player, InputManager.menu.BACK) || backTrigger;
    }

    public bool GetStart(){
        if(startTrigger && InputManager.GetMenuButton(player, InputManager.menu.START)){
            startTrigger = false;
            return true;
        }

        return false;

    }

    public bool GetLeft(){
        if(leftTrigger && InputManager.GetMenuButton(player, InputManager.menu.LEFT)){
            leftTrigger = false;
            return true;
        }

        return false;
    }

    public bool GetRight(){
        if(rightTrigger && InputManager.GetMenuButton(player, InputManager.menu.RIGHT)){
            rightTrigger = false;
            return true;
        }

        return false;
    }

    public bool GetSubmit(){
        if(submitTrigger && InputManager.GetMenuButton(player, InputManager.menu.SUBMIT)){
            submitTrigger = false;
            return true;
        }

        return false;
    }

    public bool GetBack(){
        if(backTrigger && InputManager.GetMenuButton(player, InputManager.menu.BACK)){
            backTrigger = false;
            return true;
        }

        return false;
    }
    

}