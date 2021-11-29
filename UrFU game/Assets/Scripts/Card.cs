using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        
    }

    // Update is called once per frame
    void Update()
    {
        
=======
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
>>>>>>> Stashed changes
    }
}
