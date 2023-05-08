using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterUp : MonoBehaviour
{

    private void OnMouseUpAsButton()
    {
        if (gameObject.CompareTag("ClickLetter") )
        {
            PlayerPrefs.SetInt("ActualCountOfLetters", PlayerPrefs.GetInt("ActualCountOfLetters") + 1);
            Destroy(this.gameObject);
        }
    }
}
