
//--------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

//--------------------------------------------------

public class Game: MonoBehaviour {

    public GameOfLifeableBoard board_;
    public Level [] levels_;
    public LevelLoader level_loader_;
    public GameEnder   game_ender_;

    public Text game_end_text_;
    private bool is_game_running = true;

    //--------------------------------------------------

    void Start () {

        board_.transform.parent = transform;
        board_.transform.localPosition = Vector3.zero;

        //--------------------------------------------------

        levels_ = Resources.LoadAll<Level> ("Levels");
        level_loader_.transform.parent = transform;
        LoadLevel (0);
    }

    void Update () {

        if (Input.GetKeyDown (KeyCode.Space)) ToggleGameRunning ();
        if (Input.GetKeyDown (KeyCode.Keypad0)) LoadLevel (0);
        if (Input.GetKeyDown (KeyCode.Keypad1)) LoadLevel (1);
        if (Input.GetKeyDown (KeyCode.Keypad2)) LoadLevel (2);
    }

    //--------------------------------------------------

    public void EndGame (VictoryText text) {

        game_end_text_.text = text.message;
        game_end_text_.color = text.color;

        //--------------------------------------------------

        CancelInvoke ("UpdateGameOfLife");
    }

    void ToggleGameRunning () {

        if (is_game_running) StopGameRunning ();
        else                 StartGameRunning ();
    }

    void StartGameRunning () {

        InvokeRepeating ("UpdateGameOfLife", 0f, 0.5f);
        is_game_running = true;
    }

    void StopGameRunning () {

        CancelInvoke ("UpdateGameOfLife");
        is_game_running = false;
    }

    void UpdateGameOfLife () {

        board_.UpdateBoard ();
    }

    //--------------------------------------------------

    void LoadLevel (int index) {

        game_end_text_.text = "";
        StopGameRunning ();
        StartGameRunning ();
        level_loader_.LoadLevel (levels_ [index]);
    }
}
