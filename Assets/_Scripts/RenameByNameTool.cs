using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Text.RegularExpressions;

[CustomEditor(typeof(RenameByNameTool))]
public class RenameByNameToolEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RenameByNameTool tool = (RenameByNameTool)target;

        if (GUILayout.Button("RENAME"))
        {
            tool.RenameObjects();
        }
    }
}

public class RenameByNameTool : MonoBehaviour
{
    [Header("Settings")]
    public string targetName = "Name"; // اسم مورد نظر
    public int startNumber = 1;        // شماره شروع
    public int digits = 3;             // تعداد رقم (مثلاً 3 → 001)
    public bool renameChildrenOnly = true; // فقط زیرمجموعه یا کل آبجکت‌ها

    public void RenameObjects()
    {
        List<GameObject> matches = new List<GameObject>();

        if (renameChildrenOnly)
        {
            GetChildrenRecursive(transform, matches);
        }
        else
        {
            // همه آبجکت‌ها بر اساس ترتیب Hierarchy
            foreach (GameObject obj in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
            {
                CollectHierarchy(obj.transform, matches);
            }
        }

        int counter = startNumber;
        foreach (var obj in matches)
        {
            // حذف عدد قبلی بعد از targetName
            string pattern = $@"^{Regex.Escape(targetName)}\s*\d*\s*";
            string restOfName = Regex.Replace(obj.name, pattern, "", RegexOptions.IgnoreCase).TrimStart();

            // ساخت نام جدید
            string newName = $"{targetName} {counter.ToString($"D{digits}")}";
            if (!string.IsNullOrEmpty(restOfName))
                newName += " " + restOfName;

            Undo.RecordObject(obj, "Rename Objects");
            obj.name = newName;
            counter++;
        }

        Debug.Log($"Renamed {matches.Count} objects starting with '{targetName}'");
    }

    private void GetChildrenRecursive(Transform parent, List<GameObject> list)
    {
        foreach (Transform child in parent)
        {
            if (child.name.StartsWith(targetName, System.StringComparison.OrdinalIgnoreCase))
                list.Add(child.gameObject);

            GetChildrenRecursive(child, list);
        }
    }

    private void CollectHierarchy(Transform parent, List<GameObject> list)
    {
        if (parent.name.StartsWith(targetName, System.StringComparison.OrdinalIgnoreCase))
            list.Add(parent.gameObject);

        foreach (Transform child in parent)
        {
            CollectHierarchy(child, list);
        }
    }
}
