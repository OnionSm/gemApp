using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;

public class DataPersistaceManager : MonoBehaviour
{
    public static DataPersistaceManager instance { get; private set; }
    public  List<SaveSlot> gameData {  get; private set; }
    private List<IDataPersistance> listDataPersistances = new List<IDataPersistance>();
    private FileHandlerData fileHandlerData;
    private string persistent_path;
    [SerializeField] private SaveSlot slot_choosen;
    public SaveSlot SlotChoosen
    {
        get { return slot_choosen; }
        set { slot_choosen = value; }
    }
    private void Awake()
    {
        persistent_path = Application.persistentDataPath;
        if (instance != null)
        {
            Debug.Log("More than one intance in Game !!!");
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        fileHandlerData = new FileHandlerData();
    }

    public void Start()
    {
        gameData = new List<SaveSlot>();
        LoadListSaveGame();
        GetLastSlotAccess();
        listDataPersistances =  FindAllDataInObject();
    }


    public void CreateNewUser(String name)
    {
        slot_choosen = new SaveSlot();
        slot_choosen.character_name = name;
        fileHandlerData.CreateFileIfNotExists(persistent_path, name + ".txt");
        fileHandlerData.WriteData(slot_choosen, persistent_path, name + ".txt");
    }
    
    public void LoadListSaveGame()
    {
        string[] txtFiles = GetTextFilesInDirectory(persistent_path);
        foreach (string file in txtFiles)
        {
            String path = file.Split('\\')[1];
            Debug.Log(path);
            SaveSlot save_slot = fileHandlerData.ReadData(Path.Combine(persistent_path,path));
            Debug.Log(Path.Combine(persistent_path, path));    
            if(save_slot != null) 
            {
                gameData.Add(save_slot);
            }
        }
    }
    private string[] GetTextFilesInDirectory(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            // Tìm tất cả các tệp tin .txt trong thư mục
            return Directory.GetFiles(directoryPath, "*.txt", SearchOption.AllDirectories);
        }
        else
        {
            Debug.LogError("Directory not found: " + directoryPath);
            return new string[0];
        }
    }
    public void LoadGame()
    {
        if (slot_choosen != null)
        {
            foreach (IDataPersistance persistance in listDataPersistances)
            {
                persistance.LoadGame(slot_choosen);
            }
            Debug.Log("Loaded");
        }
        else
        {   
            Debug.Log("Load Failed");
        }
    }
    public void SaveGame()
    {
        foreach (IDataPersistance persistance in listDataPersistances)
        {
            persistance.SaveGame(ref slot_choosen);
        }
        fileHandlerData.WriteData(slot_choosen, persistent_path, slot_choosen.character_name + ".txt");
        Debug.Log("Saved");
    }

    private void OnApplicationQuit()
    {
        if (slot_choosen != null)
        {
            SaveGame();
        }
    }


    private List<IDataPersistance> FindAllDataInObject()
    {
        IEnumerable<IDataPersistance> listDataPersistances = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(listDataPersistances);
    }

    private void GetLastSlotAccess()
    {
        string latestAccessedFile = GetLatestAccessedTextFile(persistent_path);
        if(latestAccessedFile != null) 
        {

            slot_choosen =  fileHandlerData.ReadData(Path.Combine(persistent_path , latestAccessedFile)); 
        }
        else
        {
            Debug.Log("Không tìm thấy file truy cập");
        }
    }
    private string GetLatestAccessedTextFile(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            string[] txtFiles = Directory.GetFiles(directoryPath, "*.txt", SearchOption.AllDirectories);

            string latestFile = null;
            DateTime latestAccessTime = DateTime.MinValue;

            foreach (string file in txtFiles)
            {
                DateTime accessTime = File.GetLastAccessTime(file);

                if (accessTime > latestAccessTime)
                {
                    latestAccessTime = accessTime;
                    latestFile = file;
                }
            }

            return latestFile;
        }
        else
        {
            Debug.LogError("Directory not found: " + directoryPath);
            return null;
        }
    }
}
