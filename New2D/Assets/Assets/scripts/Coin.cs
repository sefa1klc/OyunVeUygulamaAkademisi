using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int count;
    [SerializeField] private AudioClip _audioClip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("gold"))
        {
            count++;
            AudioSource.PlayClipAtPoint(_audioClip,other.transform.position);
            Destroy(other.gameObject);
        }
    }
}
