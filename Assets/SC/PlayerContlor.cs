using UnityEngine;

public class PlayerRoll : MonoBehaviour
{
    //������鋗��
    public float rollSpeed = 10f;
    //������Ă��鎞��
    public float rollDuration = 0.4f;
    //�ړ��X�s�[�h
    public float moveSpeed = 1.0f;
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
        float moveX = Input.GetAxisRaw("Horizontal");


        if (playerMoveCheck == false)
        {
            rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

            if (moveX == 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (moveX == 1)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            
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

        //���G����
        GetComponent<Collider2D>().enabled = true;
    }

  
}