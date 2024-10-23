
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class Bullet: MonoBehaviour {

    public float lifetime = 20f;
    public GameObject owner;

    void Start () {

        Destroy (gameObject, lifetime); // Уничтожение пули через определенное время
    }

    void OnCollisionEnter2D (Collision2D collision) {

        GameObject collider = collision.gameObject;

        //--------------------------------------------------

        PlayerController player = collider.GetComponent<PlayerController> ();
        if (player != null) {

            if (collider == owner) return;
            player.Die ();
        }

        //--------------------------------------------------
        // hit wall

        Destroy(gameObject);
    }
}