
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class Board {

    protected Tile [,] tiles_;

    //--------------------------------------------------

    public Board (int width, int height) {

        tiles_ = new Tile[width, height];
    }

    public void SetTile (int x, int y, Tile tile) {

        if (x < 0 || x >= tiles_.GetLength(0)) return;
        if (y < 0 || y >= tiles_.GetLength(1)) return;

        tiles_[x, y] = tile;
    }

    public Tile GetTile (int x, int y) {

        if (x < 0 || x >= tiles_.GetLength(0)) return null;
        if (y < 0 || y >= tiles_.GetLength(1)) return null;

        return tiles_[x, y];
    }
}
