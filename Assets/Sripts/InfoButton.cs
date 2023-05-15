using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoButton : MonoBehaviour
{
    [SerializeField] private GameObject canvasToOpen;
    [SerializeField] private Button buttonToClick;

    // Start is called before the first frame update
    void Start()
    {
        buttonToClick.onClick.AddListener(Openning);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Openning()
    {
        Time.timeScale = 0.0f;
        canvasToOpen.SetActive(true);
    }
}
