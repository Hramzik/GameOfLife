
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public abstract class Tile {

    public int x;
    public int y;

    protected GameObject game_object_;

    public Tile (int x, int y, GameObject game_object) {

        this.x = x;
        this.y = y;
        game_object_ = game_object;
    }
}

//--------------------------------------------------

