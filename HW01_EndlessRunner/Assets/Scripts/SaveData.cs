using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public  void saveData(List<int> list)
    {
        if (list.Count == 0)
        {
            //Dummy data
            list = new List<int>();
            list.Add(0);
            list.Add(4);
            list.Add(2);
            list.Add(3);
            list.Add(1);
        }

        string path = Application.persistentDataPath + "/highScores.sc";

        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        bf.Serialize(stream, list);

        stream.Close();
    }

    public List<int> loadData()
    {
        string path = Application.persistentDataPath + "/highScores.sc";

        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            List<int> scores = (List<int>)bf.Deserialize(stream);
            stream.Close();

            return scores;
        }
        else
        {
            return null;
        }
    }
}