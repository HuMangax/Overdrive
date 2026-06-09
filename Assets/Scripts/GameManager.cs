using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { Menu, Playing, GameOver }
    public GameState State { get; private set; }

    public int Score { get; private set; }
    public int HighScore { get; private set; }

    public event System.Action<GameState> OnStateChanged;
    public event System.Action<int> OnScoreChanged;

    private const string HighScoreKey = "HighScore";

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        HighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    void Start()
    {
        SetState(GameState.Menu);
    }

    public void StartGame()
    {
        Score = 0;
        OnScoreChanged?.Invoke(Score);
        SetState(GameState.Playing);
    }

    public void TriggerGameOver()
    {
        if (State == GameState.GameOver) return;
        if (Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetInt(HighScoreKey, HighScore);
            PlayerPrefs.Save();
        }
        SetState(GameState.GameOver);
    }

    public void AddScore(int points)
    {
        if (State != GameState.Playing) return;
        Score += points;
        OnScoreChanged?.Invoke(Score);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SetState(GameState newState)
    {
        State = newState;
        OnStateChanged?.Invoke(newState);
    }
}
