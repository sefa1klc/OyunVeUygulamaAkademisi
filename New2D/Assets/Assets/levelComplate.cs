using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelComplate : MonoBehaviour
{
    public GameObject winText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winText.SetActive(true);
        }
    }

    public void next()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
    }
}
