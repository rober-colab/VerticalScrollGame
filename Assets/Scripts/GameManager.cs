using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int hp = 3;
    public int score = 0;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI scoreText;

    [Header("ゲームオーバー")]
    public GameObject gameOverPanel;   // ゲームオーバーパネル

    private bool isGameOver = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        if (isGameOver) return;

        hp -= amount;
        UpdateUI();

        // ダメージ音を鳴らす
        if (AudioManager.Instance != null) AudioManager.Instance.PlayDamaged();

        if (hp <= 0)
        {
            GameOver();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (hpText != null) hpText.text = "HP: " + hp;
        if (scoreText != null) scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f; // ゲームを一時停止

        if (gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    // リスタートボタンから呼ばれる
    public void RestartGame()
    {
        Time.timeScale = 1f; // 時間を元に戻す
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
