
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

[System.Serializable]
public struct Level {

    public Vector2Int board_size;

    public Vector2Int player1_spawn;
    public Vector2Int player2_spawn;

    public GameObject tile_prefab;
    public Material level_tile_material;
    public Material alive_tile_material;
    public Material  dead_tile_material;
    public Vector2 [] level_tile_positions;
    public Vector2 [] alive_tile_positions;
}

//--------------------------------------------------

