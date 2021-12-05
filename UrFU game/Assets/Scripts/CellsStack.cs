using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsStack : MonoBehaviour
{
    public List<GameObject> Stack;
    public GameObject CommonCell;
    public GameObject ForestCell;
    public GameObject GrassCell;
    public GameObject MountainCell;
    public GameObject MushroomCell;
    public GameObject WaterCell;
    public List<GameObject> AllCells;

    private Vector3 Step = new Vector3(0, -0.25f, 0);
    private Vector3 NextPosition = Vector3.zero;

    private int PositionInOrder;


    void Start()
    {
        Stack = new List<GameObject>();
        AllCells = new List<GameObject>() { CommonCell, ForestCell, GrassCell, MountainCell, MushroomCell, WaterCell };
        AddRandomCells(6);
    }

    public void AddRandomCells(int cellCount)
    {
        var rnd = new System.Random();
        for (var i = 0; i < cellCount; i++)
        {
            var randI = rnd.Next(0, AllCells.Count - 1);
            var newCell = Instantiate(AllCells[randI]);
            newCell.transform.parent = transform;
            newCell.transform.localPosition = NextPosition;
            NextPosition += Step;
            newCell.GetComponent<SpriteRenderer>().sortingOrder = PositionInOrder;
            PositionInOrder--;
            newCell.transform.localScale *= 2; // увеличение спрайта в 2 раза, мб убрать после получения нормальных спрайтов

            Stack.Add(newCell);
        }
    }

    public void RemoveTop()
    {
        Destroy(Stack[0]);
        Stack.RemoveAt(0);
        NextPosition -= Step;
        for (var i = 0; i < Stack.Count; i++)
        {
            Stack[i].transform.localPosition -= Step;
        }
    }
}
