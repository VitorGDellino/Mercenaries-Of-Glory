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
        BACK,
        PAUSE,
        LEFT,
        RIGHT,
        UP,
        DOWN,
        START
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

    public xboxButton submitButton;
    public xboxButton backButton;
    public xboxButton leftButton;
    public xboxButton rightButton;
    public xboxButton downButton;
    public xboxButton upButton;
    public xboxButton startButton;

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
    
    public static bool GetMenuButton(menu _button){

        bool pressed = false;

        for(int i = 0; i < 4; i++){

            GamePadState state = GamePad.GetState((PlayerIndex) (i));

            switch(_button){
                case menu.SUBMIT:
                    pressed |= GetButton(state, instance.submitButton);
                    break;
                case menu.BACK:
                    pressed |= GetButton(state, instance.backButton);
                    break;
                case menu.LEFT:
                    pressed |= GetButton(state, instance.leftButton)  || state.ThumbSticks.Left.X < -instance.triggMinRatio;
                    break;
                case menu.RIGHT:
                    pressed |= GetButton(state, instance.rightButton) || state.ThumbSticks.Left.X > instance.triggMinRatio;;
                    break;
                case menu.UP:
                    pressed |= GetButton(state, instance.upButton) || state.ThumbSticks.Left.Y > instance.triggMinRatio;;
                    break;
                case menu.DOWN:
                    pressed |= GetButton(state, instance.downButton) || state.ThumbSticks.Left.Y < -instance.triggMinRatio;;
                    break;
            }
        }

        return pressed;
    }

     public static bool GetMenuButton(int player, menu _button){

        bool pressed = false;
        if(player < 0 || player >= 4){
            return false;
        }

        GamePadState state = GamePad.GetState((PlayerIndex) (player -1));

        switch(_button){
            case menu.SUBMIT:
                pressed |= GetButton(state, instance.submitButton);
                break;
            case menu.BACK:
                pressed |= GetButton(state, instance.backButton);
                break;
            case menu.LEFT:
                pressed |= GetButton(state, instance.leftButton)  || state.ThumbSticks.Left.X < -instance.triggMinRatio;
                break;
            case menu.RIGHT:
                pressed |= GetButton(state, instance.rightButton) || state.ThumbSticks.Left.X > instance.triggMinRatio;;
                break;
            case menu.UP:
                pressed |= GetButton(state, instance.upButton) || state.ThumbSticks.Left.Y > instance.triggMinRatio;;
                break;
            case menu.DOWN:
                pressed |= GetButton(state, instance.downButton) || state.ThumbSticks.Left.Y < -instance.triggMinRatio;;
                break; 
            case menu.START:
                pressed |= GetButton(state, instance.startButton); 
                break;
        }

        return pressed;
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

        GamePadState state = GamePad.GetState((PlayerIndex) (player - 1));

        switch(_axis){
            case axis.HORIZONTAL:
                return state.ThumbSticks.Left.X;
            case axis.VERTICAL:
                return state.ThumbSticks.Left.Y;
        }

        return 0f;
    }

    private static bool GetButton(GamePadState state, xboxButton _button){

        switch(_button){

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