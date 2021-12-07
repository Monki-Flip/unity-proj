using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Canvas Panel;
    public GameObject Obj;

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

    public void ChangeGameObjectState()
    {
        Obj.SetActive(!Obj.activeSelf);
    }

}
