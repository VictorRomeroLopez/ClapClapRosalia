using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitPS;
    [SerializeField] private Text pointsText;
    [SerializeField] private Text endGameText;
    [SerializeField] private GameObject MainCanvas;
    [SerializeField] private GameObject GameCanvas;
    private bool gameRunning = false;
    private float points = 0;

    // Update is called once per frame
    void Update()
    {
        if (gameRunning)
        {
            for (int i = 0; i < InputManager.Instance.TouchCount; i++)
            {
                if (InputManager.Instance.Touches[i].phase == TouchPhase.Began)
                {
                    ParticleSystem nps = Instantiate(hitPS, Camera.main.ScreenToWorldPoint(InputManager.Instance.Touches[i].position), Quaternion.identity);
                    nps.Play();
                    points += GameManager.Instance.CurrentPlayer.TapPoints * GameManager.Instance.CurrentPlayer.NailPointsModifier;
                    pointsText.text = points.ToString();
                }
            }
        }
    }

    public void StartGame()
    {
        gameRunning = true;
        pointsText.gameObject.SetActive(true);
        pointsText.text = "0";
        points = 0;
    }

    public void EndGame()
    {
        gameRunning = false;
        GameManager.Instance.CurrentPlayer.Coins += points;
        if (points > GameManager.Instance.CurrentPlayer.Fans) GameManager.Instance.CurrentPlayer.Fans = points;
        

        StartCoroutine(GameEnded());
    }

    IEnumerator GameEnded()
    {
        endGameText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);

        pointsText.gameObject.SetActive(false);
        endGameText.gameObject.SetActive(false);
        MainCanvas.SetActive(true);
        GameCanvas.SetActive(false);
    }
}
