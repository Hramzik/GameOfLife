
//--------------------------------------------------

using UnityEngine;
using System.Collections.Generic;

//--------------------------------------------------

public class GameOfLifeableBoard: Board {

    private HashSet<GameOfLifeCell> alive_cells_; // поддерживается постоянно
    private HashSet<GameOfLifeCell> dead_cells_;  // новоумершие клетки
    private HashSet<GameOfLifeCell> cells_to_check_;

    //--------------------------------------------------

    public GameOfLifeableBoard (Vector2Int size/*, GameOfLifeCellCfg cell_cfg*/):
        base(size)
    {
        // for (int x = 0; x < size.x;  ++x) {
        // for (int y = 0; y < size.y; ++y) {

        //     GameOfLifeCellCfg cfg = cell_cfg;
        //     Vector3 prefab_position = cell_cfg.game_object.transform.position;
        //     Vector3 offset = new Vector3 (-size.x/2 + x, -size.y/2 + y, 0);
        //     Vector3 cell_position = prefab_position + offset;
        //     cfg.game_object = Object.Instantiate (cell_cfg.game_object, cell_position, Quaternion.identity);

        //     tiles_ [x, y] = new GameOfLifeCell (x, y, cfg, false);
        // }}

        alive_cells_    = new HashSet<GameOfLifeCell> ();
        dead_cells_     = new HashSet<GameOfLifeCell> ();
        cells_to_check_ = new HashSet<GameOfLifeCell> ();
    }

    //--------------------------------------------------

    public void ReviveTile (int x, int y) {

        Tile tile = GetTile (x, y);
        GameOfLifeCell cell = tile as GameOfLifeCell;
        if (cell == null) return;

        //--------------------------------------------------

        cell.set_is_alive (true);
        alive_cells_.Add (cell);
    }

    public void UpdateBoard () {

        UpdateCellsToCheck ();
        UpdateSets ();
        UpdateCells ();
    }

    //--------------------------------------------------

    private void UpdateCellsToCheck () {

        cells_to_check_.Clear ();

        foreach (GameOfLifeCell alive_cell in alive_cells_) {
        for (int dx = -1; dx <= 1; dx++) {
        for (int dy = -1; dy <= 1; dy++) {

            Tile neighbor = GetTile (alive_cell.x + dx, alive_cell.y + dy);
            if (neighbor is GameOfLifeCell cell) cells_to_check_.Add (cell);
        }}}
    }

    private void UpdateSets () {

        dead_cells_.Clear ();

        foreach (GameOfLifeCell cell in cells_to_check_) {

            int neighbor_count = CountNeighbors (cell);
            bool alive = cell.is_alive ();

            if (!alive && neighbor_count == 3) {

                alive_cells_.Add (cell);
                continue;
            }

            if (alive && (neighbor_count < 2 || neighbor_count > 3)) {

                alive_cells_.Remove(cell);
                dead_cells_.Add (cell);
                continue;
            }
        }
    }

    private void UpdateCells () {

        foreach (GameOfLifeCell cell in alive_cells_) cell.set_is_alive (true);
        foreach (GameOfLifeCell cell in dead_cells_)  cell.set_is_alive (false);
    }

    private int CountNeighbors (GameOfLifeCell center_tile) {

        int count = 0;
        for (int dx = -1; dx <= 1; dx++) {
        for (int dy = -1; dy <= 1; dy++) {

            if (dx == 0 && dy == 0) continue;

            Tile neighbor = GetTile (center_tile.x + dx, center_tile.y + dy);
            if (neighbor is GameOfLifeCell tile && tile.is_alive ()) count++;
        }}

        return count;
    }
}