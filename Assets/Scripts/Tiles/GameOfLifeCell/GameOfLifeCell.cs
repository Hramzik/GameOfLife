
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------



//--------------------------------------------------

public class GameOfLifeCell: Tile {

    private bool is_alive_;
    private GameOfLifeCellCfg cfg_;

    //--------------------------------------------------

    public GameOfLifeCell (int x, int y, GameOfLifeCellCfg cfg, bool is_alive):
        base(x, y, cfg.game_object)
    {
        cfg_ = cfg;
        set_is_alive (is_alive);
    }

    public bool is_alive () {

        return is_alive_;
    }

    public void set_is_alive (bool flag) {

        is_alive_ = flag;

        //--------------------------------------------------

        Renderer renderer = game_object_.GetComponent<Renderer> ();
        renderer.material = is_alive_ ? cfg_.alive_material : cfg_.dead_material;
    }
}

//--------------------------------------------------

