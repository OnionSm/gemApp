using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileHandlerData 
{
    /*public string dataDirPath = "";
    public string dataFileName = "";


    public FileHandlerData(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }*/



    public void CreateFileIfNotExists(String dataDirPath, String dataFileName)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        if (!File.Exists(fullPath))
        {
            File.Create(fullPath).Close();
            Debug.Log("File created at: " + fullPath);
        }
    }

    public SaveSlot ReadData(String fullPath)
    {
        try
        {
            string jsonData = File.ReadAllText(fullPath);
            SaveSlot loadedData = JsonUtility.FromJson<SaveSlot>(jsonData);
            Debug.Log("Data read from: " + fullPath);
            return loadedData;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return null;
        }
    }
    public void WriteData(SaveSlot data, String dataDirPath, String dataFileName)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            string jsonData = JsonUtility.ToJson(data, true);
            File.WriteAllText(fullPath, jsonData);
            Debug.Log("Data written to: " + fullPath);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

    }
}
