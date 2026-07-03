using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI wantedText;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject gameOverPanel;
    
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
    
    public void UpdateMoneyDisplay(int money)
    {
        if (moneyText)
            moneyText.text = $"Money: ${money}";
    }
    
    public void UpdateScoreDisplay(int score)
    {
        if (scoreText)
            scoreText.text = $"Score: {score}";
    }
    
    public void UpdateWantedDisplay(int level)
    {
        if (wantedText)
        {
            string stars = "";
            for (int i = 0; i < level; i++)
                stars += "★";
            
            wantedText.text = level > 0 ? $"Wanted: {stars}" : "";
            
            // Change color based on level
            Color wantedColor = level switch
            {
                0 => Color.green,
                1 or 2 => Color.yellow,
                3 or 4 => new Color(1f, 0.5f, 0f), // Orange
                _ => Color.red
            };
            
            wantedText.color = wantedColor;
        }
    }
    
    public void ShowPauseMenu(bool show)
    {
        if (pauseMenuPanel)
            pauseMenuPanel.SetActive(show);
    }
    
    public void ShowGameOverPanel(bool show)
    {
        if (gameOverPanel)
            gameOverPanel.SetActive(show);
    }
    
    public void ResumeGame()
    {
        GameManager.Instance?.PauseGame();
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameManager.Instance?.GameOver();
    }
}
