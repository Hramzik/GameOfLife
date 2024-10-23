
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------



//--------------------------------------------------

public class GameOfLifeCell: Tile {

    public bool is_alive_;
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

    //--------------------------------------------------

    public void Start () {

        renderer_ = GetComponent <Renderer> ();
    }

    public void Update () {

        if (cfg_.alive_material == null) Debug.Log ("HUY");
        if (cfg_.dead_material == null) Debug.Log ("HU1Y");
        renderer_.material = is_alive_ ? cfg_.alive_material : cfg_.dead_material;
        //renderer_.enabled  = is_alive_;
    }

    public void FixedUpdate () {

        GetComponent<BoxCollider2D> ().isTrigger = !is_alive_;
    }

    //--------------------------------------------------

    void OnMouseDown () {

        GameOfLifeableBoard board = transform.parent.GetComponent<GameOfLifeableBoard> ();
        if (board == null) return;

        board.ReviveTile (new Vector2Int (x, y));
        //Debug.Log ("clicked");
    }
}

//--------------------------------------------------

