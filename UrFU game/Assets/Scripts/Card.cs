using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnityProj
{
    public TMP_Text PriceText;
    public ModelTextManager TextManager;
    public CardOutlineManager CardOutlineManager;
    public Outline Outline;

    public int Price;
    public double AlphaDiff;
    public double BetaDiff;
    public double GammaDiff;
    public double SigmaDiff;

    private void Start()
    {
        PriceText.text = Price.ToString();
    }



    public void Select()
    {
        TextManager.UpdateCoeffChangesText(AlphaDiff, BetaDiff, GammaDiff, SigmaDiff);
        TextManager.UpdateCurrentSystem(AlphaDiff, BetaDiff, GammaDiff, SigmaDiff);
    }

    public void UpdateOutlineManager()
    {
        CardOutlineManager.CurrentCard = this;
        CardOutlineManager.ChangeCardsOutlineStates();
    }

    public void EnableOutlineState()
    {
        Outline.enabled = true;
    }

    public void DisableOutlineState()
    {
        Outline.enabled = false;
    }
}