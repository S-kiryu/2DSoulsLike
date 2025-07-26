using UnityEngine;

public class PlayerRoll : MonoBehaviour
{
    //回避する距離
    public float rollSpeed = 10f;
    //回避している時間
    public float rollDuration = 0.4f;
    //移動スピード
    public float moveSpeed = 1.0f;
    //ロールキーを設定
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

            //回転する距離を計算
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

        // 移動方向は現在の入力方向、なければ右
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        rollDirection = new Vector2(moveX, moveY).normalized;
        if (rollDirection == Vector2.zero)
            rollDirection = Vector2.right; // デフォルト右に転がる

        // 無敵状態をつける場合はここでフラグ立てる
        GetComponent<Collider2D>().enabled = false;
    }

    void EndRoll()
    {
        playerMoveCheck = false;
        isRolling = false;
        rb.velocity = Vector2.zero;
        transform.rotation = originalRotation;

        //無敵解除
        GetComponent<Collider2D>().enabled = true;
    }

  
}