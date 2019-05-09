using UnityEditor;
using System.IO;
using System;
using UnityEngine;

public class Bundle : EditorWindow {

    string inputDirectory = "Assets/ExpanseBundler/AssetBundles/Input";
    string outputDirectory = "Assets/ExpanseBundler/AssetBundles/Output";
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
       // BuildReferences.ResetReferences();
        foreach (string fileName in Directory.GetFiles(inputDirectory)) {
            switch (Path.GetExtension(fileName)) {
                case ".cs":
                    string newFileName = fileName.Substring(0, fileName.Length - Path.GetFileName(fileName).Length) + Path.GetFileNameWithoutExtension(fileName) + ".cs.txt";
                    File.Copy(fileName, newFileName);
                    break;
                case ".prefab":
                   // BuildReferences.Scan(fileName); //inputDirectory + "/" + 
                    break;
            }
        }

        AssetDatabase.Refresh();

        BuildBundle(BuildTarget.StandaloneWindows);
        string[] fileEntries = BuildBundle(BuildTarget.Android);

        foreach (string fileName in fileEntries) {
            if (fileName.Length > 7 && fileName.Substring(fileName.Length - 7) == ".cs.txt") {
                File.Delete(fileName);
            }
        }
        if (deleteManifests) {
            string[] newFileEntries = Directory.GetFiles(outputDirectory);
            foreach (string fileName in newFileEntries) {
                if (fileName.Substring(fileName.Length - 9) == ".manifest" ||
                    Path.GetFileName(fileName) == "Output" ||
                    Path.GetFileName(fileName) == "Output.meta" ||
                    fileName.Substring(fileName.Length - 14) == ".manifest.meta") {
                    File.Delete(fileName);
                }
            }
        }
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(outputDirectory + "/" + outputName);
        EditorGUIUtility.PingObject(Selection.activeObject);
        AssetDatabase.Refresh();
    }

    string[] BuildBundle(BuildTarget target) {
        string[] fileEntries = Directory.GetFiles(inputDirectory);
        foreach (string fileName in fileEntries) {
            if (Path.GetExtension(fileName) != ".cs") {
                AssetImporter asset = AssetImporter.GetAtPath(fileName);
                if (asset != null) {
                    asset.SetAssetBundleNameAndVariant(target == BuildTarget.StandaloneWindows ? outputName : outputName + "_android", "");
                }
            }
        }
        if (!Directory.Exists(outputDirectory)) {
            Directory.CreateDirectory(outputDirectory);
        }
        BuildPipeline.BuildAssetBundles(outputDirectory, BuildAssetBundleOptions.None, target);
        return fileEntries;
    }
}