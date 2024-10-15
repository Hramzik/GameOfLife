
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class Game: MonoBehaviour {

    public GameOfLifeCellCfg cell_cfg;

    private GameOfLifeableBoard board_;

    //--------------------------------------------------

    void Start() {

        board_ = new GameOfLifeableBoard (10, 10, cell_cfg);
        board_.ReviveTile (0, 0);
        board_.ReviveTile (0, 1);
        board_.ReviveTile (1, 0);
        board_.ReviveTile (1, 1);

        board_.ReviveTile (0, 8);
        board_.ReviveTile (1, 7);
        board_.ReviveTile (2, 7);
        board_.ReviveTile (2, 8);
        board_.ReviveTile (2, 9);

        board_.ReviveTile (8, 7);
        board_.ReviveTile (8, 8);
        board_.ReviveTile (8, 9);

        InvokeRepeating ("UpdateGameOfLife", 0.5f, 0.5f);
    }

    void UpdateGameOfLife () {

        board_.UpdateBoard ();
    }
}
