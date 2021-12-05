using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCell : MonoBehaviour
{
    public GameObject Prefab;
    public CellsStackOutline CellsStackOutline;
    public CellsStack CellsStack;
    public CellsManager CellsManager;


    //—»—“≈Ã¿ —Œ—≈ƒ≈… Õ≈ ƒŒƒ≈À¿Õ¿
    //—“Œ»“ œŒƒ”Ã¿“‹ Õ¿—◊≈“ œ≈–≈ƒ≈À€¬¿Õ»ﬂ –≈¿À»«¿÷»» œŒƒ ŒƒÕŒ–¿«Œ¬€… ◊≈  “–»√≈–Œ¬ ¬Œ –”√ Õ¿ —Œ—≈ƒ—“¬Œ
    public bool HasTopNeighbor;
    public bool HasTopLeftNeighbor;
    public bool HasTopRightNeighbor;
    public bool HasBottomLeftNeighbor;
    public bool HasBottomRightNeighbor;
    public bool HasBottomNeighbor;

    public List<GameObject> Neighbors;



    void OnMouseDown()
    {
        if(CellsStackOutline.Outline.enabled)
        {
            var cellInStick = CellsStack.Stack[0];
            CellsStack.RemoveTop();
            //Debug.Log(cellInStick.GetComponent<Cell>().Name);
            var cell = Instantiate(CellsManager.GetCell(cellInStick.GetComponent<Cell>().Name));
            cell.transform.parent = transform.parent;
            cell.transform.position = transform.position;
            CheckAround(cell.GetComponent<Cell>());
            CellsStackOutline.Outline.enabled = false;
            Destroy(gameObject);
        }
    }
    // ÔÓÒÚ‡‚¸ ÚÂ„Ë!!!
    public void CheckAround(Cell cell)
    {
        var hittenColliders = Physics2D.OverlapCircleAll(transform.position, 0.55f);
        //Debug.Log(hittenColliders.Length);

        for (var i = 0; i < hittenColliders.Length; i++)
        {
            if(hittenColliders[i].gameObject.tag == "Cell")
            {
                cell.Neighbors.Add(hittenColliders[i].gameObject);
                hittenColliders[i].gameObject.GetComponent<Cell>().Neighbors.Add(cell.gameObject);
                MarkPosition(hittenColliders[i].gameObject, cell);
            }
            else if (hittenColliders[i].gameObject.tag == "EmptyCell")
                MarkPosition(hittenColliders[i].gameObject, cell);
        }
        CreateGridAround(cell);
    }

    public void CreateGridAround(Cell cell)
    {
        if (!cell.HasBottomAnyCell)
            —reateEmptyCellBottom();
        if (!cell.HasBottomLeftAnyCell)
            CreateEmptyCellBottomLeft();
        if (!cell.HasBottomRightAnyCell)
            CreateEmptyCellBottomRight();
        if (!cell.HasTopAnyCell)
            CreateEmptyCellTop();
        if (!cell.HasTopLeftAnyCell)
            CreateEmptyCellTopLeft();
        if (!cell.HasTopRightAnyCell)
            CreateEmptyCellTopRight();
    }

    public void MarkPosition(GameObject obj, Cell cell)
    {
        Vector2 pos = obj.transform.position;
        if (pos == (Vector2)gameObject.transform.position + Vector2.up * 0.85f + Vector2.right * 0.15f)
            cell.HasTopAnyCell = true;
        else if (pos == (Vector2)gameObject.transform.position + Vector2.down * 0.85f + Vector2.left * 0.15f)
            cell.HasBottomAnyCell = true;
        else if (pos == (Vector2)gameObject.transform.position + Vector2.up * 0.425f + Vector2.right * 0.975f)
            cell.HasTopRightAnyCell = true;
        else if (pos == (Vector2)gameObject.transform.position + Vector2.up * 0.425f + Vector2.left * 0.825f)
            cell.HasTopLeftAnyCell = true;
        else if (pos == (Vector2)gameObject.transform.position + Vector2.down * 0.425f + Vector2.left * 0.975f)
            cell.HasBottomLeftAnyCell = true;
        else if (pos == (Vector2)gameObject.transform.position + Vector2.down * 0.425f + Vector2.right * 0.825f)
            cell.HasBottomRightAnyCell = true;
    }

    private GameObject CreateEmptyCell()
    {
        var newEmptyCell = Instantiate(Prefab);
        newEmptyCell.GetComponent<EmptyCell>().Prefab = Prefab;
        newEmptyCell.GetComponent<EmptyCell>().CellsStackOutline = CellsStackOutline;
        newEmptyCell.GetComponent<EmptyCell>().CellsStack = CellsStack;
        newEmptyCell.GetComponent<EmptyCell>().CellsManager = CellsManager;
        newEmptyCell.GetComponent<EmptyCell>().Neighbors.Add(gameObject);
        Neighbors.Add(newEmptyCell);
        
        return newEmptyCell;
    }
    public void CreateEmptyCellTop()
    {
        var newEmptyCell = CreateEmptyCell();
        newEmptyCell.transform.parent = transform.parent;
        newEmptyCell.transform.localPosition = gameObject.transform.position + Vector3.up * 0.85f + Vector3.right * 0.15f;
        HasTopNeighbor = true;
        newEmptyCell.GetComponent<EmptyCell>().HasBottomNeighbor = true;
    }

    public void —reateEmptyCellBottom()
    {
        var newEmptyCell = CreateEmptyCell();
        newEmptyCell.transform.parent = transform.parent;
        newEmptyCell.transform.localPosition = gameObject.transform.position + Vector3.down * 0.85f + Vector3.left * 0.15f;
        HasBottomNeighbor = true;
        newEmptyCell.GetComponent<EmptyCell>().HasTopNeighbor = true;
    }

    public void CreateEmptyCellTopRight()
    {
        var newEmptyCell = CreateEmptyCell();
        newEmptyCell.transform.parent = transform.parent;
        newEmptyCell.transform.localPosition = gameObject.transform.position + Vector3.up * 0.425f + Vector3.right * 0.975f;
        HasTopRightNeighbor = true;
        newEmptyCell.GetComponent<EmptyCell>().HasBottomLeftNeighbor = true;
    }

    public void CreateEmptyCellTopLeft()
    {
        var newEmptyCell = CreateEmptyCell();
        newEmptyCell.transform.parent = transform.parent;
        newEmptyCell.transform.localPosition = gameObject.transform.position + Vector3.up * 0.425f + Vector3.left * 0.825f;
        HasTopLeftNeighbor = true;
        newEmptyCell.GetComponent<EmptyCell>().HasBottomRightNeighbor = true;
    }

    public void CreateEmptyCellBottomLeft()
    {
        var newEmptyCell = CreateEmptyCell();
        newEmptyCell.transform.parent = transform.parent;
        newEmptyCell.transform.localPosition = gameObject.transform.position + Vector3.down * 0.425f + Vector3.left * 0.975f;
        HasBottomLeftNeighbor = true;
        newEmptyCell.GetComponent<EmptyCell>().HasTopRightNeighbor = true;
    }

    public void CreateEmptyCellBottomRight()
    {
        var newEmptyCell = CreateEmptyCell();
        newEmptyCell.transform.parent = transform.parent;
        newEmptyCell.transform.localPosition = gameObject.transform.position + Vector3.down * 0.425f + Vector3.right * 0.825f;
        HasBottomRightNeighbor = true;
        newEmptyCell.GetComponent<EmptyCell>().HasTopLeftNeighbor = true;
    }
}
