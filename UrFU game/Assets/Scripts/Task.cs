using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public CellsStack CellsStack;
    public Score Score;
    public Tutorial Tutorial;

    public GameObject Button;

    public GameObject FirstCheckMark;
    public GameObject SecondCheckMark;

    public TMP_Text CellsRewardText;
    public TMP_Text PoitnsRewardText;
    public int CellsRewardCount;
    public int PoitnsRewardCount;

    public bool IsFirstConditionDone;
    public bool IsSecondConditionDone;
    public bool IsDone;


    public void MarkFirstCondition()
    {
        IsFirstConditionDone = true;
        FirstCheckMark.SetActive(true);
        IsDone = IsFirstConditionDone && IsSecondConditionDone ? true : false;
    }

    public void MarkSecondCondition()
    {
        IsSecondConditionDone = true;
        FirstCheckMark.SetActive(true);
        IsDone = IsFirstConditionDone && IsSecondConditionDone ? true : false;
    }

    public void MakeButtonActive()
    {
        if (IsDone)
        {
            Button.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
            Button.GetComponent<Button>().interactable = true;
        }
    }

    public void GetReward()
    {
        Score.Add(PoitnsRewardCount);
        CellsStack.AddRandomCells(CellsRewardCount);
        DeleteTask();
    }

    public void DeleteTask()
    {
        Destroy(gameObject);
    }

    public void SetTutorialCurrText(int a)
    {
        Tutorial.CurrentText = a;
    }
}
