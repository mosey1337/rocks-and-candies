using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Canvas _ui;
    [SerializeField] private InputField _nameInputField;

    void Awake()
    {
        _nameInputField.text = PlayerPrefs.GetString("UserName");
    }

    public void Save()
    {
        var id = PlayerPrefs.GetInt("UserId");

        var name = _nameInputField.text;

        if (name == null)
        {
            SceneManager.LoadScene("menu");
            return;
        }

        StartCoroutine(UserAPI.UpdateName(id, name, OnUpdateName));
    }

    void OnUpdateName(string json)
    {
        var user = JsonConvert.DeserializeObject<User>(json);

        PlayerPrefs.SetString("UserName", user.name);
        SceneManager.LoadScene("menu");
    }
}
