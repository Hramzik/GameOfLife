
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class PlayerController: MonoBehaviour {

    public VictoryText victory_text;
    public PlayerControls controls;

    private float speed = 5.0f;
    private float jump_speed = 7.0f;

    public Transform bullet_spawn;
    public BulletCfg bullet_cfg;

    private Rigidbody2D rigit_body_;

    public LayerMask  ground_layer;
    public Collider2D ground_check_collider;

    private bool  is_grounded_;
    private float jump_interval_window = 0.5f;
    private float last_pressed_jump_time_ = -1;

    private bool is_dead_   = false;
    private bool is_active_ = true;

    //--------------------------------------------------

    public void Win () {

        transform.parent.parent.GetComponent<Game> ().EndGame (victory_text);
    }

    public void Deactivate () {

        is_active_ = false;
        GetComponent<Rigidbody2D> ().simulated = false;
    }

    public void Die () {

        if (is_dead_) return;

        //--------------------------------------------------

        is_dead_   = true;
        is_active_ = false;
        GetComponent<Renderer> ().enabled = false;
    }

    public bool IsDead () {

        return is_dead_;
    }
    //--------------------------------------------------

    public void Start () {

        rigit_body_ = GetComponent<Rigidbody2D> ();
        //rigit_body_.gravityScale = 2.0f;
    }

    public void Update () {

        CheckControlls ();
        UpdateSpriteDirection ();
    }

    public void FixedUpdate () {

        CheckOutOfMap ();
        UpdateGrounded ();
        CheckForJump ();
    }

    //--------------------------------------------------

    private void CheckControlls () {

        if (!is_active_) return;

        //--------------------------------------------------

        Vector2 direction = Vector2.zero;
        if (Input.GetKey (controls.left_key))  direction += Vector2.left;
        if (Input.GetKey (controls.right_key)) direction += Vector2.right;

        rigit_body_.velocity = new Vector2 (direction.x * speed, rigit_body_.velocity.y);

        if (Input.GetKeyDown (controls.jump_key)) last_pressed_jump_time_ = Time.time;
        if (Input.GetKeyDown (controls.shoot_key)) Shoot ();
    }

    private void CheckOutOfMap () {

        if (transform.localPosition.y < -20) Die ();
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

    private bool IsFacingRight () {

        return transform.localScale.x > 0 ? true : false;
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

        GameObject bullet = Instantiate (bullet_cfg.bullet_prefab, bullet_spawn.position, bullet_spawn.rotation);
        Rigidbody2D bullet_rb = bullet.GetComponent<Rigidbody2D> ();

        //--------------------------------------------------
        // set velocity

        Vector2 direction = IsFacingRight () ? Vector2.right : Vector2.left;
        bullet_rb.velocity = direction * bullet_cfg.bullet_speed;

        //--------------------------------------------------
        // set owner

        bullet.GetComponent<Bullet> ().owner = this;
    }
}