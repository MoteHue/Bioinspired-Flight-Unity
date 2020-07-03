using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;
using UnityEngine;

public class SaveData
{
    public Dictionary<string, bool> data;
    private string saveDirectoryPath = Application.persistentDataPath;
    private string filePath;

    public SaveData(string filePath){
        this.filePath = filePath;
    }

    public void Load(){
        data = SaveData.DeserializeData<Dictionary<string, bool>>(saveDirectoryPath + "/" + filePath);
    }

    public void Save(){
        SaveData.SerializeData(data, saveDirectoryPath + "/" + filePath);
    }

    private static T DeserializeData<T>(string path){
        T data;
        try {
            data = System.Activator.CreateInstance<T>();
        } catch (MissingMethodException e) {
            data = default(T);
        }
        if (File.Exists(path)){
            FileStream fs = new FileStream(path, FileMode.Open);
            try {
                BinaryFormatter formatter = new BinaryFormatter();
                data = (T) formatter.Deserialize(fs);
                UnityEngine.Debug.Log("Data read from " + path);
            } catch (SerializationException e){
                UnityEngine.Debug.LogError(e.Message);
            } finally {
                fs.Close();
            }
        } else {
            UnityEngine.Debug.Log("what do");
        }
        UnityEngine.Debug.Log(data);
        return data;
        
    }

    private static void SerializeData<T>(T data, string path){
        FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
        BinaryFormatter formatter = new BinaryFormatter();
        try {
            formatter.Serialize(fs, data);
            UnityEngine.Debug.Log("Data written to " + path + " @ " + DateTime.Now.ToShortTimeString());
        } catch (SerializationException e){
            UnityEngine.Debug.LogError(e.Message);
        } finally {
            fs.Close();
        }
    }
}
