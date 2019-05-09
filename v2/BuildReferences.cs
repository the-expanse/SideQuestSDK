//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Reflection;
//using UnityEditor;
//using UnityEngine;

//public class BuildReferences{

//    public static Dictionary<string, Dictionary<string,Dictionary<string, string>>> prefabReferences = 
//        new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

//    public static void Scan(string prefabPath) {
//        GameObject prefab = (GameObject)AssetDatabase.LoadAssetAtPath(prefabPath, typeof(GameObject));
//        var children = prefab.transform.root.GetComponentsInChildren<Transform>();
//        GetAllChildComponents(children, (component, refrenceDictionary) => {
//           var key = component.GetInstanceID() + ":" + component.GetType().ToString();
//            var dictionary = new Dictionary<string, string>();
//            refrenceDictionary.Add(key, dictionary);
//            if (!component.GetType().ToString().StartsWith("UnityEngine.")) {
//                foreach (var field in component.GetType().GetFields()) {
//                    try {
//                       var fieldKey = component.GetInstanceID() + ":" + component.GetType().ToString() + ":" + field.FieldType.ToString() + ":" + field.Name;
//                       var value = field.GetValue(component);
//                       if(value != null) {
//                           string path;
//                           switch (field.FieldType.BaseType.ToString()) {
//                               case "UnityEngine.GameObject":
//                                   path = GetGameObjectPath(((GameObject)value).transform);
//                                   break;
//                               case "UnityEngine.Transform":
//                                   path = GetGameObjectPath((Transform)value);
//                                   break;
//                               case "UnityEngine.Collider":
//                                   path = GetGameObjectPath(((Collider)value).transform);
//                                   break;
//                               default:
//                                   path = GetGameObjectPath(((Component)value).transform);
//                                   break;
//                           }
//                           dictionary.Add(fieldKey, path);
//                       }
//                    } catch (Exception e) {
//                        Debug.LogError(e);
//                    }
//                }
//            }
//        });
//    }

//    static void GetAllChildComponents(Transform[] children,  Action<Component, Dictionary<string, Dictionary<string, string>>> callback) {
//        foreach (var child in children) {
//            MonoBehaviour[] components = child.GetComponents<MonoBehaviour>();
//            var componentReferences = new Dictionary<string, Dictionary<string, string>>();
//            for (int i = 0; i < components.Length; i++) {
//                callback(components[i], componentReferences);
//            }
//            prefabReferences.Add(GetGameObjectPath(child), componentReferences);
//        }
//    }

//    public static void ResetReferences() {
//        prefabReferences = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
//    }

//    public static string GetGameObjectPath(Transform transform) {
//        string path = transform.name;
//        while (transform.parent != null) {
//            transform = transform.parent;
//            path = transform.name + "/" + path;
//        }
//        return path;
//    }
//}
