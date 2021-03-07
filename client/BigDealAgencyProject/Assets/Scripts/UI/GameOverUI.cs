using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Canvas _ui;
    [SerializeField] private Text _scoreText;

    public void Deactivate()
    {
        _ui.enabled = false;
    }

    public void Activate()
    {
        _ui.enabled = true;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = "Score: " + score;
    }
}
