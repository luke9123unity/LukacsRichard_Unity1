using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] string sceneName;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("More than one GameManager");
    }
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

}