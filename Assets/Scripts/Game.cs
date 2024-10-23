
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class Game: MonoBehaviour {

    public GameOfLifeCellCfg cell_cfg;

    public GameOfLifeableBoard board_;
    public Level [] levels_;
    public LevelLoader level_loader_;

    //--------------------------------------------------

    void Start() {

        levels_ = Resources.LoadAll<Level> ("Levels");
        LoadLevel ();

        InvokeRepeating ("UpdateGameOfLife", 1f, 0.5f);
    }

    void LoadLevel (/*int index*/) {

        level_loader_.LoadLevel (levels_ [0]);
    }

    //--------------------------------------------------

    void UpdateGameOfLife () {

        board_.UpdateBoard ();
    }
}
