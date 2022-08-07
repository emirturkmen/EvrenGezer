using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class OrbitSaveData
{
    public static float fuel;
    public static float health;
    public static float coin;
    public static float[] shipPos;
    public static float[] shipRot;
    public static float shipVelo;
}


public class OrbitSaveLoad 
{
    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = new FileStream("GameSave.bin", FileMode.Create, FileAccess.Write))
        {
            bf.Serialize(fs, OrbitSaveData.fuel);
            bf.Serialize(fs, OrbitSaveData.health);
            bf.Serialize(fs, OrbitSaveData.coin);
            bf.Serialize(fs, OrbitSaveData.shipPos);
            bf.Serialize(fs, OrbitSaveData.shipRot);
            bf.Serialize(fs, OrbitSaveData.shipVelo);
        }
    }

    public static void Load()
    {
        if(!File.Exists("GameSave.bin"))
            return;
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream fs = new FileStream("GameSave.bin", FileMode.Open, FileAccess.Read))
        {
            OrbitSaveData.fuel = (float)bf.Deserialize (fs);
            OrbitSaveData.health = (float)bf.Deserialize (fs);
            OrbitSaveData.coin = (float)bf.Deserialize (fs);
            OrbitSaveData.shipPos = (float[])bf.Deserialize (fs);
            OrbitSaveData.shipRot = (float[])bf.Deserialize (fs);
            OrbitSaveData.shipVelo = (float)bf.Deserialize (fs);
        }
    }

}
