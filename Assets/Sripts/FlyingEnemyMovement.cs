using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMovement : MonoBehaviour
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
        yield return new WaitForSeconds(1f);

        if (returning)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 3f);
        }
        else
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, -3f);
        }

        returning = !returning;

        yield return StartCoroutine(WaitForSecond());
    }
}
