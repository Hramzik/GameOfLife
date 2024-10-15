
//--------------------------------------------------

using UnityEngine;

//--------------------------------------------------

public class PlayerController: MonoBehaviour {

    public PlayerControls controls;

    public float speed = 1.0f;
    public float jumpForce = 10.0f;

    //public GameObject bulletPrefab;
    //public Transform bulletSpawnPoint;
    //public float bulletSpeed = 10.0f;

    private Rigidbody2D rigit_body_;
    //private bool isGrounded;
    //public LayerMask groundLayer;
    //public Transform groundCheck;
    //public float checkRadius;

    void Start () {

        rigit_body_ = GetComponent<Rigidbody2D> ();
    }

    void Update () {

        Vector2 direction = Vector2.zero;
        if (Input.GetKey (controls.left_key))  direction += Vector2.left;
        if (Input.GetKey (controls.right_key)) direction += Vector2.right;

        rigit_body_.velocity = new Vector2 (direction.x * speed, rigit_body_.velocity.y);

        //if (Input.GetKeyDown(jumpKey) && isGrounded) rigit_body_.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        //if (Input.GetKeyDown(shootKey)) Shoot();
    }

    void FixedUpdate () {

        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    void Shoot () {

        //GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        //Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        //bulletRb.velocity = Vector2.right * bulletSpeed;
    }
}