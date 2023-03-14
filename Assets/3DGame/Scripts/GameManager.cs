using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] string sceneName;
    public void RestartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
