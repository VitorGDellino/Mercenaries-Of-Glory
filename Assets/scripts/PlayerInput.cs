using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInput : MonoBehaviour{

    public int nPlayer;
    public abstract bool GetDash();
    public abstract bool GetJump();
    public abstract bool GetSkill1();
    public abstract bool GetSkill2();
    public abstract bool GetSkill3();
    public abstract bool GetAttack();

    public abstract float GetHorizontal();
    public abstract float GetVertical();

}