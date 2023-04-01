using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Health : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private Player _player;

    private void Update()
    {
        _text.text = "Health: " + _player.PlayerHealth.ToString();
    }
}
