using UnityEngine;
using System.IO;

namespace Game {

    internal sealed class DataSystem : MonoBehaviour {
       
          private static string GetPath(string fileName) {
               return Path.Combine(Application.persistentDataPath, fileName + ".json");
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