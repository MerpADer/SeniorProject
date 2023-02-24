using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Initialize Components
    private Rigidbody2D rb;
    private SpriteRenderer spr;
    private Animator anim;
    private AudioSource audioSource;

    // used for horizontal movement
    [Header("Stats")]
    [SerializeField] float speed;

    // will be used to store playerprefs in the future
    [Header("Keys")]
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode attackKey;
    public KeyCode rollKey;

    //[Header("Audio Clips")]
    //[SerializeField] AudioClip walk;

    enum PlayerState
    {
        Normal,
        Rolling
    }

    private PlayerState playerState;

    void Awake()
    {
        // Assign components
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        // Set player state
        playerState = PlayerState.Normal;
    }

    void Update()
    {
        if (playerState == PlayerState.Normal)
        {
            HorizontalMovement();
            Attack();
            Roll();
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(attackKey) && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack"))
        {
            anim.SetTrigger("isAttacking");
            rb.velocity = new Vector2(0, 0);
        }
    }

    void Roll()
    {
        // checks to see if the roll key is pressed an it isn't in the middle of a roll
        if (Input.GetKeyDown(rollKey) && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerRoll"))
        {
            // set the player status to rolling
            anim.SetTrigger("isRolling");
            playerState = PlayerState.Rolling;
            // move the player
            rb.velocity = new Vector2(5.5f * playerDir(), rb.velocity.y);
            Invoke(nameof(StopRoll), 0.22f);
        }
    }

    // gets the players direction and returns -1 or 1 to multiply to a movement
    int playerDir()
    {
        if (spr.flipX)
            return -1;
        return 1;
    }

    void StopRoll()
    {
        rb.velocity = new Vector2(0, 0);
        playerState = PlayerState.Normal;
    }

    void HorizontalMovement()
    {
        // If the player presses the left or right keys,
        // it will move them in that direction and change their velocity towards it
        if (Input.GetKey(leftKey))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            spr.flipX = true;
            anim.SetBool("isWalking", true);
            GetComponentInChildren<AttackStats>().gameObject.transform.localScale = new Vector2(-1, 1);
            audioSource.enabled = true;
        }
        if (Input.GetKey(rightKey))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            spr.flipX = false;
            anim.SetBool("isWalking", true);
            GetComponentInChildren<AttackStats>().gameObject.transform.localScale = new Vector2(1, 1);
            audioSource.enabled = true;
        }
        // when they let go of both keys it sets x vel to 0 and turns off animation
        if (!Input.GetKey(leftKey) && !Input.GetKey(rightKey))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetBool("isWalking", false);
            audioSource.enabled = false;
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        // freezes the player so they don't fall off of a slope object
        if (!Input.GetKey(leftKey) && !Input.GetKey(rightKey) && collision.gameObject.tag == "Slope")
        {
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // when they leave a slope I set the velocity to 0 because otherwise
        // it will fly off
        if (collision.gameObject.tag == "Slope")
        {
            rb.velocity = new Vector2(0, 0);
        }
        rb.gravityScale = 1;
    }
}
