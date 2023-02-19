using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class dino_move : MonoBehaviour
{
    public GameManager gameManager;
    public AudioClip audioJump;
    public AudioClip audioItem;
    public AudioClip audioDie;
    public AudioClip audioFinish;

    public float maxSpeed;
    public float jumpPower;
    
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    AudioSource audioSource;
    CapsuleCollider capsuleCollider;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();


    }


    void FixedUpdate()
    {
        // Move by key control
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        // Max Speed
        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

        // Landing Platform
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 10.5f)
                    anim.SetBool("isJumping", false);
            }
        }
    }

    void PlaySound(string action)
    {
        switch (action)
        {
            case "JUMP":
                audioSource.clip = audioJump;
                break;

            case "ITEM":
                audioSource.clip = audioItem;
                break;

            case "DIE":
                audioSource.clip = audioDie;
                break;

            case "FINISH":
                audioSource.clip = audioFinish;
                break;
        }
        audioSource.Play();
    }


    void Update()
    {

        // Jump!
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);

            PlaySound("JUMP");
        }

        // Stop Speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        // Direction Sprite
        if(Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        // Animation
        if (Mathf.Abs(rigid.velocity.x) < 0.4)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
    }
    


    public void OnDie()
    {
        PlaySound("DIE");
    }

    public void OnClear()
    {
        PlaySound("FINISH");
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            // Point
            bool isCompost = collision.gameObject.name.Contains("compost");
            bool isTrash = collision.gameObject.name.Contains("trash");
            bool isRecycle = collision.gameObject.name.Contains("recycle");

            if(rigid.gameObject.name.Contains("Compost") && isCompost)
            {
                gameManager.stagePoint += 100;
            }

            else if (rigid.gameObject.name.Contains("Trash") && isTrash)
            {
                gameManager.stagePoint += 100;
            }

            else if (rigid.gameObject.name.Contains("Recycle") && isRecycle)
            {
                gameManager.stagePoint += 100;
            }
   
            else
            {
                gameManager.stagePoint -= 100;
            }

            // Deactive Item
            collision.gameObject.SetActive(false);
            //PlaySound("ITEM");

        }
        else if (collision.gameObject.tag == "Finish")
        {
            gameManager.Clear();
        }

        
    }

   
}
