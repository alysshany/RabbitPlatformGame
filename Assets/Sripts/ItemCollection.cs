using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GirlLetter") && gameObject.CompareTag("Girl"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BoyLetter") && gameObject.CompareTag("Boy"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("GoldenCoin"))
        {
            Destroy(collision.gameObject);
        }
    }
}
