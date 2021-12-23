using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GAME_STATE
{
    MAIN_MENU = 0,
    PLAY_MODE = 1,
    GAME_WON = 2,
    GAME_OVER = 3
}

[CreateAssetMenu(fileName = "GameStateBase", menuName = "GameStatesObject", order = 2)]
public class GameStatesObject : ScriptableObject
{
    public GAME_STATE game_state = GAME_STATE.MAIN_MENU;
    public float timer = 0f;


    public GameObject last_ui_state;
    public GameObject current_ui_state;

    public void ResetGameState()
    {
        game_state = GAME_STATE.MAIN_MENU;
        timer = 0f;
    }

    /// <summary>
    /// UI/Canvas object to activate
    /// </summary>
    /// <param name="state_object"></param>
    public void setUIState(GameObject state_object)
    {
        last_ui_state = current_ui_state;
        current_ui_state = state_object;

        last_ui_state.SetActive(false);
        current_ui_state.SetActive(true);
    }
}
