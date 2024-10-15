
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

        foreach (Vector2Int pos in level.level_tile_positions) {

            
            board_.SetTile (pos, new Tile (pos, level.tile_prefab));
        }

        foreach (Vector2Int pos in level.alive_tile_positions) {

            GameOfLifeCellCfg cfg (level.alive_tile_material, level.dead_tile_material, level.tile_prefab);
            board_.SetTile (pos, new GameOfLifeCell (pos, level.tile_prefab));
        }
    }
}

//--------------------------------------------------

