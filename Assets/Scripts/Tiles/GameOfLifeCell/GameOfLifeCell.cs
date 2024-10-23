
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------



//--------------------------------------------------

public class GameOfLifeCell: Tile {

    private bool is_alive_;
    private GameOfLifeCellCfg cfg_;

    private Renderer renderer_;

    //--------------------------------------------------

    public void SetCfg (GameOfLifeCellCfg cfg) {

        cfg_ = cfg;
    }

    public bool IsAlive () {

        return is_alive_;
    }

    public void SetIsAlive (bool flag) {

        is_alive_ = flag;
    }

    public void Start () {

        renderer_ = GetComponent<Renderer> ();
    }

    public void Update () {

        renderer_.material = is_alive_ ? cfg_.alive_material : cfg_.dead_material;
        renderer_.enabled  = is_alive_;
    }

    public void FixedUpdate () {

        GetComponent<BoxCollider2D>().enabled = is_alive_;
    }
}

//--------------------------------------------------

