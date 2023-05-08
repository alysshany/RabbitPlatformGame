using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevelScene : MonoBehaviour
{
    [SerializeField]
    private Button clickedButton;

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

        //FadeInOut.sceneEnd = true;
        SceneManager.LoadScene("LevelsScene");
    }
}
