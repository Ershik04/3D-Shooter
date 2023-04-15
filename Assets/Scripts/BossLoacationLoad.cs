using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLoacationLoad : MonoBehaviour
{
    [SerializeField]
    private string _scene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(_scene);
            Time.timeScale = 1;
        }
    }
}
