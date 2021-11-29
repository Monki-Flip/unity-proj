using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    public TMP_Text PriceText;
    public TMP_Text ÑoefficientsChanges;
    public TMP_Text XEquation;
    public TMP_Text YEquation;
    public int Price;
    public double AlphaDiff;
    public double BetaDiff;
    public double GammaDiff;
    public double DeltaDiff;

    private void Start()
    {
        PriceText.text = Price.ToString();
    }

    public void Select()
    {
            
    }
}
