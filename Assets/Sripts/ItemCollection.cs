using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GirlLetter") && gameObject.CompareTag("Girl"))
        {
            PlayerPrefs.SetInt("ActualCountOfLetters", PlayerPrefs.GetInt("ActualCountOfLetters") + 1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BoyLetter") && gameObject.CompareTag("Boy"))
        {
            PlayerPrefs.SetInt("ActualCountOfLetters", PlayerPrefs.GetInt("ActualCountOfLetters") + 1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("GoldenCoin"))
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
            Destroy(collision.gameObject);
        }
    }
}
