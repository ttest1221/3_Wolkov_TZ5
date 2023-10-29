using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro _scoreText;
    [SerializeField] private Text _nicknameText;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _gameGO;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _nicknamePanel;
    [SerializeField] private Button _acceptNicknameButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private InputField _nicknameInput;


    public LeaderBoard leaderBoard;
    public SaveManager saveManager;
    public string nickname;
    public float score;

    private void Start()
    {
        _menu.SetActive(false);
        _gameOverPanel.SetActive(false);
        _acceptNicknameButton.onClick.AddListener(() => AcceptNicknameClick());
        _restartButton.onClick.AddListener(() => RestartClick());
        _menuButton.onClick.AddListener(() => MenuClick());
    }

    private void AcceptNicknameClick()
    {
        nickname = _nicknameInput.text;
        _gameGO.SetActive(true);
        _menu.SetActive(true);
        _nicknamePanel.SetActive(false);
        TextsUpdate();
    }
    public void TextsUpdate()
    {
        _scoreText.text = Math.Round(score, 3).ToString();
        _nicknameText.text = "Nickname: " + nickname;
    }
    public void GameOver()
    {
        _gameGO.SetActive(false);
        _menu.SetActive(false);
        _gameOverPanel.SetActive(true);
        saveManager.SaveLeader(leaderBoard.GetLeaders());
    }
    private void RestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void MenuClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
