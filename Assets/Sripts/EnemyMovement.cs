using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private bool returning;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForSecond());
        rigidbody = GetComponent<Rigidbody2D>();
        returning = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(0.5f);

        if (returning)
        {
            rigidbody.velocity = new Vector2(3f, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(-3f, rigidbody.velocity.y);
        }

        returning = !returning;
        
        yield return StartCoroutine(WaitForSecond());
    }
}
