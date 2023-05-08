using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameScene : MonoBehaviour
{
    [SerializeField]
    private Button clickedButton;
    [SerializeField]
    private int index;

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
        PlayerPrefs.SetInt("Level", index);
        FadeInOut.sceneEnd = true;
        //SceneManager.LoadScene("GameScene");
    }
}
