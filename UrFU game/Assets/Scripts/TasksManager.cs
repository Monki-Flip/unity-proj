using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksManager : MonoBehaviour
{
    public GameObject Content;
    public List<GameObject> TasksPrefab;
    public List<GameObject> TasksPrefabInPanel;
    public int NextTaskToAdd;

    public void AddTaskToPanel()
    {
        var prefab = Instantiate(TasksPrefab[NextTaskToAdd], Content.transform);
        NextTaskToAdd++;
        prefab.transform.localPosition = Vector2.zero;
        prefab.GetComponent<RectTransform>().transform.localScale = Vector3.one;

        TasksPrefabInPanel.Add(prefab);
    }
}
