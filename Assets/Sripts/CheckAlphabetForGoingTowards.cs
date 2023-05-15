using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CheckAlphabetForGoingTowards : MonoBehaviour
{
    [SerializeField] private int countOfLetters;
    [SerializeField] private GameObject canvasToOpen;
    [SerializeField] private string answer;
    [SerializeField] private Button buttonToClick;

    //Panel of letters
    [SerializeField]
    private Transform _letterPanel;
    [SerializeField]
    private GameObject _letterPanelPrefab;

    //Panel of QA's letters ANSWER
    [SerializeField]
    private Transform _letterPanelOfQA;
    [SerializeField]
    private GameObject _letterPanelPrefabOfQA;

    [SerializeField] private GameObject canvasOfWinToOpen;

    char[] stringChars;
    char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();


    // Start is called before the first frame update
    void Start()
    {
        stringChars = new char[countOfLetters];
        PlayerPrefs.SetInt("ActualCountOfLetters", 0);
        CreatingButtonsForAnswer();
        Shuffle(ref stringChars);

        buttonToClick.onClick.AddListener(CheckingTheAnswer);

        for (int i = 0; i < stringChars.Length; i++)
        {
            var button = Instantiate(_letterPanelPrefab, _letterPanel);
            button.GetComponent<Button>().onClick.AddListener(() => ChooseLetterButton(button.GetComponent<Button>()));
            button.GetComponentInChildren<Text>().text = stringChars[i].ToString();
        }

        for (int i = 0; i < answer.Length; i++)
        {
            var button = Instantiate(_letterPanelPrefabOfQA, _letterPanelOfQA);
            button.GetComponent<Button>().onClick.AddListener(() => ReturnButton(button.GetComponent<Button>()));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckingTheAnswer()
    {
        bool checkingValue = true;
        string checkingString = "";

        foreach (Button button in _letterPanelOfQA.GetComponentsInChildren<Button>())
        {
            checkingString += button.GetComponentInChildren<Text>().text;

            if (button.GetComponentInChildren<Text>().text == "")
            {
                checkingValue = false;
                return;
            }
        }

        if (checkingValue && checkingString.ToUpper() == answer.ToUpper())
        {
            canvasToOpen.SetActive(false);
            canvasOfWinToOpen.SetActive(true);
            
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Boy") || collision.gameObject.CompareTag("Girl")) && PlayerPrefs.GetInt("ActualCountOfLetters") == countOfLetters)
        {
            Time.timeScale = 0.0f;
            canvasToOpen.SetActive(true);
        }
    }

    public void ReturnButton(Button btn)
    {
        try
        {
            Button button = _letterPanel.GetComponentsInChildren<Button>()
                .Where(x => x.interactable == false && x.GetComponentInChildren<Text>().text == btn.GetComponentInChildren<Text>().text).FirstOrDefault();

            btn.GetComponentInChildren<Text>().text = "";
            button.interactable = true;
        }
        catch { }
    }

    public void CreatingButtonsForAnswer()
    {
        for (int i = 0; i < countOfLetters; i++)
        {
            stringChars[i] = answer.ToUpper().ToCharArray()[i];
        }
    }

    public static void Shuffle(ref char[] list)
    {
        System.Random random = new System.Random();
        int n = list.Length;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            char value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public void ChooseLetterButton(Button sender)
    {
        foreach (Button button in _letterPanelOfQA.GetComponentsInChildren<Button>())
        {
            if (button.GetComponentInChildren<Text>().text == "")
            {
                button.GetComponentInChildren<Text>().text = sender.GetComponentInChildren<Text>().text;
                sender.interactable = (false);
                return;
            }
        }
    }
}
