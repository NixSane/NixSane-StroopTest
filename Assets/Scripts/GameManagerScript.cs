/* GameManagerScript
 * 
 * Purpose: Track and set state of the game. Communicate with UI canvases
 * and contain all static variables (e.g. timer, state)
 * 
 */

using UnityEngine;
using TMPro;


public enum GAME_STATE
{
    MAIN_MENU = 0,
    PLAY_MODE = 1,
    GAME_WON = 2,
    GAME_OVER = 3
}

public enum COLOR
{
    RED,
    BLUE,
    GREEN,
    YELLOW,
    NONE
}

public class GameManagerScript : MonoBehaviour
{
    public static GAME_STATE game_state = GAME_STATE.MAIN_MENU;
    public static float timer = 0f;

    string[] colour_word = new string[4];
    Color[] colors = new Color[4];

    [Header("Number of rounds")]
    public int rounds = 5;
    int current_round = 1;
    int last_round;

    COLOR correct_colour;

    COLOR color_picked;
    public COLOR ColorPicked
    {
        set { color_picked = value; }
    }


    [Header("UI Canvases")]
    /// Different UI depending on states
    [SerializeField] GameObject main_menu;
    [SerializeField] GameObject play_menu;
    [SerializeField] TextMeshProUGUI random_word;
    [SerializeField] TextMeshProUGUI timer_text;

    [SerializeField] GameObject game_win_menu;
    [SerializeField] GameObject game_over_menu;


    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.UtcNow.Second);

        colour_word[0] = "Red";
        colour_word[1] = "Blue";
        colour_word[2] = "Green";
        colour_word[3] = "Yellow";

        colors[0] = Color.red;
        colors[1] = Color.blue;
        colors[2] = Color.green;
        colors[3] = Color.yellow;

        main_menu.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (game_state)
        {
            case GAME_STATE.MAIN_MENU:
                if (!main_menu.activeSelf)
                {
                    main_menu.SetActive(true);
                }
                play_menu.SetActive(false);
                game_win_menu.SetActive(false);
                game_over_menu.SetActive(false);
                break;
            case GAME_STATE.PLAY_MODE:

                if (!play_menu.activeSelf)
                    play_menu.SetActive(true);
                PlayModeUpdate();
                main_menu.SetActive(false);
                game_win_menu.SetActive(false);
                game_over_menu.SetActive(false);
                break;
            case GAME_STATE.GAME_WON:
                if (!game_win_menu.activeSelf)
                    game_win_menu.SetActive(true);
                main_menu.SetActive(false);
                play_menu.SetActive(false);
                game_over_menu.SetActive(false);
                break;
            case GAME_STATE.GAME_OVER:
                if (!game_over_menu.activeSelf)
                    game_over_menu.SetActive(true);
                main_menu.SetActive(false);
                play_menu.SetActive(false);
                game_win_menu.SetActive(false);
                break;
        }
    }

    void PlayModeUpdate()
    {
        DigitalTimer();

        // check if the current round has progressed
        // If so, generate new colour for the next round
        if (current_round != last_round)
        {
            last_round = current_round;
            GenerateColour();
        }

        // Check to see if player's choice equals, randomly selected colour
        if (color_picked == correct_colour)
        {
            current_round++;
            color_picked = COLOR.NONE;
        }

        // Check to see if the number of rounds if reached.
        HasBeatenGame();
    }

    bool HasBeatenGame()
    {
        if (current_round == rounds)
        {
            current_round = 0;
            game_state = GAME_STATE.GAME_WON;
            return true;
        }

        return false;
    }


    /// <summary>
    /// Generate a random color and word.
    /// </summary>
    void GenerateColour()
    {
        int random_number = Random.Range(0, 3);
        correct_colour = (COLOR)random_number;

        random_word.text = colour_word[Random.Range(0, 3)];
        random_word.color = colors[random_number];        
    }

    /// <summary>
    /// Convert time passed each frame into a digital clock
    /// </summary>
    void DigitalTimer()
    {
        timer += Time.deltaTime;
        float minutes = Mathf.FloorToInt(timer / 60f);
        float seconds = Mathf.FloorToInt(timer % 60f);

        timer_text.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
