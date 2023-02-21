using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SSE
{
    public class MainMenuController : MonoBehaviour
    {
        // Запуск игры
        public void Play()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        // Выход из игры
        public void Quit()
        {
            Application.Quit();
            Debug.Log("Player has quit !");
        }
    }
}
