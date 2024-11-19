using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        PlayerPrefs.Save();
        
        SceneManager.LoadScene("skateparkScene");
    }
}