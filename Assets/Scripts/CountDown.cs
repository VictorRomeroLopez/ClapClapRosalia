using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] private Text timeText;
    [SerializeField] private Text startTimeText;
    [SerializeField] private GameLogic gL;

    private float defaultPlayTime = 5f;

    private float modifiedPlayTime;
    private float startMaxTime = 3.99f;

    private bool startCountdown = false;
    public bool gameCountdown = false;
    // Start is called before the first frame update
    void Start()
    {
        modifiedPlayTime = defaultPlayTime * GameManager.Instance.CurrentPlayer.JaquetTimeModifier;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCounter();
    }

    void UpdateCounter()
    {
        if (gameCountdown)
        {
            modifiedPlayTime -= Time.deltaTime;
            int secondValue = (int)modifiedPlayTime % 60;
            timeText.text = secondValue.ToString();
            if (modifiedPlayTime < 0)
            {
                timeText.text = "0";
                gameCountdown = false;
                modifiedPlayTime = defaultPlayTime * GameManager.Instance.CurrentPlayer.JaquetTimeModifier;
                startMaxTime = 3.99f;
                gL.EndGame();
                timeText.gameObject.SetActive(false);
            }
        }
        else if(startCountdown)
        {
            startMaxTime -= Time.deltaTime;
            int secondValue = (int)startMaxTime % 60;
            
            startTimeText.text = secondValue.ToString();
            if(startMaxTime < 0)
            {
                startTimeText.text = "0";
                startCountdown = false;
                timeText.gameObject.SetActive(true);
                StartGameCountDown();
                startTimeText.gameObject.SetActive(false);
                gL.StartGame();
            }
        }
    }

    public void StartStartCountDown()
    {
        startCountdown = true;
        startTimeText.gameObject.SetActive(true);
    }

    public void StartGameCountDown()
    {
        gameCountdown = true;
        modifiedPlayTime += GameManager.Instance.CurrentPlayer.JaquetTimeModifier;
    }

}
