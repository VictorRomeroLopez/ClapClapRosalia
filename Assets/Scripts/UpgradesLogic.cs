using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesLogic : MonoBehaviour
{
    struct UpgradePanel
    {
        [SerializeField] private string _tittle;
        [SerializeField] private string _hint;

    }
    [SerializeField] private TextMeshProUGUI nailsPointsText;
    [SerializeField] private TextMeshProUGUI nailsCostText;
    [SerializeField] private TextMeshProUGUI coatMaxTimeText;
    [SerializeField] private TextMeshProUGUI coatCostText;
    [SerializeField] private Text coinsCounterText;
    [SerializeField] private TextMeshProUGUI nailsLevelText;
    [SerializeField] private TextMeshProUGUI coatLevelText;
    [SerializeField] private Text resetDoneText;
    [SerializeField] private Text fansCounterText;
    [SerializeField] private Text mainFansCounterText;
    [SerializeField] private Text mainCoinsCounterText;
    [SerializeField] private Text multiplierText;
    [SerializeField] private Text futureMultiplierText;
    [SerializeField] private Image coinsButton;
    [SerializeField] private Image coatButton;
    [SerializeField] private Image resetButton;
    [SerializeField] private Color activeButtonColor;
    [SerializeField] private Color activeResetButtonColor;

    private float nailUpgradeValue = 0.1f;
    private float jaquetUpgradeValue = 0.05f;
    private float coatCost = 100f;
    private float nailCost = 50f;
    private float resetConverter = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        nailsPointsText.text = GameManager.Instance.CurrentPlayer.NailPointsModifier.ToString("F2");
        coatMaxTimeText.text = (5 * GameManager.Instance.CurrentPlayer.JaquetTimeModifier).ToString("F2");
        nailsCostText.text = "Cost: " + nailCost.ToString("F2");
        coatCostText.text = "Cost: " + coatCost.ToString("F2");
        nailsLevelText.text = GameManager.Instance.CurrentPlayer.NailsLevel.ToString();
        coatLevelText.text = GameManager.Instance.CurrentPlayer.JaquetLevel.ToString();

        UpdateCoinsCounter();
        UpdateFansCounter();
        CheckButtons();
    }

    public void CheckButtons()
    {
        if (GameManager.Instance.CurrentPlayer.Coins < nailCost)
        {
            coinsButton.color = Color.gray;
        }
        else
        {
            coinsButton.color = activeButtonColor;
        }

        if (GameManager.Instance.CurrentPlayer.Coins < coatCost)
        {
            coatButton.color = Color.gray;
        }
        else
        {
            coatButton.color = activeButtonColor;
        }

        if (GameManager.Instance.CurrentPlayer.Fans < 500f)
        {
            resetButton.color = Color.gray;
        }
        else
        {
            resetButton.color = activeResetButtonColor;
        }
    }

    public void UpgradeNails()
    {
        if (GameManager.Instance.CurrentPlayer.Coins >= nailCost)
        {
            GameManager.Instance.CurrentPlayer.NailsLevel++;

            if (GameManager.Instance.CurrentPlayer.NailsLevel % 5 == 0) 
                GameManager.Instance.CurrentPlayer.NailPointsModifier += GameManager.Instance.CurrentPlayer.NailPointsModifier * (nailUpgradeValue * 5);
            else
            GameManager.Instance.CurrentPlayer.NailPointsModifier += GameManager.Instance.CurrentPlayer.NailPointsModifier * nailUpgradeValue;
            

            GameManager.Instance.CurrentPlayer.Coins -= nailCost;
            nailCost += nailCost * 0.1f * GameManager.Instance.CurrentPlayer.NailsLevel;

            nailsPointsText.text = GameManager.Instance.CurrentPlayer.NailPointsModifier.ToString("F2");
            nailsCostText.text = "Cost: " + nailCost.ToString("F2");

            nailsLevelText.text = GameManager.Instance.CurrentPlayer.NailsLevel.ToString();

            UpdateCoinsCounter();
        }
    }

    public void UpgradeJaquet()
    {
        if (GameManager.Instance.CurrentPlayer.Coins >= coatCost)
        {
            GameManager.Instance.CurrentPlayer.JaquetTimeModifier += GameManager.Instance.CurrentPlayer.JaquetTimeModifier * jaquetUpgradeValue;
            GameManager.Instance.CurrentPlayer.JaquetLevel++;


            GameManager.Instance.CurrentPlayer.Coins -= coatCost;
            coatCost += coatCost * 0.1f * GameManager.Instance.CurrentPlayer.JaquetLevel;

            coatMaxTimeText.text = (5 * GameManager.Instance.CurrentPlayer.JaquetTimeModifier).ToString("F2");
            coatCostText.text = "Cost: " + coatCost.ToString("F2");

            coatLevelText.text = GameManager.Instance.CurrentPlayer.JaquetLevel.ToString("F2");

            UpdateCoinsCounter();
        }
    }

    public void UpdateCoinsCounter()
    {
        coinsCounterText.text = "Coins: " + GameManager.Instance.CurrentPlayer.Coins.ToString("F2");
        mainCoinsCounterText.text = "Coins: " + GameManager.Instance.CurrentPlayer.Coins.ToString("F2");
    }

    public void UpdateTapMultiplier()
    {
        multiplierText.text = GameManager.Instance.CurrentPlayer.TapPoints.ToString("F2");
        futureMultiplierText.text = "New multiplier: " + (GameManager.Instance.CurrentPlayer.TapPoints + (GameManager.Instance.CurrentPlayer.Fans / resetConverter)).ToString("F2");
    }

    public void UpdateFansCounter()
    {
        fansCounterText.text = "Nº Fans: " + GameManager.Instance.CurrentPlayer.Fans;
        mainFansCounterText.text = "Nº Fans: " + GameManager.Instance.CurrentPlayer.Fans;
    }

    public void UpdatePowerUpsCounters()
    {
        nailsPointsText.text = GameManager.Instance.CurrentPlayer.NailPointsModifier.ToString("F2");
        nailCost = 50f;
        nailsCostText.text = "Cost: " + nailCost.ToString("F2");
        coatMaxTimeText.text = (5 * GameManager.Instance.CurrentPlayer.JaquetTimeModifier).ToString("F2");
        coatCost = 100f;
        coatCostText.text = "Cost: " + coatCost.ToString("F2");
        UpdateCoinsCounter();
        nailsLevelText.text = GameManager.Instance.CurrentPlayer.NailsLevel.ToString();
        coatLevelText.text = GameManager.Instance.CurrentPlayer.JaquetLevel.ToString();
        UpdateFansCounter();
    }

    public void ResetTheGame()
    {
        if(GameManager.Instance.CurrentPlayer.Fans >= 500f)
        {
            GameManager.Instance.CurrentPlayer.TapPoints +=  (GameManager.Instance.CurrentPlayer.Fans / resetConverter);
            GameManager.Instance.CurrentPlayer.Fans = 0;
            GameManager.Instance.CurrentPlayer.Coins = 0;
            GameManager.Instance.CurrentPlayer.NailsLevel = 0;
            GameManager.Instance.CurrentPlayer.NailPointsModifier = 1;
            GameManager.Instance.CurrentPlayer.JaquetLevel = 0;
            GameManager.Instance.CurrentPlayer.JaquetTimeModifier = 1;
            resetDoneText.gameObject.SetActive(true);
            UpdatePowerUpsCounters();
        }

        
    }
}
