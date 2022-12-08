using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] private Canvas youDiedScreen;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Invoke(nameof(Load), .5f);
        
        youDiedScreen.gameObject.SetActive(true);
    }

    private void Load()
    {
        SceneManager.LoadScene("Level1");
    }
}