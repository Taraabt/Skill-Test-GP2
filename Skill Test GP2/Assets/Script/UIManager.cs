using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static Action<int> Stamina;
    public static Action<int> Score;
    public static Action<int> Health;

    [SerializeField] Image staminaBar;
    [SerializeField] Image healthBar;
    [SerializeField]float stamina = 1000;
    [SerializeField]float hp = 10;
    [SerializeField]TMP_Text scoreText;
    int score;
    string str;

    private void Awake()
    {
        str=scoreText.text;
        UpdateScore(0);
    }

    private void OnEnable()
    {
        Score += UpdateScore;
        Stamina += UpdateStamina;
        Health += UpdateHealth;
    }

    private void OnDisable()
    {
        Score -= UpdateScore;
        Stamina -= UpdateStamina;
        Health -= UpdateHealth;
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

}
