using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject MESSAGE;  //MESSAGE.SetActive(true);

    public TasksManager TasksManager;
    public GameObject AngelPanel;
    public Canvas Canv;
    public Image Panel;
    public Cloud TextCloud;
    public GameObject TasksPanel;
    public CellsManager CellsManager;
    public GameObject ModelInfo;

    public Animation TutorialTasksHelper;
    public Animation TutorialModelHelper;

    public int CurrentIteration;
    public int CurrentText;
    public int TextCount;

    public bool[] IsRun;

    public int TasksCount;

    public bool IsTutorial1Done;

    private void Start()
    {
        IsRun = new bool[50];
    }
    private void Update()
    {
        if (CurrentIteration == 0)
        {
            if (!Canv.enabled)
                CurrentIteration++;
            else if (!IsRun[CurrentIteration])
            {
                IsRun[CurrentIteration] = true;
                TextCloud.PlayAnim("Open1");
                TextCloud.DisplayText(CurrentText);
                CurrentText++;
            }
        }
        else if (CurrentIteration == 1)
        {
            if (!IsRun[CurrentIteration])
            {
                IsRun[CurrentIteration] = true;
                System.Threading.Thread.Sleep(1000);
                Canv.enabled = true;
                TextCloud.MakeCloseButtonBlack();
                Panel.color = new Color(0, 0, 0, 0.5f);
                TextCloud.PlayAnim("Open2");
                TextCloud.ChangeButton();
                TextCloud.DisplayText(CurrentText);
                CurrentText++;
            }
            else if (!TextCloud.IsTyping)
                CurrentIteration++;
        }
        else if (CurrentIteration == 2)
        {
            if (!IsRun[CurrentIteration])
            {
                IsRun[CurrentIteration] = true;
                TextCloud.PlayAnim("Open2");
                TextCloud.ChangeButton();
                TextCloud.DisplayText(CurrentText);
                CurrentText++;
                TasksManager.AddTaskToPanel();
            }
            else if (!TextCloud.IsTyping)
                CurrentIteration++;
        }
        else if (CurrentIteration == 3)
        {
            if (TasksManager.CheckTutorial1() && !IsRun[CurrentIteration])
            {
                IsRun[CurrentIteration] = true;
                Canv.enabled = true;
                TasksManager.TasksDone++;
                TasksManager.UpdateTaskButton();
                TextCloud.ChangeButton();
                TextCloud.PlayAnim("Open1");
                TextCloud.DisplayText(CurrentText);
                CurrentText++;

            }
        }
        else if (CurrentIteration == 4)
        {
            if (!IsRun[CurrentIteration])
            {
                IsRun[CurrentIteration] = true;
                TextCloud.ChangeButton();
                TextCloud.PlayAnim("Open2");
                TextCloud.DisplayText(CurrentText);
                CurrentText++;
            }
            else if (!TextCloud.IsTyping)
                CurrentIteration++;
        }
        else if (CurrentIteration == 5)
        {
            IsRun[CurrentIteration] = true;
            TutorialTasksHelper.gameObject.SetActive(true);
            TutorialTasksHelper.Play();
        }
        else if (CurrentIteration == 6)
        {
            if (!IsRun[CurrentIteration])
            {
                IsRun[CurrentIteration] = true;
                TutorialTasksHelper.gameObject.SetActive(false);
                Canv.enabled = true;
                TasksPanel.SetActive(false);
                TextCloud.PlayAnim("Open2");
                TextCloud.DisplayText(CurrentText);
                CurrentText++;
            }
            else if (!TextCloud.IsTyping)
            {
                CellsManager.PutAnimalOnCell(CellsManager.GetRandomCellForAnimal(), "Deer");
                CurrentIteration++;
            }
        }
        else if (CurrentIteration == 7)
        {
            if (!IsRun[CurrentIteration])
            {
                System.Threading.Thread.Sleep(1000);
                IsRun[CurrentIteration] = true;
                Canv.enabled = true;
                TasksPanel.SetActive(false);
                TextCloud.PlayAnim("Open3");
                TextCloud.DisplayText(CurrentText);
                CurrentText++;
            }
            else if (!TextCloud.IsTyping)
                CurrentIteration++;
        }
        else if (CurrentIteration == 8)
        {
            IsRun[CurrentIteration] = true;
            TutorialModelHelper.gameObject.SetActive(true);
            TutorialModelHelper.Play();
            if (ModelInfo.activeSelf)
            {
                CurrentIteration++;
            }
        }
        else if (CurrentIteration == 9)
        {
            if (!IsRun[CurrentIteration])
            {
                IsRun[CurrentIteration] = true;
                TutorialModelHelper.gameObject.SetActive(false);
                Canv.enabled = true;
                Panel.enabled = false;
                TextCloud.Angel.transform.localPosition += new Vector3(40f, 0f, 0f);
                TextCloud.gameObject.transform.localPosition += new Vector3(40f, 0f, 0f);
                TextCloud.ChangeButton();
                TextCloud.PlayAnim("Open4.2");
                TextCloud.DisplayText(CurrentText);
                TextCloud.NextTextButton.transform.localPosition += new Vector3(150f, 50f, 0f);
                TextCloud.CloseButton.transform.localPosition += new Vector3(150f, 50f, 0f);
                CurrentText++;
            }
        }
        else if (CurrentIteration == 10)
        {
            if (!IsRun[CurrentIteration])
            {
                IsRun[CurrentIteration] = true;
                TextCloud.PlayAnim("Open4");
                TextCloud.DisplayText(CurrentText);
                CurrentText++;
            }
        }
        else if (CurrentIteration == 11)
        {
            if (!IsRun[CurrentIteration])
            {
                IsRun[CurrentIteration] = true;
                TextCloud.PlayAnim("Open4.2");
                TextCloud.DisplayText(CurrentText);
                CurrentText++;
            }
        }
        else if (CurrentIteration == 12)
        {
            if (!IsRun[CurrentIteration])
            {
                IsRun[CurrentIteration] = true;
                TextCloud.ChangeButton();
                TextCloud.PlayAnim("Open4.2");
                TextCloud.DisplayText(CurrentText);
                CurrentText++;
            }
            else if (!TextCloud.IsTyping)
            {
                TextCloud.NextTextButton.transform.localPosition += new Vector3(-40f, 0f, 0f);
                TextCloud.CloseButton.transform.localPosition += new Vector3(-40f, 0f, 0f);
                TextCloud.Angel.transform.localPosition += new Vector3(-150f, -50f, 0f);
                TextCloud.gameObject.transform.localPosition += new Vector3(-150f, -50f, 0f);
            }
        }
    }

    public void NextText() //NextIteration, но если поменять, все сломается
    {
        CurrentIteration++;
    }

    public void Tutorial1Done()
    {
        IsTutorial1Done = true;
    }

}
