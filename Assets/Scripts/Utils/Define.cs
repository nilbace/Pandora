using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        SpeedRunScene,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }
    public enum UIEvent
    {
        Click,
        Drag,
        
    }
    public enum MouseEvent{
        Press,
        Click,
    }
    public enum CameraMode{
        QuaterView,
    }
}
