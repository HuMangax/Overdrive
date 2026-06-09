using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject hudPanel;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] TextMeshProUGUI menuHighScoreText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI gameOverHighScoreText;

    void Start()
    {
        GameManager.Instance.OnStateChanged += HandleStateChanged;
        GameManager.Instance.OnScoreChanged += HandleScoreChanged;
        HandleStateChanged(GameManager.Instance.State);
        HandleScoreChanged(GameManager.Instance.Score);
    }

    void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnStateChanged -= HandleStateChanged;
            GameManager.Instance.OnScoreChanged -= HandleScoreChanged;
        }
    }

    void HandleStateChanged(GameManager.GameState state)
    {
        mainMenuPanel.SetActive(state == GameManager.GameState.Menu);
        hudPanel.SetActive(state == GameManager.GameState.Playing);
        gameOverPanel.SetActive(state == GameManager.GameState.GameOver);

        if (state == GameManager.GameState.Menu)
            menuHighScoreText.text = $"Best Score Ever: {GameManager.Instance.HighScore}";

        if (state == GameManager.GameState.GameOver)
        {
            finalScoreText.text = $"Score: {GameManager.Instance.Score}";
            gameOverHighScoreText.text = $"Best Score Ever: {GameManager.Instance.HighScore}";
        }
    }

    void HandleScoreChanged(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void OnStartButtonPressed() => GameManager.Instance.StartGame();
    public void OnRestartButtonPressed() => GameManager.Instance.RestartGame();
}
