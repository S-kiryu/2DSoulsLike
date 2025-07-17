using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�v���C���[�̈ړ����x
    public float speed = 5f;
    //�v���C�x�[�g�ϐ�
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = 0.0f;
        float horizontalKey = Input.GetAxis("Horizontal");

        //�v���C���[�̈ړ�
        if (horizontalKey > 0.0f)
        {
            xSpeed = speed;
        }
        else if (horizontalKey < 0.0f)
        {
            xSpeed = -speed;
        }
        else 
        {
            xSpeed = 0.0f;
        }

        rb.velocity = new Vector2(xSpeed, rb.velocity.y);

    }
}
