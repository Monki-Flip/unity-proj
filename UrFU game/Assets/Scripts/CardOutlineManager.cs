using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace UnityProj
{
    public class CardOutlineManager : MonoBehaviour
    {
        public Card CurrentCard;
        public List<Card> Cards;

        public void ChangeCardsOutlineStates()
        {
            foreach (var card in Cards)
                if (card == CurrentCard)
                    card.EnableOutlineState();
                else
                    card.DisableOutlineState();
        }

        public void DisableAllCardsOutline()
        {
            CurrentCard = null;
            foreach (var card in Cards)
                card.DisableOutlineState();
        }
    }
}