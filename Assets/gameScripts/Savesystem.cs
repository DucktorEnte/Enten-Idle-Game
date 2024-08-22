using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices.ComTypes;

public static class Savesystem 
{
    private static string path = Application.persistentDataPath + "/gameManager.stupid";
    public static void saveGameManager(GameManager gameManager) { 
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameManager.stupid";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(gameManager);
        Logger.DevTest(path);
        bf.Serialize(stream,data);
        stream.Close();
    }

    //DAs ist scheiﬂe so, weil 
    public static GameData loadGameData() {

        //use this to be good

        //saveGameManager(new GameData().loadDataToGameManager(new GameManager())) ;


        string path = Application.persistentDataPath + "/gameManager.stupid";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = bf.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            return new GameData();
        }

    }

}
