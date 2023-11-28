using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public List<GameObject> collectables;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        isGameActive = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void GuideMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ControlMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void Return()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
 