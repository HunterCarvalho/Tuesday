using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController8 : MonoBehaviour
{
    public LayerMask whatIsGround;
    private float horizontal;
    private float speed = 20f;
    private float jumpingPower = 14.1f;
    public bool flip;
    private bool isGrounded;
    public float jumpForce;
    private bool gameOver = false;
    public bool hasTitle;
    public float titleSpeed;
    public float titleJumpingPower;
    public Transform groundPoint;
    bool facingRight = true;
    public AudioClip collectSound;
    private AudioSource playerAudio;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .2f, whatIsGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(0f, jumpForce, 0f);
        }

    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOver = true;
            Debug.Log("Game Over.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasTitle = true;
            titleSpeed = speed + 2f;
            speed = titleSpeed;
            titleJumpingPower = jumpingPower + 2f;
            jumpingPower = titleJumpingPower;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(collectSound, 1.0f);
        }
    }
}
