
//--------------------------------------------------

using UnityEngine;
using UnityEngine.UIElements;

//--------------------------------------------------

public class Board: MonoBehaviour {

    protected Tile [,] tiles_;

    //--------------------------------------------------

    public Start () {

        SetSize (Vector2Int.zero);
    }

    public void SetSize (Vector2Int size) {

        tiles_ = new Tile[size.x, size.y];
    }

    public Vector2Int GetSize () {

        return new Vector2Int (tiles_.GetLength(0), tiles_.GetLength(1));
    }

    public void SetTile (int x, int y, Tile tile_prefab) {

        if (x < 0 || x >= tiles_.GetLength(0)) { Debug.Log ("Invalid index"); return; }
        if (y < 0 || y >= tiles_.GetLength(1)) { Debug.Log ("Invalid index"); return; }

        Tile tile = Instantiate (tile_prefab, new Vector3 (-GetSize ().x/2 + x, -GetSize ().y/2 + y, 0), Quaternion.identity);
        tile.transform.parent = transform;

        tiles_[x, y] = tile;
    }

    public void SetTile (Vector2Int position, Tile tile_prefab) {

        SetTile (position.x, position.y, tile_prefab);
    }

    public Tile GetTile (int x, int y) {

        if (x < 0 || x >= GetSize ().x) { Debug.Log ("Invalid index"); return null; }
        if (y < 0 || y >= GetSize ().y) { Debug.Log ("Invalid index"); return null; }

        return tiles_[x, y];
    }

    public Tile GetTile (Vector2Int position) {

        return GetTile (position.x, position.y);
    }
}
