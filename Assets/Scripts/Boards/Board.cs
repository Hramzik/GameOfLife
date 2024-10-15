
//--------------------------------------------------

using UnityEngine;
using UnityEngine.UIElements;

//--------------------------------------------------

public class Board: MonoBehaviour {

    protected Vector2Int size_;
    protected Tile [,] tiles_;

    //--------------------------------------------------

    public Board (Vector2Int size) {

        SetSize (size);
    }

    public void SetSize (Vector2Int size) {

        tiles_ = new Tile[size.x, size.y];
    }

    public void SetTile (int x, int y, Tile tile_prefab) {

        if (x < 0 || x >= tiles_.GetLength(0)) return;
        if (y < 0 || y >= tiles_.GetLength(1)) return;

        Vector3 tile_object_pos = GetComponent <GameObject> ().Transform.Position;
        tile_object_pos += new Vector3 (-size_.x/2 + x, -size_.y/2 + y, 0);
        tile_prefab.game_object.Transform.Position = tile_object_pos;

        tiles_[x, y] = tile;
    }

    public void SetTile (Vector2Int position, Tile tile_prefab) {

        SetTile (position.x, position.y, tile_prefab);
    }

    public Tile GetTile (int x, int y) {

        if (x < 0 || x >= tiles_.GetLength(0)) return;
        if (y < 0 || y >= tiles_.GetLength(1)) return;

        return tiles_[x, y];
    }

    public Tile GetTile (Vector2Int position) {

        GetTile (position.x, position.y);
    }
}
