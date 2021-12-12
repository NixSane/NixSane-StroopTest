using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public GameManagerScript game_manager;
    ButtonFunctionTemplates button_functions;

    /// <summary>
    /// Set the current game state to Play_Mode
    /// </summary>
    public void SetToPlay()
    {
        GameManagerScript.game_state = GAME_STATE.PLAY_MODE;
        GameManagerScript.timer = 0f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetRed()
    {
        game_manager.ColorPicked = COLOR.RED;
    }

    public void SetBlue()
    {
        game_manager.ColorPicked = COLOR.BLUE;
    }

    public void SetYellow()
    {
        game_manager.ColorPicked = COLOR.YELLOW;
    }

    public void SetGreen()
    {
        game_manager.ColorPicked = COLOR.GREEN;
    }
}
