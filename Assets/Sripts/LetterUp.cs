using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterUp : MonoBehaviour
{

    private void OnMouseUpAsButton()
    {
        Destroy(this.gameObject);
    }
}
