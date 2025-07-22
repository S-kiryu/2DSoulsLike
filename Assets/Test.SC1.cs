using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;         // 移動速度
    public float jumpForce = 5f;         // ジャンプ力
    public Transform groundCheck;        // 地面チェック位置
    public LayerMask groundLayer;        // 地面のレイヤー

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 横方向の移動
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // ジャンプ
        if (Input.GetButtonDown("F") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
