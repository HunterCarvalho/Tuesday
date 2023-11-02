using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

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
}
