
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

[System.Serializable]
[CreateAssetMenu (fileName = "BulletCfg", menuName = "BulletCfg")]
public class BulletCfg: ScriptableObject {

    public GameObject bullet_prefab;
    public float      bullet_speed;
}

//--------------------------------------------------

