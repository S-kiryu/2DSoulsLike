using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�̈ړ����x
    /// </summary>
    public float moveSpeed = 5f;
    //�v���C�x�[�g�ϐ�
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
        //�v���C���[�̈ړ�

        float moveX = Input.GetAxisRaw("Horizontal");
        //rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.LeftShift) || _isRoll)
        {

            // �V�t�g���������u��1�񂾂��Ă΂��
            Debug.Log("����I");

            //�����u�Ԉړ�
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
