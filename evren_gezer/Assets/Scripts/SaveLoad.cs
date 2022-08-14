using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveData
{
    public static float fuel;
    public static float health;
    public static float coin;
    public static float[] shipPosition;
    public static float shipRotationZ;
    public static string sceneName;
    public static int numberOfMissiles;
}

public class SaveLoad 
{
    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = new FileStream("GameSave.bin", FileMode.Create, FileAccess.Write))
        {
            bf.Serialize(fs, SaveData.fuel);
            bf.Serialize(fs, SaveData.health);
            bf.Serialize(fs, SaveData.coin);
            bf.Serialize(fs, SaveData.shipPosition);
            bf.Serialize(fs, SaveData.shipRotationZ);
            bf.Serialize(fs, SaveData.sceneName);
            bf.Serialize(fs, SaveData.numberOfMissiles);
        }
    }

    public static void Load()
    {
        if(!File.Exists("GameSave.bin")){
            LoadNewGame();
            return;
        }
            
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = new FileStream("GameSave.bin", FileMode.Open, FileAccess.Read))
        {
            SaveData.fuel = (float)bf.Deserialize (fs);
            SaveData.health = (float)bf.Deserialize (fs);
            SaveData.coin = (float)bf.Deserialize (fs);
            SaveData.shipPosition = (float [])bf.Deserialize (fs);
            SaveData.shipRotationZ = (float)bf.Deserialize (fs);
            SaveData.sceneName = (string)bf.Deserialize (fs);
            SaveData.numberOfMissiles = (int)bf.Deserialize (fs);
        }
    }

    public static void LoadNewGame(){
        float [] positions = new float[] { -33f, 20f, 0f};
        SaveData.fuel = 0.5f;
        SaveData.health = 0.5f;
        SaveData.coin = 0f;
        SaveData.shipPosition = positions;
        SaveData.shipRotationZ = 0f;
        SaveData.sceneName = "";
        SaveData.numberOfMissiles = 5;
        SaveLoad.Save();
    }
}
