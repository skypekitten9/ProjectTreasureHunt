﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance = null;
    public static GameMaster Instance { get { return instance; } }
    public int life;

    int sceneIndex = 0;


    public void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetLevel();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            NextLevel();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            DecreaseLife();
        }
    }

    public void Win()
    {
        NextLevel();
    }

    public void DecreaseLife()
    {
        life--;
        if(life <= 0)
        {
            Loose();
        }
    }

    public void Loose()
    {
        ResetLevel();
    }

    public void ResetLevel()
    {
        life = 3;
        SceneManager.LoadScene(sceneIndex);
    }

    public void NextLevel()
    {
        sceneIndex++;
        life = 3;
        SceneManager.LoadScene(sceneIndex);
    }
}
