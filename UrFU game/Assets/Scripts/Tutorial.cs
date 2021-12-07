using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public TasksManager TasksManager;
    public GameObject AngelPanel;
    public Canvas Canv;
    public Image Panel;
    public Cloud TextCloud;
    public int CurrentTask;
    public int CurrentText;

    public bool[] IsRun;

    private void Start()
    {
        IsRun = new bool[10];
    }
    private void Update()
    {
        if (CurrentText == 0)
        {
            if (!Canv.enabled)
                CurrentText++;
            else if (!IsRun[CurrentText])
            {
                Debug.Log(IsRun[CurrentText].ToString() + CurrentText);
                IsRun[CurrentText] = true;
                TextCloud.PlayAnim("Open1");
                TextCloud.DisplayText(CurrentText);
                Debug.Log(IsRun[CurrentText].ToString() + CurrentText);
            }
        }
        else if (CurrentText == 1)
        {
            if (!IsRun[CurrentText])
            {
                IsRun[CurrentText] = true;
                System.Threading.Thread.Sleep(2000);
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
        }
    }

    public void NextText()
    {
        CurrentText++;
    }
}
