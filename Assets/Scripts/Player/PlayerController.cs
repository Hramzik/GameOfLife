
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class PlayerController: MonoBehaviour {

    //public static PlayerControls player1_controls = new PlayerControls (KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.Space);
    //public static PlayerControls player2_controls = new PlayerControls (KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow);

    //--------------------------------------------------

    public PlayerControls controls;

    private float speed = 5.0f;
    private float jump_speed = 7.0f;

    //public GameObject bulletPrefab;
    //public Transform bulletSpawnPoint;
    //public float bulletSpeed = 10.0f;

    private Rigidbody2D rigit_body_;

    public LayerMask  ground_layer;
    public Collider2D ground_check_collider;

    private bool  is_grounded_;
    private float jump_interval_window = 0.5f;
    private float last_pressed_jump_time_ = -1;

    public void Start () {

        rigit_body_ = GetComponent<Rigidbody2D> ();
        //rigit_body_.gravityScale = 2.0f;
    }

    public void Update () {

        Vector2 direction = Vector2.zero;
        if (Input.GetKey (controls.left_key))  direction += Vector2.left;
        if (Input.GetKey (controls.right_key)) direction += Vector2.right;

        rigit_body_.velocity = new Vector2 (direction.x * speed, rigit_body_.velocity.y);

        if (Input.GetKeyDown (controls.jump_key)) last_pressed_jump_time_ = Time.time;
        //if (Input.GetKeyDown(shoot_key)) Shoot();

        UpdateSpriteDirection ();
    }

    public void FixedUpdate () {

        UpdateGrounded ();
        CheckForJump ();
    }

    //--------------------------------------------------

    private void UpdateSpriteDirection () {

        if (rigit_body_.velocity.x == 0) return;

        //--------------------------------------------------

        int mirror_coefficient = (rigit_body_.velocity.x > 0) ? 1 : -1;

        Vector3 local_scale = transform.localScale;
        local_scale.x = mirror_coefficient * Mathf.Abs (local_scale.x);
        transform.localScale = local_scale;
    }

    private void UpdateGrounded () {

        //Bounds collider_bounds = ground_check_collider.bounds;
        //Vector2 center = collider_bounds.center;
        //Vector2 size   = collider_bounds.size;

        //is_grounded_ = Physics2D.OverlapBox (center, size, 0, ground_layer) != null;
        is_grounded_ = rigit_body_.velocity.y == 0;
    }

    private void CheckForJump () {

        if (!is_grounded_) return;
        if (Time.time - last_pressed_jump_time_ > jump_interval_window) return;

        Jump ();
    }

    //--------------------------------------------------

    private void Jump () {

        //rigit_body_.AddForce (new Vector2 (0, jump_force), ForceMode2D.Impulse);
        rigit_body_.velocity = new Vector2(rigit_body_.velocity.x, jump_speed);
    }

    private void Shoot () {

        //GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        //Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        //bulletRb.velocity = Vector2.right * bulletSpeed;
    }
}