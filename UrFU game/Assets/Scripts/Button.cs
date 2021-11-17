using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProj
{
    public class Button : MonoBehaviour
    {
        public Canvas Panel;
        public void Open()
        {
            Panel.enabled = true;
        }

        public void Close()
        {
            Panel.enabled = false;
        }

        public void ChangeState()
        {
            Panel.enabled = !Panel.enabled;
        }
    }
}
