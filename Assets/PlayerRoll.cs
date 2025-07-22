using UnityEngine;

public class PlayerRoll : MonoBehaviour
{
    public float rollSpeed = 10f;
    public float rollDuration = 0.4f;
    //���[���L�[��ݒ�
    public KeyCode rollKey = KeyCode.LeftShift;

    private bool isRolling = false;
    private bool playerMoveCheck = false;
    private float rollTimer = 0f;
    private Vector2 rollDirection;
    private Rigidbody2D rb;
    private Quaternion originalRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (playerMoveCheck = false)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
        }

        if (!isRolling && Input.GetKeyDown(rollKey))
        {
            StartRoll();
        }

        if (isRolling)
        {
            rollTimer -= Time.deltaTime;
            rb.velocity = rollDirection * rollSpeed;

            //��]���鋗�����v�Z
            transform.Rotate(0f, 0f,-1* Time.deltaTime);

            if (rollTimer <= 0f)
            {
                EndRoll();
            }
        }
    }

    void StartRoll()
    {
        playerMoveCheck = true;
        isRolling = true;
        rollTimer = rollDuration;

        // �ړ������͌��݂̓��͕����A�Ȃ���ΉE
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        rollDirection = new Vector2(moveX, moveY).normalized;
        if (rollDirection == Vector2.zero)
            rollDirection = Vector2.right; // �f�t�H���g�E�ɓ]����

        // ���G��Ԃ�����ꍇ�͂����Ńt���O���Ă�
        GetComponent<Collider2D>().enabled = false;
    }

    void EndRoll()
    {
        playerMoveCheck = false;
        isRolling = false;
        rb.velocity = Vector2.zero;
        transform.rotation = originalRotation;

        // ���G�����Ȃ�
        GetComponent<Collider2D>().enabled = true;
    }
}