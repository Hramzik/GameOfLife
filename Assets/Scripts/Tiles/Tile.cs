
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class Tile: MonoBehaviour {

    public int x;
    public int y;

    public void SetPosition (int x, int y) {

        this.x = x;
        this.y = y;
    }

    public void SetPosition (Vector2Int position) {

        SetPosition (position.x, position.y);
    }
}

//--------------------------------------------------

