using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField]
    private Text timeText;
    private float maxTime = 30f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCounter();
    }

    void UpdateCounter()
    {
        maxTime -= Time.deltaTime;
        int secondValue = (int)maxTime % 60;
        timeText.text = secondValue.ToString();
    }
}
