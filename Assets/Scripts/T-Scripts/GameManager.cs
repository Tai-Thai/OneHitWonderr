using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton pattern để dễ truy cập

    public bool isPaused = false;
    public int currentLevel = 0;
    public float score = 0;
    public TMP_Text TMP_Score;
    public TMP_Text TMP_currentHP;
    public TMP_Text TMP_instruction;
    public TMP_Text TMP_menuScoreText;
    public GameObject Menu;
    public GameObject ContinueBtn;

    private int keyCount = 0;

    private string[] sceneNames = { "Level-1", "Level-2", "Level-3" };


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Đảm bảo chỉ có một GameManager
        }
    }

    void Start()
    {
        Debug.Log("Game Started at Level: " + currentLevel);
    }

    void Update()
    {
        // Nhấn P để tạm dừng hoặc tiếp tục
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            TMP_menuScoreText.text = "Score " + score;
            Menu.SetActive(true);
            Debug.Log("Game Paused");
        }
        else
        {
            Time.timeScale = 1;
            Menu.SetActive(false);
            Debug.Log("Game Resumed");
        }
    }

    public void ReplayGame()
    {
        currentLevel = 0;
        string sceneName = sceneNames[currentLevel];
        SceneManager.LoadScene(sceneName);
        PlayerScript.Instance.ResetPlayer();
        Menu.SetActive(false);
        isPaused = false;
    }

    // public void IncreaseLevel()
    // {
    //     currentLevel++;
    //     Debug.Log("Level Increased to: " + currentLevel);
    //     // Ở đây có thể load thêm dữ liệu level hoặc khởi tạo logic level mới
    // }

    public void AddScore(float score)
    {
        this.score += score;

        TMP_Score.text = this.score + "";
    }

    public void OnHPChange(float currentHP)
    {
        TMP_currentHP.text = "HP: " + currentHP;
    }

    public void NextLevel()
    {
        if (keyCount > 0)
        {
            currentLevel++;
            if (currentLevel >= sceneNames.Length)
            {
                // player win;
                isPaused = false;
                TogglePause();
                TMP_menuScoreText.text = "Win   " + score;
            }
            else
            {
                string sceneName = sceneNames[currentLevel];
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            OnAlert("You have to find key to go to next level.");

        }

    }

    public void GameOver()
    {
        isPaused = true;
        TMP_menuScoreText.text = "Lose " + score;
        ContinueBtn.SetActive(false);
        TogglePause();
    }

    public void OnAlert(string alertText)
    {
        if (TMP_instruction != null)
        {
            TMP_instruction.text = alertText;
            Invoke("ClearInstructionText", 5f);
        }
        else
        {
            Debug.LogWarning("TMP_instruction is not assigned!");
        }
    }

    public void ClearInstructionText()
    {
        TMP_instruction.text = "";
    }

    public void AddKey()
    {
        keyCount++;
    }
}
