using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class MainMenu : MonoBehaviour
{
    
    void Start()
    {
        // PlayerPrefs.DeleteAll();

        if (!PlayerPrefs.HasKey("UserName"))
        {
            StartCoroutine(UserAPI.Create(OnUserCreated, OnError));
        }
    }

    public void OnError(string error)
    {
        Debug.Log(error);
    }

    public void OnUserCreated(string json)
    {
        var user = JsonConvert.DeserializeObject<User>(json);

        PlayerPrefs.SetInt("UserId", user.id);
        PlayerPrefs.SetString("UserName", user.name);
        PlayerPrefs.SetInt("UserScore", user.score);
    }


    public void StartGame() 
    {
        SceneManager.LoadSceneAsync("level");
    }

    public void Leaderboard() 
    {
        SceneManager.LoadSceneAsync("leaderboard");
    }

    public void Settings() 
    {
        SceneManager.LoadSceneAsync("settings");
    }
}
