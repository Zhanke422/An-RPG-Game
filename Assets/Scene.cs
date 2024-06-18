using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class Scene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            RestartGame();
        }
    }
    public void RestartGame()
    {
        Debug.Log("called");
        SceneManager.LoadScene("Main Scene");
    }
}
