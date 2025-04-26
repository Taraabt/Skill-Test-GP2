using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static Action<int> Stamina;
    public static Action<int> Score;
    public static Action Lose;
    public static Action Win;
    public static Action Pause;
    public static Action<int> Health;


    [SerializeField] Image staminaBar;
    [SerializeField] Image healthBar;
    [SerializeField]float stamina = 1000;
    [SerializeField]float hp = 10;
    [SerializeField]TMP_Text scoreText;
    [SerializeField]GameObject loseScreen;
    [SerializeField]GameObject winScreen;
    [SerializeField]GameObject pauseMenu;
    int score;
    string str;
    bool isPaused;

    private void Awake()
    {
        isPaused = false;
        str=scoreText.text;
        UpdateScore(0);
    }

    private void OnEnable()
    {
        Pause += PauseGame;
        Win += WinScreen;
        Lose += LoseScreen;
        Score += UpdateScore;
        Stamina += UpdateStamina;
        Health += UpdateHealth;
    }

    private void OnDisable()
    {
        Pause -= PauseGame;
        Win -= WinScreen;
        Lose -= LoseScreen;
        Score -= UpdateScore;
        Stamina -= UpdateStamina;
        Health -= UpdateHealth;
    }

    public void PauseGame()
    {
        if (isPaused) {
            isPaused = false;
            Time.timeScale = 1;
            Player.activeInput?.Invoke();
            Cursor.lockState = CursorLockMode.Locked;
            pauseMenu.SetActive(false);
        }
        else
        {
            isPaused = true;
            Player.deactiveInput?.Invoke();
            Cursor.lockState = CursorLockMode.Confined;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void WinScreen()
    {
        isPaused = true;
        winScreen.SetActive(true);
    }

    private void UpdateHealth(int value)
    {
        healthBar.fillAmount = value /hp;
    }

    private void UpdateStamina(int value)
    {
        staminaBar.fillAmount = value / stamina;
    }

    private void UpdateScore(int value)
    {
        score=score+value;
        scoreText.text = str+score.ToString();
    }
    public void LoseScreen()
    {
        isPaused=true;
        loseScreen.SetActive(true);
    }

    public void StartGame()
    {
        Player.activeInput?.Invoke();
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
