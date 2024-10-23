
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class LevelLoader: MonoBehaviour {

    public GameOfLifeableBoard board_;
    public GridRenderer grid_renderer_;
    public SpriteRenderer background_;

    //--------------------------------------------------

    public LevelLoader (GameOfLifeableBoard board) {

        board_ = board;
    }

    public void LoadLevel (Level level) {

        board_.SetSize (level.board_size);

        SpawnTiles   (level);
        SpawnPlayers (level);
        SpawnGrid (level);
        SpawnBackground (level);
    }

    private void SpawnGrid (Level level) {

        grid_renderer_.transform.parent = board_.transform;
        grid_renderer_.transform.localPosition = new Vector3 (0, 0, 0.5f);
        grid_renderer_.SetSize (level.board_size);
        grid_renderer_.DrawGrid ();
    }

    private void SpawnBackground (Level level) {

        // position
        background_.transform.parent = board_.transform;
        background_.transform.localPosition = new Vector3 (0, 0, 1.5f);

        // scale
        float scaling = board_.GetSize ().y / background_.bounds.size.y;
        scaling *= 1.5f;
        Vector3 local_scale = background_.transform.localScale;
        Vector3 new_scale = new Vector3 (local_scale.x * scaling, local_scale.y * scaling, local_scale.z);
        background_.transform.localScale = new_scale;
    }

    private void SpawnPlayers (Level level) {

        var obj1 = Object.Instantiate (level.player1_prefab);
        board_.AddObject (level.player1_spawn, obj1);

        //--------------------------------------------------

        var obj2 = Object.Instantiate (level.player2_prefab);
        board_.AddObject (level.player2_spawn, obj2);
    }

    private void SpawnTiles (Level level) {

        SpawnDeadTiles  (level);
        SpawnAliveTiles (level);
        SpawnLevelTiles (level);
    }

    private void SpawnLevelTiles (Level level) {

        foreach (Vector2Int pos in level.level_tile_positions) {

            var obj = Object.Instantiate (level.tile_prefab);
            obj.GetComponent<Renderer> ().material = level.level_tile_material;
            var tile = obj.AddComponent<Tile> ();

            board_.SetTile (pos, tile);
        }
    }

    private void SpawnAliveTiles (Level level) {

        foreach (Vector2Int pos in level.alive_tile_positions) {

            var obj = Object.Instantiate (level.tile_prefab);
            var cell = obj.AddComponent<GameOfLifeCell> ();
            cell.SetCfg (level.cell_cfg);
            cell.SetIsAlive (true);

            board_.SetTile (pos, cell);
        }
    }

    private void SpawnDeadTiles (Level level) {

        for (int x = 0; x < level.board_size.x; ++x) {
        for (int y = 0; y < level.board_size.y; ++y) {

            var obj = Object.Instantiate (level.tile_prefab);
            var cell = obj.AddComponent<GameOfLifeCell> ();
            cell.SetCfg (level.cell_cfg);
            cell.SetIsAlive (false);

            board_.SetTile (new Vector2Int (x, y), cell);
        }}
    }
}

//--------------------------------------------------

