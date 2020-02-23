using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI artistTitleText = null;

    [SerializeField] private Image tier1Button = null;
    [SerializeField] private Image tier2Button = null;
    [SerializeField] private Image tier3Button = null;
    [SerializeField] private Image tier4Button = null;
    [SerializeField] private Image tier5Button = null;

    [SerializeField] private GameObject upgrade1 = null;
    [SerializeField] private GameObject upgrade2 = null;
    [SerializeField] private GameObject upgrade3 = null;
    [SerializeField] private GameObject upgrade4 = null;
    [SerializeField] private GameObject upgrade5 = null;

    [SerializeField] private Color activateButtonColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckButtons()
    {
        switch(GameManager.Instance.CurrentPlayer.ArtistTier)
        {
            case 0:
                if(GameManager.Instance.CurrentPlayer.Fans < 1000f || GameManager.Instance.CurrentPlayer.Coins < 5000f)
                {
                    tier1Button.color = Color.gray;
                }
                else
                {
                    tier1Button.color = activateButtonColor;
                }
                tier2Button.color = Color.gray;
                tier3Button.color = Color.gray;
                tier4Button.color = Color.gray;
                tier5Button.color = Color.gray;
                break;
            case 1:
                if (GameManager.Instance.CurrentPlayer.Fans < 10000f || GameManager.Instance.CurrentPlayer.Coins < 50000f)
                {
                    tier2Button.color = Color.gray;
                }
                else
                {
                    tier2Button.color = activateButtonColor;
                }
                tier3Button.color = Color.gray;
                tier4Button.color = Color.gray;
                tier5Button.color = Color.gray;
                break;
            case 2:
                if (GameManager.Instance.CurrentPlayer.Fans < 100000f || GameManager.Instance.CurrentPlayer.Coins < 500000f)
                {
                    tier3Button.color = Color.gray;
                }
                else
                {
                    tier3Button.color = activateButtonColor;
                }
                tier4Button.color = Color.gray;
                tier5Button.color = Color.gray;
                break;
            case 3:
                if (GameManager.Instance.CurrentPlayer.Fans < 1000000f || GameManager.Instance.CurrentPlayer.Coins < 5000000f)
                {
                    tier4Button.color = Color.gray;
                    
                }
                else
                {
                    tier4Button.color = activateButtonColor;
                }
                tier5Button.color = Color.gray;
                break;
            case 4:
                if (GameManager.Instance.CurrentPlayer.Fans < 10000000f || GameManager.Instance.CurrentPlayer.Coins < 50000000f)
                {
                    tier5Button.color = Color.gray;
                }
                else
                {
                    tier5Button.color = activateButtonColor;
                }
                break;
            default:
                break;
        }
    }

    public void TierUpgrade()
    {
        switch(GameManager.Instance.CurrentPlayer.ArtistTier)
        {
            case 0:
                if(GameManager.Instance.CurrentPlayer.Fans >= 1000f && GameManager.Instance.CurrentPlayer.Coins >= 5000f)
                {
                    artistTitleText.text = "Artist Tier:\nAmateur";
                    GameManager.Instance.CurrentPlayer.Coins -= 5000f;
                    GameManager.Instance.CurrentPlayer.ArtistTier++;
                    upgrade1.SetActive(false);
                }
                break;
            case 1:
                if (GameManager.Instance.CurrentPlayer.Fans >= 10000f && GameManager.Instance.CurrentPlayer.Coins >= 50000f)
                {
                    artistTitleText.text = "Artist Tier:\nPub Singer";
                    GameManager.Instance.CurrentPlayer.Coins -= 50000f;
                    GameManager.Instance.CurrentPlayer.ArtistTier++;
                    upgrade2.SetActive(false);
                }
                break;
            case 2:
                if (GameManager.Instance.CurrentPlayer.Fans >= 100000f && GameManager.Instance.CurrentPlayer.Coins >= 500000f)
                {
                    artistTitleText.text = "Artist Tier:\nPromise";
                    GameManager.Instance.CurrentPlayer.Coins -= 500000f;
                    GameManager.Instance.CurrentPlayer.ArtistTier++;
                    upgrade3.SetActive(false);
                }
                break;
            case 3:
                if (GameManager.Instance.CurrentPlayer.Fans >= 1000000f && GameManager.Instance.CurrentPlayer.Coins >= 5000000f)
                {
                    artistTitleText.text = "Artist Tier:\nStar";
                    GameManager.Instance.CurrentPlayer.Coins -= 5000000f;
                    GameManager.Instance.CurrentPlayer.ArtistTier++;
                    upgrade4.SetActive(false);
                }
                break;
            case 4:
                if (GameManager.Instance.CurrentPlayer.Fans >= 10000000f && GameManager.Instance.CurrentPlayer.Coins >= 50000000f)
                {
                    artistTitleText.text = "Artist Tier:\nSuperStar";
                    GameManager.Instance.CurrentPlayer.Coins -= 50000000f;
                    GameManager.Instance.CurrentPlayer.ArtistTier++;
                    upgrade5.SetActive(false);
                }
                break;
        }
    }

}
