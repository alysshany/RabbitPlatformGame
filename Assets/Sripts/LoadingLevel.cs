using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingLevel : MonoBehaviour
{
    [SerializeField]
    private Button clickedButton;
    [SerializeField]
    private List<GameObject> listOfLevels;

    // Start is called before the first frame update
    void Start()
    {
        clickedButton.onClick.AddListener(LoadScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadScene()
    {
        PlayerPrefs.SetString("Alive", "Yes");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("GameScene");
        GameObject levelToOpen = listOfLevels[PlayerPrefs.GetInt("Level")];
        
        levelToOpen.SetActive(true);
    }
}
