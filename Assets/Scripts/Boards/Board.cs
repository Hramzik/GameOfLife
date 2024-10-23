
//--------------------------------------------------

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

//--------------------------------------------------

public class Board: MonoBehaviour {

    protected Tile [,] tiles_;

    //--------------------------------------------------

    public void Start () {

        SetSize (Vector2Int.zero);
    }

    // по координатам клеток! 0, 0 - центр нулевого квадрата, а не угол карты!
    public void AddObject (float x, float y, GameObject obj) {

        obj.transform.parent = transform;
        float local_x = -(float) GetSize ().x/2 + x + 0.5f;
        float local_y = -(float) GetSize ().y/2 + y + 0.5f;
        obj.transform.localPosition = new Vector3 (local_x, local_y, 0);
    }

    public void AddObject (Vector2 position, GameObject obj) {

        AddObject (position.x, position.y, obj);
    }

    //--------------------------------------------------

    public void SetSize (Vector2Int size) {

        tiles_ = new Tile[size.x, size.y];
    }

    public Vector2Int GetSize () {

        return new Vector2Int (tiles_.GetLength(0), tiles_.GetLength(1));
    }

    public virtual void SetTile (Vector2Int position, Tile tile) {

        if (position.x < 0 || position.x >= tiles_.GetLength(0)) { Debug.Log ("Invalid index"); return; }
        if (position.y < 0 || position.y >= tiles_.GetLength(1)) { Debug.Log ("Invalid index"); return; }

        tile.SetPosition (position);
        AddObject (position, tile.gameObject);

        if (tiles_ [position.x, position.y] is Tile old_tile) Destroy (old_tile.gameObject);
        tiles_ [position.x, position.y] = tile;
    }

    public Tile GetTile (int x, int y) {

        if (x < 0 || x >= GetSize ().x) { /*Debug.Log ("Invalid index");*/ return null; }
        if (y < 0 || y >= GetSize ().y) { /*Debug.Log ("Invalid index");*/ return null; }

        return tiles_[x, y];
    }

    public Tile GetTile (Vector2Int position) {

        return GetTile (position.x, position.y);
    }
}
