using UnityEditor;
using System.IO;
using System;
using UnityEngine;

public class Bundle : EditorWindow {

    string inputDirectory = "Assets/AssetBundles/Input";
    string outputDirectory = "Assets/AssetBundles/Output";
    string outputName = "my_bundle";
    bool deleteManifests = true;

    public Texture tex;

    void OnGUI() {
        minSize = new Vector2(350, 288);
        var centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperCenter;
        GUILayout.Label(tex, centeredStyle);
        GUILayout.FlexibleSpace();
        GUILayout.MinHeight(400f);
        GUILayout.Label("Expanse Asset Bundle Settings", EditorStyles.boldLabel);
        GUILayout.Label("Enter the below settings to generate your asset bundles.\nWARNING: Items in the output folder may be overwritten!", EditorStyles.wordWrappedLabel);
        GUILayout.Space(20);
        inputDirectory = EditorGUILayout.TextField("Input Directory", inputDirectory);
        outputDirectory = EditorGUILayout.TextField("Output Directory", outputDirectory);
        outputName = EditorGUILayout.TextField("Output Name", outputName);
        deleteManifests = EditorGUILayout.Toggle("Remove Manifests", deleteManifests);
        GUILayout.Space(10);
        if (GUILayout.Button("Build")) {
            BuildAllAssetBundles();
        }
    }
    
    [MenuItem("Tools/ExpanseBundler")]
    public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(Bundle));
    }
    
    void BuildAllAssetBundles() {
        if (!Directory.Exists(inputDirectory)) {
            EditorUtility.DisplayDialog("No Input", "The input directory does not exist!", "OK");
            return;
        }
        BuildBundle(BuildTarget.StandaloneWindows);
        string[] fileEntries = BuildBundle(BuildTarget.Android);
        
        foreach (string fileName in fileEntries) {
            if (fileName.Length>7 && fileName.Substring(fileName.Length-7) == ".cs.txt") {
                File.Move(fileName, fileName.Substring(0, fileName.Length - 7) + ".cs");
            }
        }
        if (deleteManifests) {
            string[] newFileEntries = Directory.GetFiles(outputDirectory);
            foreach (string fileName in newFileEntries) {
                if(Path.GetExtension(fileName) == ".manifest" || Path.GetFileName(fileName) == "Output") {
                    File.Delete(fileName);
                }
            }
        }
        EditorUtility.DisplayDialog("Done", "Asset bundles completed OK!", "Close");
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(outputDirectory+"/"+outputName);
        EditorGUIUtility.PingObject(Selection.activeObject);
    }

    string[] BuildBundle(BuildTarget target) {
        string[] fileEntries = Directory.GetFiles(inputDirectory);
        foreach (string fileName in fileEntries) {
            AssetImporter asset;
            if (Path.GetExtension(fileName) == ".cs") {
                string newFileName = fileName.Substring(0, fileName.Length - Path.GetFileName(fileName).Length) + Path.GetFileNameWithoutExtension(fileName) + ".cs.txt";
                File.Move(fileName, newFileName);
                asset = AssetImporter.GetAtPath(newFileName);
            } else {
                asset = AssetImporter.GetAtPath(fileName);
            }
            if (asset != null) {
                asset.SetAssetBundleNameAndVariant(target == BuildTarget.StandaloneWindows? outputName : outputName+"_android", "");
            }
        }
        if (!Directory.Exists(outputDirectory)) {
            Directory.CreateDirectory(outputDirectory);
        }
        BuildPipeline.BuildAssetBundles(outputDirectory, BuildAssetBundleOptions.None, target);
        return fileEntries;
    }
}