
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class Bullet: MonoBehaviour {

    public float lifetime = 20f;
    public PlayerController owner;

    void Start () {

        Destroy (gameObject, lifetime); // Уничтожение пули через определенное время
    }

    void OnCollisionEnter2D (Collision2D collision) {

        GameObject collider = collision.gameObject;

        //--------------------------------------------------

        PlayerController player = collider.GetComponent<PlayerController> ();
        if (player != null) {

            if (player == owner) return;
            player.Die ();
            owner.Deactivate ();
            owner.Win ();
        }

        //--------------------------------------------------
        // hit wall

        Destroy(gameObject);
    }
}