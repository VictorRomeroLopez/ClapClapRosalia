using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    public float TimerValue { get; set; }
    public Player CurrentPlayer { get; set; }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        CurrentPlayer = new Player();
    }
}
