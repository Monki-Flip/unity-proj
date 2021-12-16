using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnityProj
{
    public class TasksManager : MonoBehaviour
    {
        public CellsStack CellsStack;
        public Score Score;

        public Tutorial Tutorial;
        public GameObject Panel;
        public GameObject Content;
        public List<GameObject> TasksPrefab;
        public List<GameObject> TasksPrefabInPanel;
        public int NextTaskToAdd;

        public TMP_Text CellsInStackCount;

        public int TasksCount;
        public int TasksDone;
        public Image Bar;
        public TMP_Text TasksButtonPregressText;


        private void Start()
        {
            TasksCount = Tutorial.TasksCount;
        }

        public void AddTaskToPanel()
        {
            var prefab = Instantiate(TasksPrefab[NextTaskToAdd], Content.transform);
            NextTaskToAdd++;
            prefab.transform.localPosition = Vector2.zero;
            prefab.GetComponent<RectTransform>().transform.localScale = Vector3.one;

            TasksPrefabInPanel.Add(prefab);
        }

        public bool CheckTutorial1()
        {
            if (CellsInStackCount.text == "0")
            {
                ChangeTaskState("Tutorial1(Clone)");
                return true;
            }
            return false;
        }

        public void ChangeTaskState(string taskName)
        {
            Panel.SetActive(true);
            var tasks = Content.GetComponentsInChildren<Task>();
            foreach (var task in tasks)
            {
                if (task.gameObject.name == taskName)
                {
                    task.MarkFirstCondition();
                    task.MarkSecondCondition();
                    task.MakeButtonActive();
                    task.CellsStack = CellsStack;
                    task.Score = Score;
                    task.Tutorial = Tutorial;
                    break;
                }
            }
            Panel.SetActive(false);
        }

        public void UpdateTaskButton()
        {
            Debug.Log(TasksDone / TasksCount);
            var str = new StringBuilder();
            str.Append(TasksDone.ToString() + "/" + TasksCount.ToString());
            Bar.fillAmount = (float)TasksDone / (float)TasksCount;
            TasksButtonPregressText.text = str.ToString();
        }
    }
}