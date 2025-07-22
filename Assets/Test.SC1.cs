using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;         // �ړ����x
    public float jumpForce = 5f;         // �W�����v��
    public Transform groundCheck;        // �n�ʃ`�F�b�N�ʒu
    public LayerMask groundLayer;        // �n�ʂ̃��C���[

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �������̈ړ�
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // �W�����v
        if (Input.GetButtonDown("F") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
