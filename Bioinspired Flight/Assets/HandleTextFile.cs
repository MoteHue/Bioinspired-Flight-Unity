using UnityEngine;
using UnityEditor;
using System.IO;

public class HandleTextFile : MonoBehaviour
{

    [MenuItem("Tools/Read file")]
    public string ReadString()
    {
        string path = "Assets/Sensor Information/test.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string text = reader.ReadToEnd();
        reader.Close();
        Debug.Log(text);
        return text;
    }

}
