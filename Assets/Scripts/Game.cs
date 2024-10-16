
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class Game: MonoBehaviour {

    public GameOfLifeCellCfg cell_cfg;

    public GameOfLifeableBoard board_;
    public Level [] levels_;

    //--------------------------------------------------

    void Start() {

        levels_ = Resources.LoadAll<Level> ("Levels");

        LevelLoader loader = new LevelLoader (board_);
        loader.LoadLevel (levels_ [0]);

        InvokeRepeating ("UpdateGameOfLife", 0.5f, 0.5f);
    }

    void UpdateGameOfLife () {

        board_.UpdateBoard ();
    }
}
