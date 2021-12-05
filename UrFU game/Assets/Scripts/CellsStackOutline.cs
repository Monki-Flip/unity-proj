using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsStackOutline : MonoBehaviour
{
    public SpriteRenderer Outline;

    void OnMouseDown()
    {
        Outline.enabled = !Outline.enabled;
    }
}
