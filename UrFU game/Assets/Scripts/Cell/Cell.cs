using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public string Name;
    public GameObject Prefab;

    public bool HasTopAnyCell;
    public bool HasTopLeftAnyCell;
    public bool HasTopRightAnyCell;
    public bool HasBottomLeftAnyCell;
    public bool HasBottomRightAnyCell;
    public bool HasBottomAnyCell;

    public List<GameObject> Neighbors;

    public Cell(string name, GameObject prefab)
    {
        Name = name;
        Prefab = prefab;
    }
}
