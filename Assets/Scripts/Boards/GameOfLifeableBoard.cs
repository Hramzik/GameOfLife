
//--------------------------------------------------

using UnityEngine;
using System.Collections.Generic;

//--------------------------------------------------

public class GameOfLifeableBoard: Board {

    private HashSet<GameOfLifeCell> alive_cells_; // поддерживается постоянно
    private HashSet<GameOfLifeCell> dead_cells_;  // новоумершие клетки
    private HashSet<GameOfLifeCell> cells_to_check_;

    //--------------------------------------------------

    public new void Start () {

        base.Start ();

        alive_cells_    = new HashSet<GameOfLifeCell> ();
        dead_cells_     = new HashSet<GameOfLifeCell> ();
        cells_to_check_ = new HashSet<GameOfLifeCell> ();
    }

    //--------------------------------------------------

    public override void SetTile (Vector2Int position, Tile tile) {

        base.SetTile (position, tile);

        //--------------------------------------------------

        GameOfLifeCell cell = tile as GameOfLifeCell;
        if (cell == null) return;

        if (cell.IsAlive ()) alive_cells_.Add (cell);;
        UpdateCellsToCheck ();
    }

    public void ReviveTile (Vector2Int position) {

        GameOfLifeCell cell = GetTile (position) as GameOfLifeCell;
        if (cell == null) return;

        cell.SetIsAlive (true);
        alive_cells_.Add (cell);;
        UpdateCellsToCheck ();
    }

    //--------------------------------------------------

    public void UpdateBoard () {

        UpdateCellsToCheck ();
        UpdateSets ();
        UpdateCells ();
    }

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
            bool alive = cell.IsAlive ();

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

        foreach (GameOfLifeCell cell in alive_cells_) cell.SetIsAlive (true);
        foreach (GameOfLifeCell cell in dead_cells_)  cell.SetIsAlive (false);
    }

    private int CountNeighbors (GameOfLifeCell center_tile) {

        int count = 0;
        for (int dx = -1; dx <= 1; dx++) {
        for (int dy = -1; dy <= 1; dy++) {

            if (dx == 0 && dy == 0) continue;

            Tile neighbor = GetTile (center_tile.x + dx, center_tile.y + dy);
            if (neighbor is GameOfLifeCell tile && tile.IsAlive ()) count++;
        }}

        return count;
    }
}