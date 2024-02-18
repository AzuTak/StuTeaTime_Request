using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
<<<<<<< HEAD
=======
using UnityEngine.SceneManagement;
>>>>>>> weizu/main

public class SaveAndLoad : MonoBehaviour
{
    PlayerData PlayerData;
    public SaveData SaveData;
    public bool LoadEnd;
    public bool SaveOK;
    string FilePath;
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        LoadEnd = false;
        PlayerData = this.gameObject.GetComponent<PlayerData>();
        FilePath = Application.persistentDataPath + "/" + "SaveData.json";
        if(!File.Exists(FilePath))
        {
            SaveData.First = PlayerData.First;
            SaveData.Coins = PlayerData.Money;
            Save(SaveData);
            LoadEnd = true;
        }
        else
        {
            SaveData Data = Load();
            PlayerData.First = Data.First;
            PlayerData.Money = Data.Coins;
            LoadEnd = true;
        }
=======
        FilePath = Application.persistentDataPath + "/" + "SaveData.json";
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            LoadEnd = false;
            PlayerData = this.gameObject.GetComponent<PlayerData>();
            if(!File.Exists(FilePath))
            {
                SaveData.First = PlayerData.First;
                SaveData.Coins = PlayerData.Money;
                Save(SaveData);
                LoadEnd = true;
            }
            else
            {
                SaveData Data = Load();
                PlayerData.First = Data.First;
                PlayerData.Money = Data.Coins;
                LoadEnd = true;
            }
        }
        
>>>>>>> weizu/main
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if(SaveOK == false)
        {
            SaveData.First = PlayerData.First;
            SaveData.Coins = PlayerData.Money;
            Save(SaveData);
            SaveOK = true;
        }
        
=======
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            if(SaveOK == false)
            {
                SaveData.First = PlayerData.First;
                SaveData.Coins = PlayerData.Money;
                SaveData.OrderMenu = PlayerData.OrderMenu;
                Save(SaveData);
                SaveOK = true;
            }
        }
        
        
>>>>>>> weizu/main
    }
    public void Save(SaveData Data)
    {
        string json = JsonUtility.ToJson(Data);
        StreamWriter writer = new StreamWriter(FilePath , false);
        writer.WriteLine(json);
        writer.Close();
    }
    public SaveData Load()
    {
        StreamReader reader = new StreamReader(FilePath);
        string json = reader.ReadToEnd();
        reader.Close();
        return JsonUtility.FromJson<SaveData>(json);
    }
<<<<<<< HEAD
=======
    public bool ExistSaveData()
    {
        return File.Exists(FilePath);
    }
>>>>>>> weizu/main
}
[System.Serializable]
public class SaveData
{
    public bool First;
    public int Coins;
    public int TotalSec;
    public int TotalMin;
    public int TotalHou;
<<<<<<< HEAD
    public List<string> NextFree;
=======
    public List<string> OrderMenu = new List<string>();
>>>>>>> weizu/main
}