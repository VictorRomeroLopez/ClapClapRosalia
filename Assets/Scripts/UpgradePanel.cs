using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [Header("Tittle Canvas")]
    [SerializeField] private TextMeshProUGUI _tittleText;
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private TextMeshProUGUI _levelText;

    [Space, Header("Cost Canvas")]
    [SerializeField] private TextMeshProUGUI _costText;

    [Space, Header("Upgrade Canvas")]
    [SerializeField] private Button _upgradeButton;

    public string TittleText { get => _tittleText.text; set => _tittleText.text = value; }
    public string PointsText { get => _pointsText.text; set => _pointsText.text = value; }
    public string LevelText { get => _levelText.text; set => _levelText.text = value; }
    public string CostText { get => _costText.text; set => _costText.text = value; }
    public Button UpgradeButton { get => _upgradeButton; set => _upgradeButton = value; }

}
