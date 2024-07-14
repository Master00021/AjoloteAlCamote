using UnityEngine;
using System.IO;
using UnityEditor;

namespace Game {

    internal sealed class DataSystem : MonoBehaviour {
       
          private static string GetPath(string fileName) {
               string folderName = "SaveData";

               string folderPath = "Assets/" + folderName;

               if (!AssetDatabase.IsValidFolder(folderPath)) {
                    AssetDatabase.CreateFolder("Assets", folderName);
                    Debug.Log($"Carpeta {folderName} creada en Assets/");
               }


               string fullPath = folderPath + "/" + fileName + ".json";
               return fullPath;
          }

          public static void SaveLevelData(LevelData levelData) {
               string json = JsonUtility.ToJson(levelData);
               File.WriteAllText(GetPath(levelData.name), json);
          }

          public static void LoadLevelData(LevelData levelData) {
               string path = GetPath(levelData.name);
               
               if (File.Exists(path)) {
                    string json = File.ReadAllText(path);
                    JsonUtility.FromJsonOverwrite(json, levelData);
               }
          }

    }
}