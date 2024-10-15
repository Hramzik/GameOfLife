
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

[System.Serializable]
public struct GameOfLifeCellCfg {

    public Material alive_material;
    public Material dead_material;
    public GameObject game_object;

    //--------------------------------------------------

    public GameOfLifeCellCfg (Material alive_material, Material dead_material, GameObject game_object) {

        alive_material = alive_material;
        dead_material  = dead_material;
        game_object = game_object;
    }
}

//--------------------------------------------------

