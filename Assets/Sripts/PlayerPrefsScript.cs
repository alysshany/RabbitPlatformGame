using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("FirstLevel", "NotFinish");
        PlayerPrefs.SetString("SecondLevel", "NotFinish");
        PlayerPrefs.SetString("ThirdLevel", "NotFinish");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
