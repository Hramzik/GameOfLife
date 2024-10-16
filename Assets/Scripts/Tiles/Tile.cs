
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class Tile: MonoBehaviour {

    public int x;
    public int y;

    public GameObject game_object;

    public Tile (int x, int y, GameObject game_object) {

        this.x = x;
        this.y = y;
        this.game_object = Object.Instantiate (game_object);
    }

    public Tile (Vector2Int position, GameObject game_object):
        this (position.x, position.y, game_object) {}
}

//--------------------------------------------------

