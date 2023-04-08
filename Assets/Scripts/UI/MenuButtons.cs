using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    private string _scene;
    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private Button _closeButton;
    [SerializeField]
    private Button _descriptionButton;
    [SerializeField]
    private Button _descriptionCloseButton;
    [SerializeField]
    private GameObject _descriptionPanel;

    private void Start()
    {
        _startButton.onClick.AddListener(StartGame);
        _closeButton.onClick.AddListener(CloseGame);
        _descriptionButton.onClick.AddListener(OpenDescription);
        _descriptionCloseButton.onClick.AddListener(CloseDescription);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_scene);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void OpenDescription()
    {
        _descriptionPanel.SetActive(true);
    }

    public void CloseDescription()
    {
        _descriptionPanel.SetActive(false);
    }
}
