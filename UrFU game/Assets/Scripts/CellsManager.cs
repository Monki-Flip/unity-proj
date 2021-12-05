using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsManager : MonoBehaviour
{
    public EmptyCell FirstEmptyCell;

    public GameObject EmptyCell;
    public GameObject CommonCell;
    public GameObject ForestCell;
    public GameObject GrassCell;
    public GameObject MountainCell;
    public GameObject MushroomCell;
    public GameObject WaterCell;

    void Start()
    {
        FirstEmptyCell.CreateEmptyCellTop();
        FirstEmptyCell.CreateEmptyCellTopLeft();
        FirstEmptyCell.CreateEmptyCellBottomLeft();
    }

    public GameObject GetCell(string name)
    {
        switch(name)
        {
            case "Common":
                return CommonCell;
            case "Forest":
                return ForestCell;
            case "Grass":
                return GrassCell;
            case "Mountain":
                return MountainCell;
            case "Water":
                return WaterCell;
            case "Mushroom":
                return MushroomCell;
        }
        return EmptyCell;
    }

}
