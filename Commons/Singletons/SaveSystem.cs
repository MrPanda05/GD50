using Godot;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Text.Json;

namespace Commons.Singletons
{
    public partial class SaveSystem : Node
    {
        public static SaveSystem Instance { get; private set; }

        public static Dictionary<string, int> saveData = new Dictionary<string, int>();


        public static void Save()
        {
            using var myFile = FileAccess.Open("user://mySaveData.amongus", FileAccess.ModeFlags.Write);
            string json = JsonSerializer.Serialize(saveData);
            myFile.StoreString(json);
            GD.Print(json);
            myFile.Close();
        }
        public static void Load()
        {
            if(!FileAccess.FileExists("user://mySaveData.amongus")) return;
            using var myFile = FileAccess.Open("user://mySaveData.amongus", FileAccess.ModeFlags.Read);
            var json = myFile.GetAsText();
            var penis = JsonSerializer.Deserialize<Dictionary<string, int>>(json);
            foreach (var item in penis)
            {
                FillDick(item.Key, item.Value);
            }
            myFile.Close();


        }
        private static void FillDick(string key, int value)//just cammed
        {
            if (saveData.ContainsKey(key))
            {
                saveData[key] = value;
                return;
            }
            saveData.Add(key, value);
        }
        public static void Add(string key, int value)
        {
            if(saveData.ContainsKey(key)) return;

            saveData.Add(key, value);
            Save();
        }
        public static void Update(string key, int value)
        {
            if(!saveData.ContainsKey(key))
            {
                Add(key, value);
                return;
            }
            saveData[key] = value;
            Save();
        }

        public static int? GetValue(string key)
        {
            if(!saveData.ContainsKey(key)) return null;
            return saveData[key];
        }
        public override void _Ready()
        {
            Load();
        }
    }
}
