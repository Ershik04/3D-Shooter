using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessAtcivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _postProcessing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _postProcessing.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _postProcessing.SetActive(false);
        }
    }
}
