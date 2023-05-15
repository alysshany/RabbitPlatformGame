using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] private Text textField;
    [SerializeField] private GameObject buttonOfSecondLevel;
    [SerializeField] private GameObject buttonOfThirdLevel;
    [SerializeField] private GameObject countOfCoinsForSecond;
    [SerializeField] private GameObject countOfCoinsForThird;

    // Start is called before the first frame update
    void Start()
    {
        buttonOfSecondLevel.SetActive(false);
        countOfCoinsForSecond.SetActive(true);

        buttonOfThirdLevel.SetActive(false);
        countOfCoinsForThird.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        textField.text = PlayerPrefs.GetInt("Coins").ToString();

        if (PlayerPrefs.GetInt("Coins") >= 10 && PlayerPrefs.GetString("FirstLevel") == "Finish")
        {
            buttonOfSecondLevel.SetActive(true);
            countOfCoinsForSecond.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Coins") >= 20 && PlayerPrefs.GetString("FirstLevel") == "Finish" && PlayerPrefs.GetString("SecondLevel") == "Finish")
        {
            buttonOfThirdLevel.SetActive(true);
            countOfCoinsForThird.SetActive(false);
        }

    }
}
