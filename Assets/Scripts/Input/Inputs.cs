using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Inputs
{
    private static PlayerInput _actions;
    private static GameController _owner;

    public static void Init(GameController gameController)
    {
        _actions = new PlayerInput();

        _owner = gameController;

        _actions.GameControls.Pause.performed += ctx => _owner.Pause();
        _actions.GameControls.Test.performed += ctx => _owner.Test();
        _actions.GameControls.Roll.performed += ctx => _owner.Roll();

        PlayMode();
    }

    public static void PlayMode()
    {
        _actions.GameControls.Enable();
    }


}
