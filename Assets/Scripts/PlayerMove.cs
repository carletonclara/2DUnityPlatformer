using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveForce = 365f;
    public float playerSpeed = 3f;
    private bool facingRight = true;
    public float playerJumpPower = 100f;
    private float moveX;

    //private Animator anim;
    private Rigidbody2D rb2d;

    private Transform playerTransform;

    public GameObject deathScreen;
    public GameObject winScreen;

    public Text countText;
    private int count;

    void Awake()
    {
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText(count);
    }

    // Update is called once per frame
    void Update(){
        Move();
        Die();
    }


    void Move(){
        moveX = Input.GetAxis("Horizontal");

        //anim.SetFloat("Speed", Mathf.Abs(h));

        if (moveX * rb2d.velocity.x < playerSpeed)
            rb2d.AddForce(Vector2.right * moveX * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > playerSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * playerSpeed, rb2d.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (moveX < 0 && !facingRight)
        {
            FlipPlayer();
        }
        else if(moveX < 0 && facingRight)
        {
            FlipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void Die()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 temp = transform.position;
        temp.y = playerTransform.position.y;
        if (temp.y < -500)
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0f;

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Carrot"))
        {
            Destroy(other.gameObject);
            count = count + 1;
            SetCountText(count);
        }

        if (other.gameObject.CompareTag("Chest"))
        {
            winScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void SetCountText(int num)
    {
        countText.text = "X " + num.ToString();
    }
}
