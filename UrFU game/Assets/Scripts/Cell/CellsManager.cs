using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsManager : MonoBehaviour
{
    public CellsStackOutline CellsStackOutline;
    public CellsStack CellsStack;
    public Score Score;

    public EmptyCell FirstEmptyCell;

    public GameObject EmptyCell;
    public GameObject CommonCell;
    public GameObject ForestCell;
    public GameObject GrassCell;
    public GameObject MountainCell;
    public GameObject MushroomCell;
    public GameObject WaterCell;

    public bool IsAnyCellOnBoard;

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

    public void CreateCell(GameObject emptyCell)
    {
        if (CellsStackOutline.Outline.enabled && CanBePut(emptyCell))
        {
            var cellInStick = CellsStack.Stack[0];
            CellsStack.RemoveTop();
            //Debug.Log(cellInStick.GetComponent<Cell>().Name);
            var cell = Instantiate(GetCell(cellInStick.GetComponent<Cell>().Name));
            CheckAround(cell.GetComponent<Cell>(), emptyCell);
            cell.transform.parent = emptyCell.transform.parent;
            cell.transform.position = emptyCell.transform.position;
            CellsStackOutline.Outline.enabled = false;
            Destroy(emptyCell);
        }
    }

    public bool CanBePut(GameObject emptyCell)
    {
        if (!IsAnyCellOnBoard)
        {
            IsAnyCellOnBoard = true;
            return true;
        }
        var hittenColliders = Physics2D.OverlapCircleAll(emptyCell.transform.position, 0.55f);
        for (var i = 0; i < hittenColliders.Length; i++)
            if (hittenColliders[i].gameObject.tag == "Cell")
                return true;
        return false;
    }

    public void CheckAround(Cell cell, GameObject emptyCell)
    {
        var hittenColliders = Physics2D.OverlapCircleAll(emptyCell.transform.position, 0.55f);
        //Debug.Log(hittenColliders.Length);

        for (var i = 0; i < hittenColliders.Length; i++)
        {
            if (hittenColliders[i].gameObject.tag == "Cell" && hittenColliders[i].gameObject != cell.gameObject)
            {
                cell.Neighbors.Add(hittenColliders[i].gameObject);
                hittenColliders[i].gameObject.GetComponent<Cell>().Neighbors.Add(cell.gameObject);
                MarkPosition(hittenColliders[i].gameObject, cell, emptyCell);
                AddScore(cell, hittenColliders[i].GetComponent<Cell>());
            }
            else if (hittenColliders[i].gameObject.tag == "EmptyCell")
                MarkPosition(hittenColliders[i].gameObject, cell, emptyCell);
        }
        CreateGridAround(cell, emptyCell.GetComponent<EmptyCell>());
    }

    public void CreateGridAround(Cell cell, EmptyCell emptyCell)
    {
        if (!cell.HasBottomAnyCell)
            emptyCell.�reateEmptyCellBottom();
        if (!cell.HasBottomLeftAnyCell)
            emptyCell.CreateEmptyCellBottomLeft();
        if (!cell.HasBottomRightAnyCell)
            emptyCell.CreateEmptyCellBottomRight();
        if (!cell.HasTopAnyCell)
            emptyCell.CreateEmptyCellTop();
        if (!cell.HasTopLeftAnyCell)
            emptyCell.CreateEmptyCellTopLeft();
        if (!cell.HasTopRightAnyCell)
            emptyCell.CreateEmptyCellTopRight();
    }

    public void MarkPosition(GameObject obj, Cell cell, GameObject emptyCell)
    {
        Vector2 pos = obj.transform.position;
        if (pos == (Vector2)emptyCell.transform.position + Vector2.up * 0.85f + Vector2.right * 0.15f)
            cell.HasTopAnyCell = true;
        else if (pos == (Vector2)emptyCell.transform.position + Vector2.down * 0.85f + Vector2.left * 0.15f)
            cell.HasBottomAnyCell = true;
        else if (pos == (Vector2)emptyCell.transform.position + Vector2.up * 0.425f + Vector2.right * 0.975f)
            cell.HasTopRightAnyCell = true;
        else if (pos == (Vector2)emptyCell.transform.position + Vector2.up * 0.425f + Vector2.left * 0.825f)
            cell.HasTopLeftAnyCell = true;
        else if (pos == (Vector2)emptyCell.transform.position + Vector2.down * 0.425f + Vector2.left * 0.975f)
            cell.HasBottomLeftAnyCell = true;
        else if (pos == (Vector2)emptyCell.transform.position + Vector2.down * 0.425f + Vector2.right * 0.825f)
            cell.HasBottomRightAnyCell = true;
    }

    public void AddScore(Cell cell, Cell nearCell)
    {
        var name = nearCell.Name;
        Debug.Log("����� � �����" + name + nearCell);
        switch (cell.Name)
        {
            case "Common":
                if (name == "Common") Score.Add(5);
                else if (name == "Forest") Score.Add(7);
                else if (name == "Mountain") Score.Add(23);
                else if (name == "Water") Score.Add(17);
                else if (name == "Grass") Score.Add(13);
                else if (name == "Mushroom") Score.Add(15);
                break;
            case "Forest":
                if (name == "Common") Score.Add(7);
                else if (name == "Forest") Score.Add(10);
                else if (name == "Mountain") Score.Add(35);
                else if (name == "Water") Score.Add(20);
                else if (name == "Grass") Score.Add(15);
                else if (name == "Mushroom") Score.Add(17);
                break;
            case "Grass":
                if (name == "Common") Score.Add(13);
                else if (name == "Forest") Score.Add(15);
                else if (name == "Mountain") Score.Add(45);
                else if (name == "Water") Score.Add(30);
                else if (name == "Grass") Score.Add(20);
                else if (name == "Mushroom") Score.Add(20);
                break;
            case "Mountain":
                if (name == "Common") Score.Add(23);
                else if (name == "Forest") Score.Add(25);
                else if (name == "Mountain") Score.Add(50);
                else if (name == "Water") Score.Add(40);
                else if (name == "Grass") Score.Add(45);
                else if (name == "Mushroom") Score.Add(50);
                break;
            case "Water":
                if (name == "Common") Score.Add(17);
                else if (name == "Forest") Score.Add(20);
                else if (name == "Mountain") Score.Add(40);
                else if (name == "Water") Score.Add(35);
                else if (name == "Grass") Score.Add(30);
                else if (name == "Mushroom") Score.Add(35);
                break;
            case "Mushroom":
                if (name == "Common") Score.Add(15);
                else if (name == "Forest") Score.Add(17);
                else if (name == "Mountain") Score.Add(50);
                else if (name == "Water") Score.Add(35);
                else if (name == "Grass") Score.Add(20);
                else if (name == "Mushroom") Score.Add(25);
                break;
        }
    }

}
