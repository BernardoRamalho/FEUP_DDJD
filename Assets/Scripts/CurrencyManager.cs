using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text currencyText;
    public int currencyCount = 0;
    void Start()
    {
        currencyText = GameObject.Find("Currency").GetComponent<Text>();
    }

    public void addCurrency(int currencyValue){
        currencyCount += currencyValue;
        currencyText.text = "" + currencyCount;
    }
}
