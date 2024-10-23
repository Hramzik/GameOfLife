
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

[System.Serializable]
[CreateAssetMenu (fileName = "PlayerControls", menuName = "PlayerControls")]
public class PlayerControls: ScriptableObject {

    public KeyCode  left_key;
    public KeyCode right_key;
    public KeyCode  jump_key;
    public KeyCode shoot_key;

    public PlayerControls (KeyCode left_key, KeyCode right_key, KeyCode jump_key, KeyCode shoot_key) {

        this. left_key =  left_key;
        this.right_key = right_key;
        this. jump_key =  jump_key;
        this.shoot_key = shoot_key;
    }
}

//--------------------------------------------------

