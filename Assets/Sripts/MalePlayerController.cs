using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalePlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Animator animatorSpring;
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
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("MovingPlatform") || collision.gameObject.CompareTag("Girl") || collision.gameObject.CompareTag("BreakingPlatform"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Spring"))
        {
            animatorSpring = collision.gameObject.GetComponent<Animator>();
            animatorSpring.SetBool("Up", true);
            rigidbody.velocity = new Vector2(0, 8f);
            isGrounded = false;
            StartCoroutine(WaitForSecondsSpring(animatorSpring));
        }
        if (collision.gameObject.CompareTag("Enemy") && isGrounded)
        {
            animator.SetBool("Hurt", true);
            StartCoroutine(WaitForSecond());

        }
        if (collision.gameObject.CompareTag("HalfEnemy"))
        {
            animator.SetBool("Hurt", true);
            StartCoroutine(WaitForSecond());

        }
        if (collision.gameObject.CompareTag("FlyingEnemy"))
        {
            animator.SetBool("Hurt", true);
            StartCoroutine(WaitForSecond());

        }
        if (collision.gameObject.CompareTag("LevelArm"))
        {
            animatorSpring = collision.gameObject.GetComponent<Animator>();
            animatorSpring.SetBool("Active", !animatorSpring.GetBool("Active"));
        }
        if (collision.gameObject.CompareTag("ToDyingPlatform"))
        {
            PlayerPrefs.SetString("Alive", "No");
            //������� ���
        }
        if (collision.gameObject.CompareTag("Enemy") && !isGrounded)
        {
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("BreakingPlatform"))
        {
            StartCoroutine(WaitForSecondToDestroy(collision.gameObject));
        }
    }

    IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Hurt", false);
        PlayerPrefs.SetString("Alive", "No");
    }

    IEnumerator WaitForSecondToDestroy(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    IEnumerator WaitForSecondsSpring(Animator animatorSpring)
    {
        yield return new WaitForSeconds(0.5f);
        animatorSpring.SetBool("Up", false);
    }
}
