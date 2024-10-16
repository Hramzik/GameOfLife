
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

[System.Serializable]
public struct GameOfLifeCellCfg {

    public Material alive_material;
    public Material dead_material;

    //--------------------------------------------------

    public GameOfLifeCellCfg (Material alive_material, Material dead_material) {

        this.alive_material = alive_material;
        this.dead_material  = dead_material;
    }
}

//--------------------------------------------------

