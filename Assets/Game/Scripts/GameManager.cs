using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Timer timer;

    private int score = 0;

    public int lifeCount = 3;

    public static GameManager Instance { get; private set; }

    private void Start()
    {
        Instance = this;
        text.text = "Lifes: " + lifeCount;
    }

    public void LooseLife(bool shouldDie = false)
    {
        if (lifeCount > 0)
        {
            if (shouldDie)
            {
                lifeCount = 0;
            } 
            else
            {
                lifeCount--;
            }
            text.text = "Lifes: " + lifeCount;
            if (lifeCount <= 0)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<PlayerMovement>().isPlayerDead = true;
            }
        }
    }

    public void IncreaseScore(int value = 1)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }

    public void EnableGameOverScreen()
    {
        timer.isActive = false;
        gameOverScreen.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
