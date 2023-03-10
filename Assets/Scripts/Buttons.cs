using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private string _scene;
    [SerializeField]
    private Player _player;
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReloadGame()
    {
        _player.Damage(-100);
        Time.timeScale = 1;
        SceneManager.LoadScene(_scene);
    }
}
