using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEngine.UI;

public static class CreateBorderGameObject
{
    [MenuItem("Edit/Create Border Objects")]
    public static void CreateBorderObjects()
    {
        var objectList = Selection.gameObjects;
        var canvas = GameObject.FindObjectOfType<Canvas>();

        foreach(var ob in objectList)
        {
            var border = ObjectFactory.CreateGameObject($"{ob.name} - border");
            border.transform.SetParent(canvas.transform);
            var borderRT = border.AddComponent<RectTransform>();
            var obRT = ob.transform as RectTransform;
            borderRT.sizeDelta = new Vector2(obRT.sizeDelta.x + 5, obRT.sizeDelta.y + 5);
            Debug.Log($"Created border object for object '{ob.name}'");
        }
    }

    [MenuItem("Edit/Assign Parents")]
    public static void AssignParents()
    {
        var selection = Selection.gameObjects.ToList();
        var borders = selection.FindAll(x => x.name.Contains("border"));
        var objects = selection.FindAll(x => !x.name.Contains("border"));
        foreach(var ob in objects)
        {
            var parent = borders.Find(x => x.name.StartsWith(ob.name));
            if (parent)
                ob.transform.SetParent(parent.transform);
        }
    }
}
