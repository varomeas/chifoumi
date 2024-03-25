using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void OnGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void restart()
    {
        SceneManager.LoadScene("Chifoumi");
    }
}
