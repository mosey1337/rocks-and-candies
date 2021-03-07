using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameOverUI _gameOverUI;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameUI _gameUI;
    [SerializeField] private UserAPI _userAPI;
    private bool _isGameOver = false;
    private int _score = 0;
    private int _health = 5;
    
    void Start()
    {
        _gameOverUI.Deactivate();
    }

    void Update() 
    {
        if (_isGameOver)
        {
            return;
        }


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider != null)
            {
                var target = hit.collider.GetComponent<Target>();

                target.Tap(ref _score, ref _health);

                _gameUI.UpdateHealthText(_health);
                _gameUI.UpdateScoreText(_score);

                Destroy(target.gameObject);

                if (_health <= 0) 
                {
                    Finish();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        var target = col.GetComponent<Target>();

        target.Drop(ref _score, ref _health);

        if (_health <= 0) 
        {
            Finish();
            return;
        }

        _gameUI.UpdateHealthText(_health);
    }

    void Finish()
    {
        var id = PlayerPrefs.GetInt("UserId");
        _isGameOver = true;
        _gameUI.Deactivate();
        _gameOverUI.UpdateScore(_score);
        StartCoroutine(UserAPI.UpdateScore(id, _score, OnScoreUpdated));
        _gameOverUI.Activate();
    }

    void OnScoreUpdated(string json)
    {
        var user = JsonConvert.DeserializeObject<User>(json);

        PlayerPrefs.SetInt("HighScore", user.score);
    }

    public void Retry()
    {
        SceneManager.LoadSceneAsync("level");
    }
}
