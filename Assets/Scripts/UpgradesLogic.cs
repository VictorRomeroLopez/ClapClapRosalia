using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesLogic : MonoBehaviour
{
    [SerializeField] private Text nailsLevelText;
    [SerializeField] private Text nailsCostText;
    [SerializeField] private Text coatLevelText;
    [SerializeField] private Text coatCostText;
    [SerializeField] private Text coinsCounterText;

    private float nailUpgradeValue = 0.1f;
    private float jaquetUpgradeValue = 0.05f;
    private float coatCost = 100f;
    private float nailCost = 50f;
    // Start is called before the first frame update
    void Start()
    {
        nailsLevelText.text = "Points per hit: " + GameManager.Instance.CurrentPlayer.NailPointsModifier;
        coatLevelText.text = "Max Time: " + (5 * GameManager.Instance.CurrentPlayer.JaquetTimeModifier);
        nailsCostText.text = "Cost: " + nailCost;
        coatCostText.text = "Cost: " + coatCost;
    }

    public void UpgradeNails()
    {
        if (GameManager.Instance.CurrentPlayer.Coins >= nailCost)
        {
            GameManager.Instance.CurrentPlayer.NailPointsModifier += GameManager.Instance.CurrentPlayer.NailPointsModifier * nailUpgradeValue;
            GameManager.Instance.CurrentPlayer.NailsLevel++;

            GameManager.Instance.CurrentPlayer.Coins -= nailCost;
            nailCost += nailCost * 0.1f * GameManager.Instance.CurrentPlayer.NailsLevel;

            nailsLevelText.text = "Points per hit: " + GameManager.Instance.CurrentPlayer.NailPointsModifier;
            nailsCostText.text = "Cost: " + nailCost;

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

            coatLevelText.text = "Max Time: " + (5 * GameManager.Instance.CurrentPlayer.JaquetTimeModifier);
            coatCostText.text = "Cost: " + coatCost;

            UpdateCoinsCounter();
        }
    }

    public void UpdateCoinsCounter()
    {
        coinsCounterText.text = "Coins: " + GameManager.Instance.CurrentPlayer.Coins.ToString();
    }
}
