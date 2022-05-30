using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuHandler : MonoBehaviour
{
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button StartButton;
    [SerializeField] private Text alert;
    [SerializeField] private InputField playerName;
    [SerializeField] private Text highestScoreText;
    private void Awake()
    {
        StartButton.onClick.AddListener(StartGame);
        ExitButton.onClick.AddListener(ExitGame);
    }

    private void Start()
    {
        int score = MainManager.Instance.LoadScore();
        Debug.Log(score);
        if (score > 0)
        {
            highestScoreText.text = "Highest Score: " + score + " by " + MainManager.Instance.GetName(); 
        }
    }

    void StartGame()
    {

        if (string.IsNullOrWhiteSpace(playerName.text))
        {
            Debug.Log("Enter Name");
            alert.gameObject.SetActive(true);
            return;
        }
        MainManager.Instance.SetName(playerName.text);
        SceneManager.LoadScene(1);
    }


    void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void SetHighScore(string name, int score)
    {
        highestScoreText.text = "Player " + name + " Has the highest score " + score;
    }
}
