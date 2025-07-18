using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// プレイヤーの移動速度
    /// </summary>
    public float moveSpeed = 5f;
    //プライベート変数
    private Rigidbody2D rb;
    private int move;

    private bool _isRoll = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの移動

        float moveX = Input.GetAxisRaw("Horizontal");
        //rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.LeftShift) || _isRoll)
        {

            // シフトを押した瞬間1回だけ呼ばれる
            Debug.Log("回避！");

            //爆速瞬間移動
            //transform.position = new Vector2(this.transform.position.x + moveX, this.transform.position.y);

            rb.velocity = new Vector2(moveX * moveSpeed * 10, rb.velocity.y);

            //if()
        }
        else
        {
            rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        }

    }
}
