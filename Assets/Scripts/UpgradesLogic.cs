using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesLogic : MonoBehaviour
{
    struct UpgradePanel
    {
        [SerializeField] private string _tittle;
        [SerializeField] private string _hint;

    }
    [SerializeField] private Text nailsPointsText;
    [SerializeField] private Text nailsCostText;
    [SerializeField] private Text coatMaxTimeText;
    [SerializeField] private Text coatCostText;
    [SerializeField] private Text coinsCounterText;
    [SerializeField] private Text nailsLevelText;
    [SerializeField] private Text coatLevelText;
    [SerializeField] private Text resetDoneText;
    [SerializeField] private Text fansCounterText;

    private float nailUpgradeValue = 0.1f;
    private float jaquetUpgradeValue = 0.05f;
    private float coatCost = 100f;
    private float nailCost = 50f;
    private float resetConverter = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        nailsPointsText.text = "Points per hit: " + GameManager.Instance.CurrentPlayer.NailPointsModifier;
        coatMaxTimeText.text = "Max Time: " + (5 * GameManager.Instance.CurrentPlayer.JaquetTimeModifier);
        nailsCostText.text = "Cost: " + nailCost;
        coatCostText.text = "Cost: " + coatCost;
        nailsLevelText.text = "Level: " + GameManager.Instance.CurrentPlayer.NailsLevel;
        coatLevelText.text = "Level: " + GameManager.Instance.CurrentPlayer.JaquetLevel;
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

            nailsPointsText.text = "Points per hit: " + GameManager.Instance.CurrentPlayer.NailPointsModifier;
            nailsCostText.text = "Cost: " + nailCost;

            nailsLevelText.text = "Level: " + GameManager.Instance.CurrentPlayer.NailsLevel;
            
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

            coatMaxTimeText.text = "Max Time: " + (5 * GameManager.Instance.CurrentPlayer.JaquetTimeModifier);
            coatCostText.text = "Cost: " + coatCost;

            coatLevelText.text = "Level: " + GameManager.Instance.CurrentPlayer.JaquetLevel;

            UpdateCoinsCounter();
        }
    }

    public void UpdateCoinsCounter()
    {
        coinsCounterText.text = "Coins: " + GameManager.Instance.CurrentPlayer.Coins.ToString();
    }

    public void UpdateFansCounter()
    {
        fansCounterText.text = "Nº Fans: " + GameManager.Instance.CurrentPlayer.Fans;
    }

    public void UpdatePowerUpsCounters()
    {
        nailsPointsText.text = "Points per hit: " + GameManager.Instance.CurrentPlayer.NailPointsModifier;
        nailCost = 50f;
        nailsCostText.text = "Cost: " + nailCost;
        coatMaxTimeText.text = "Max Time: " + (5 * GameManager.Instance.CurrentPlayer.JaquetTimeModifier);
        coatCost = 100f;
        coatCostText.text = "Cost: " + coatCost;
        UpdateCoinsCounter();
        nailsLevelText.text = "Level: " + GameManager.Instance.CurrentPlayer.NailsLevel;
        coatLevelText.text = "Level: " + GameManager.Instance.CurrentPlayer.JaquetLevel;
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
