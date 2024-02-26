using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject WinCanvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO Also check Player stats 
        if (collision.gameObject.CompareTag("Player"))
        {
            WinCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
