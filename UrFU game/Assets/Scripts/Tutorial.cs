using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject MESSAGE;

    public TasksManager TasksManager;
    public GameObject AngelPanel;
    public Canvas Canv;
    public Image Panel;
    public Cloud TextCloud;
    public Animation TutorialTasksHelper;

    public int CurrentTask;
    public int CurrentText;
    public int TextCount;

    public bool[] IsRun;

    public int TasksCount;

    public bool IsTutorial1Done;

    private void Start()
    {
        IsRun = new bool[TextCount];
    }
    private void Update()
    {
        if (CurrentText == 0)
        {
            if (!Canv.enabled)
                CurrentText++;
            else if (!IsRun[CurrentText])
            {
                IsRun[CurrentText] = true;
                TextCloud.PlayAnim("Open1");
                TextCloud.DisplayText(CurrentText);
            }
        }
        else if (CurrentText == 1)
        {
            if (!IsRun[CurrentText])
            {
                IsRun[CurrentText] = true;
                System.Threading.Thread.Sleep(1000);
                Canv.enabled = true;
                TextCloud.MakeCloseButtonBlack();
                Panel.color = new Color(0, 0, 0, 0.5f);
                TextCloud.PlayAnim("Open2");
                TextCloud.ChangeButton();
                TextCloud.DisplayText(CurrentText);
            }
            else if (!TextCloud.IsTyping)
                CurrentText++;
        }
        else if (CurrentText == 2)
        {
            if (!IsRun[CurrentText])
            {
                IsRun[CurrentText] = true;
                TextCloud.PlayAnim("Open2");
                TextCloud.ChangeButton();
                TextCloud.DisplayText(CurrentText);
                TasksManager.AddTaskToPanel();
            }
            else if (!TextCloud.IsTyping)
                CurrentText++;
        }
        else if (CurrentText == 3)
        {
            if (TasksManager.CheckTutorial1() && !IsRun[CurrentText])
            {
                Debug.Log("зашел31");
                IsRun[CurrentText] = true;
                Canv.enabled = true;
                TasksManager.TasksDone++;
                TasksManager.UpdateTaskButton();
                TextCloud.ChangeButton();
                TextCloud.PlayAnim("Open1");
                TextCloud.DisplayText(CurrentText);

            }
        }
        else if (CurrentText == 4)
        {
            if (!IsRun[CurrentText])
            {
                Debug.Log("зашел41");
                IsRun[CurrentText] = true;
                TextCloud.ChangeButton();
                TextCloud.PlayAnim("Open1");
                TextCloud.DisplayText(CurrentText);
            }
            else if (!TextCloud.IsTyping)
            {
                Debug.Log("зашел42");
                CurrentText++;
            }
        }
        else if (CurrentText == 5)
        {
            if (!IsRun[CurrentText])
            {
                TutorialTasksHelper.gameObject.SetActive(true);
                TutorialTasksHelper.Play();
            }
            else if (IsTutorial1Done)
            {
                TutorialTasksHelper.gameObject.SetActive(false);
                CurrentText++;
            }
        }
        else if (CurrentText == 6)
        {
            MESSAGE.SetActive(true);
        }
    }

    public void NextText()
    {
        CurrentText++;
    }

    public void Tutorial1Done()
    {
        IsTutorial1Done = true;
    }

}
