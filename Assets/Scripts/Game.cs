
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class Game: MonoBehaviour {

    public GameOfLifeableBoard board_;
    public Level [] levels_;
    public LevelLoader level_loader_;

    private bool is_game_running = true;

    //--------------------------------------------------

    void Start () {

        levels_ = Resources.LoadAll<Level> ("Levels");
        LoadLevel ();

        InvokeRepeating ("UpdateGameOfLife", 1f, 0.5f);
    }

    void Update () {

        if (Input.GetKeyDown (KeyCode.Space)) ToggleGameRunning ();
    }

    //--------------------------------------------------

    void ToggleGameRunning () {

        if (is_game_running) {

            CancelInvoke ("UpdateGameOfLife");
            is_game_running = false;
            return;
        }

        InvokeRepeating ("UpdateGameOfLife", 0f, 0.5f);
        is_game_running = true;
    }

    void UpdateGameOfLife () {

        board_.UpdateBoard ();
    }

    //--------------------------------------------------

    void LoadLevel (/*int index*/) {

        level_loader_.LoadLevel (levels_ [0]);
    }
}
