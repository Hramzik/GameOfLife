
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class LevelLoader {

    private GameOfLifeableBoard board_;

    //--------------------------------------------------

    public LevelLoader (GameOfLifeableBoard board) {

        board_ = board;
    }

    public void LoadLevel (Level level) {

        board_.SetSize (level.board_size);

        SpawnDeadTiles  (level);
        SpawnAliveTiles (level);
        SpawnLevelTiles (level);
    }

    private void SpawnLevelTiles (Level level) {

        GameObject level_tile_object = Object.Instantiate (level.tile_prefab);
        level_tile_object.GetComponent<Renderer> ().material = level.level_tile_material;
        foreach (Vector2Int pos in level.level_tile_positions) {

            board_.SetTile (pos, new Tile (pos, level.tile_prefab));
        }
    }

    private void SpawnAliveTiles (Level level) {

        foreach (Vector2Int pos in level.alive_tile_positions) {

            board_.SetTile (pos, new GameOfLifeCell (pos, level.tile_prefab, level.cell_cfg, true));
        }
    }

    private void SpawnDeadTiles (Level level) {

        for (int x = 0; x < level.board_size.x; ++x) {
        for (int y = 0; y < level.board_size.y; ++y) {

            board_.SetTile (x, y, new GameOfLifeCell (x, y, level.tile_prefab, level.cell_cfg, false));
        }}
    }
}

//--------------------------------------------------

