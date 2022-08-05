using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveData
{
    public static float fuel;
    public static float health;
    public static float coin;
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
        }
    }

    public static void Load()
    {
        if(!File.Exists("GameSave.bin"))
            return;
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = new FileStream("GameSave.bin", FileMode.Open, FileAccess.Read))
        {
            SaveData.fuel = (float)bf.Deserialize (fs);
            SaveData.health = (float)bf.Deserialize (fs);
            SaveData.coin = (float)bf.Deserialize (fs);
        }
    }

}
