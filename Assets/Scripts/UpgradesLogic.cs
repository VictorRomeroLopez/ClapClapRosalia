using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesLogic : MonoBehaviour
{
    [SerializeField] private Text nailsPointsText;
    [SerializeField] private Text nailsCostText;
    [SerializeField] private Text coatMaxTimeText;
    [SerializeField] private Text coatCostText;
    [SerializeField] private Text coinsCounterText;
    [SerializeField] private Text nailsLevelText;
    [SerializeField] private Text coatLevelText;

    private float nailUpgradeValue = 0.1f;
    private float jaquetUpgradeValue = 0.05f;
    private float coatCost = 100f;
    private float nailCost = 50f;
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

            if(GameManager.Instance.CurrentPlayer.NailsLevel%5 == 0)
                GameManager.Instance.CurrentPlayer.NailPointsModifier += GameManager.Instance.CurrentPlayer.NailPointsModifier * (nailUpgradeValue * 3);
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
}
