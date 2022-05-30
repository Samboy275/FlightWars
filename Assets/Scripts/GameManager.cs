using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class GameManager : MonoBehaviour
{
    // game objects
    [SerializeField]
    private Text HighScoreText;
    [SerializeField]
    private Text welcomeText;
    [SerializeField] 
    private Text scoreText;
    [SerializeField]
    private GameObject gameOverMenu;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private Button RestartButton;
    [SerializeField]
    private Button mainMenuButton;
    private GameObject player;
    private GameObject spawnManager;
    // control variables
    private bool isPaused;
    public int score{get; private set;}


    // singleton instance
    public static GameManager Instance { get; private set; } 

    void Awake ()
    {
        score = 0;
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        isPaused = false;
        pauseMenu.SetActive(false);
        player = GameObject.Find("Player");
        spawnManager = GameObject.Find("SpwanManager");
        player.SetActive(false);
        gameOverMenu.SetActive(false);
        mainMenuButton.onClick.AddListener(MainMenu);
        RestartButton.onClick.AddListener(Restart);
        mainMenuButton.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        
    }

    void Start()
    {
        spawnManager.GetComponent<SpwanManager>().StartSpawning();
        player.SetActive(true);
        StartCoroutine(WelcomePlayer(MainManager.Instance.GetName()));
    }
    void Update ()
    {
        // pause game if player press's p
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                mainMenuButton.gameObject.SetActive(false);
                player.GetComponent<PlayerController>().enabled = true;
                isPaused = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                mainMenuButton.gameObject.SetActive(true);
                player.GetComponent<PlayerController>().enabled = false;
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        } 
    }

    public void GameOver()
    {
        mainMenuButton.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        player.SetActive(false);
        spawnManager.GetComponent<SpwanManager>().StopSpawning();
        gameOverMenu.SetActive(true);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {   
            GameObject en = enemy;
            Destroy(enemy);
        }
        welcomeText.enabled = true;
        if(MainManager.Instance.SaveScore(score))
        {
            welcomeText.text = "New High Score Achieved!!!!";
        }
        else
        {
            welcomeText.text = "Better Luck Next Time";
        }
    }

    private void MainMenu ()
    {
        // reloads scene
        SceneManager.LoadScene(0);
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score; 
    }


    IEnumerator WelcomePlayer(string name)
    {
        int highScore = MainManager.Instance.LoadScore();
        if (highScore > 0)
        {
            string hname = MainManager.Instance.GetName();
            HighScoreText.text = "Highest Score " + hname + " " + highScore;
        }
        welcomeText.text = "Welcome " + name + " And Good Luck";
        welcomeText.enabled = true;
        yield return new WaitForSeconds(3);
        welcomeText.enabled = false;
    }
    
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
