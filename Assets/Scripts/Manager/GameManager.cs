using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private float gameSpeed = 1f;
    private bool isPaused = false;
    public int playerMoney = 0;
    public int playerScore = 0;
    public int wantedLevel = 0;
    public int maxWantedLevel = 6;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    
    public void AddMoney(int amount)
    {
        playerMoney += amount;
        UIManager.Instance?.UpdateMoneyDisplay(playerMoney);
    }
    
    public void AddScore(int amount)
    {
        playerScore += amount;
        UIManager.Instance?.UpdateScoreDisplay(playerScore);
    }
    
    public void IncreaseWantedLevel()
    {
        if (wantedLevel < maxWantedLevel)
        {
            wantedLevel++;
            UIManager.Instance?.UpdateWantedDisplay(wantedLevel);
            PoliceManager.Instance?.SpawnPolice();
        }
    }
    
    public void DecreaseWantedLevel()
    {
        if (wantedLevel > 0)
        {
            wantedLevel--;
            UIManager.Instance?.UpdateWantedDisplay(wantedLevel);
        }
    }
    
    public void ResetWantedLevel()
    {
        wantedLevel = 0;
        UIManager.Instance?.UpdateWantedDisplay(wantedLevel);
    }
    
    public void PauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        UIManager.Instance?.ShowPauseMenu(isPaused);
    }
    
    public void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public bool IsPaused => isPaused;
    public float GameSpeed => gameSpeed;
}
