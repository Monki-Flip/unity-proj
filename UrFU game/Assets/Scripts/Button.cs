using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Canvas Panel;

    public void Opening()
    {
        Panel.enabled = true;
    }

    public void Closing()
    {
        Panel.enabled = false;
    }

    public void ChangeState()
    {
        Panel.enabled = !Panel.enabled;
    }
}
