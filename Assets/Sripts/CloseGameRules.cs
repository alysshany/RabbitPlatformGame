using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseGameRules : MonoBehaviour
{
    [SerializeField] private Button buttonToClick;

    // Start is called before the first frame update
    void Start()
    {
        buttonToClick.onClick.AddListener(Closing);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Closing()
    {
        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);
    }
}
