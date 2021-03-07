using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeaderboardRow : MonoBehaviour
{
    
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _scoreText;

    public void SetScoreText(string text)
    {
        _scoreText.text = text;
    }

    public void SetNameText(string text)
    {
        _nameText.text = text;
    }
}
