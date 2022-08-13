using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveData
{
    public static float fuel;
    public static float health;
    public static float coin;
    public static float[] shipPosition;
    public static float[] shipRotation;
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
            bf.Serialize(fs, SaveData.shipRotation);
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
            SaveData.shipRotation = (float [])bf.Deserialize (fs);
        }
    }

    public static void LoadNewGame(){
        float [] positions = new float[] {-39.0f,16.775f,0f};
        float [] rotations = new float[] {0f,0f,0f};
        SaveData.fuel = 0.5f;
        SaveData.health = 0.5f;
        SaveData.coin = 0f;
        SaveData.shipPosition = positions;
        SaveData.shipRotation = rotations;
    }
}
