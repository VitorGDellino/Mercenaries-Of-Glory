using UnityEngine;
using XInputDotNetPure;


public class InputManager : MonoBehaviour{

    public enum axis{
        HORIZONTAL,
        VERTICAL
    }

    public enum button{
        DASH,
        JUMP,
        ATTACK,
        SKILL1,
        SKILL2,
        SKILL3
    }

    public enum menu{
        SUBMIT,
        PREVIOUS,
        PAUSE,
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    public enum xboxButton{
        A,
        B,
        X,
        Y,
        DPAD_LEFT,
        DPAD_RIGHT,
        DPAD_UP,
        DPAD_DOWN,
        START,
        BACK,
        BUMPR_LEFT,
        TRIGG_LEFT,
        STICK_LEFT,
        BUMPR_RIGHT,
        TRIGG_RIGHT,
        STICK_RIGHT
    }

    public float triggMinRatio = .3f;
    public bool pcDebugMode = false;

    public xboxButton dashButtonR;
    public xboxButton dashButtonL;
    public xboxButton jumpButton;
    public xboxButton attackButton;
    public xboxButton skill1Button;
    public xboxButton skill2Button;
    public xboxButton skill3Button;

    public static InputManager instance;

     void Awake(){
        MakeSingleton();
    }
    
    private void MakeSingleton(){
        if(instance != null){
            Destroy(gameObject);
        }else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static bool GetButton(int player, button _button){
        if(player <= 0 || player > 4){
            return false;
        }

        GamePadState state = GamePad.GetState((PlayerIndex) (player - 1));

        switch(_button){

            case button.DASH:
                return GetButton(state, instance.dashButtonR) ||  GetButton(state, instance.dashButtonL);
            case button.JUMP:
                return GetButton(state, instance.jumpButton);
            case button.ATTACK:
                return GetButton(state, instance.attackButton);
            case button.SKILL1:
                return GetButton(state, instance.skill1Button);
            case button.SKILL2:
                return GetButton(state, instance.skill2Button);
            case button.SKILL3:
                return GetButton(state, instance.skill3Button);
        }

        return false;

    }

    public static float GetAxis(int player, axis _axis){
        if(player <= 0 || player > 4){
            return 0f;
        }

        GamePadState state = GamePad.GetState((PlayerIndex) (player -1));

        switch(_axis){
            case axis.HORIZONTAL:
                return state.ThumbSticks.Left.X;
            case axis.VERTICAL:
                return state.ThumbSticks.Left.Y;
        }

        return 0f;
    }

    private static bool GetButton(GamePadState state, xboxButton button){

        switch(button){

            case xboxButton.TRIGG_LEFT:
                return state.Triggers.Left > instance.triggMinRatio;
            case xboxButton.TRIGG_RIGHT:
                return state.Triggers.Right > instance.triggMinRatio;
            case xboxButton.A:
                return state.Buttons.A == ButtonState.Pressed;
            case xboxButton.B:
                return state.Buttons.B == ButtonState.Pressed;
            case xboxButton.Y:
                return state.Buttons.Y == ButtonState.Pressed;
            case xboxButton.X:
                return state.Buttons.X == ButtonState.Pressed;
            case xboxButton.START:
                return state.Buttons.Start == ButtonState.Pressed;
            case xboxButton.BACK:
                return state.Buttons.Guide == ButtonState.Pressed;
            case xboxButton.DPAD_UP:
                return state.DPad.Up == ButtonState.Pressed;
            case xboxButton.DPAD_DOWN:
                return state.DPad.Down == ButtonState.Pressed;
            case xboxButton.DPAD_LEFT:
                return state.DPad.Left == ButtonState.Pressed;
            case xboxButton.DPAD_RIGHT:
                return state.DPad.Right == ButtonState.Pressed;

        }

        return false;

    }

}