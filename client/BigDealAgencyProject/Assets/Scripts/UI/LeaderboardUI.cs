using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;


public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] private Canvas _ui;
    [SerializeField] private GameObject _prefabRecordView;
    [SerializeField] private Transform _transform;
    private float _offset = 0f;

    void Start()
    {
        StartCoroutine(LeaderboardAPI.Get(LoadLeaderboard));
    }

    void LoadLeaderboard(string json)
    {
        var users = JsonConvert.DeserializeObject<List<User>>(json);

        int position = 1;

        foreach (var user in users)
        {
            var record = Instantiate(_prefabRecordView, _transform);
            
            record.GetComponent<LeaderboardRow>().SetNameText(string.Format("{0}. {1}", position, user.name));

            record.GetComponent<LeaderboardRow>().SetScoreText(string.Format("Score: {0}", user.score));

            position += 1;
        }
    }

    private Vector3 GetPositionWithOffset(Vector3 position)
    {
        position.y += _offset;
        
        return position;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadSceneAsync("menu");
    }
}
