using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLoadingLevel : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> listOfLevels;
    [SerializeField]
    private GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("Alive", "Yes");
        Time.timeScale = 1.0f;
        GameObject levelToOpen = listOfLevels[PlayerPrefs.GetInt("Level")];
        levelToOpen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("Alive") == "No")
        {
            Time.timeScale = 0.0f;
            gameOverCanvas.SetActive(true);
        }
    }
}
