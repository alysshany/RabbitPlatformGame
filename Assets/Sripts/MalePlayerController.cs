using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalePlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxisRaw("HorizontalWASD");
        rigidbody.velocity = new Vector2(dir * 3f, rigidbody.velocity.y);

        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rigidbody.velocity = new Vector2(0, 6f);
            isGrounded = false;
        }
        
        if (dir > 0f)
        {
            animator.SetBool("Running", true);
            spriteRenderer.flipX = false;
        }
        else if (dir < 0f)
        {
            animator.SetBool("Running", true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("MovingPlatform"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Spring"))
        {
            Animator animatorSpring = collision.gameObject.GetComponent<Animator>();
            animatorSpring.SetBool("Up", true);
            rigidbody.velocity = new Vector2(0, 8f);
            isGrounded = false;
            animator.SetBool("Up", false);
        }
        if (collision.gameObject.CompareTag("Enemy") && isGrounded)
        {
            animator.SetBool("Hurt", true);
            StartCoroutine(WaitForSecond());

        }
        if (collision.gameObject.CompareTag("FlyingEnemy"))
        {
            animator.SetBool("Hurt", true);
            StartCoroutine(WaitForSecond());

        }
        if (collision.gameObject.CompareTag("Enemy") && !isGrounded)
        {
            Destroy(collision.gameObject);

        }
    }

    IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Hurt", false);
    }

    IEnumerator WaitForSecondsSpring()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Up", false);
    }
}
