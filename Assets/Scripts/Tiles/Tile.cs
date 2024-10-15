
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public abstract class Tile {

    public int x;
    public int y;

    public GameObject game_object;

    public Tile (int x, int y, GameObject game_object) {

        this.x = x;
        this.y = y;
        this.game_object = Object.Instantiate (game_object, game_object.Transform.Position, Quaternion.identity);
    }

    public Tile (Vector2Int position, GameObject game_object):
        this (posiition.x, position.y, game_object) {}
}

//--------------------------------------------------

