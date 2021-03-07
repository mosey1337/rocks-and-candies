using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
    [SerializeField] private Canvas _ui;
    [SerializeField] private Text _healthText;
    [SerializeField] private Text _scoreText;

    public void Activate()
    {
        _ui.enabled = true;
    }

    public void Deactivate()
    {
        _ui.enabled = false;
    }

    public void UpdateHealthText(int health) {
        _healthText.text = "Health: " + health;
    }

    public void UpdateScoreText(int score) {
        _scoreText.text = "Score: " + score;
    }
}
