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
        //Add dummy data if there is nothing in the list to start off with
        if (list.Count == 0)
        {
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

        //Apparently I can store array lists into .sc files which is nice
        bf.Serialize(stream, list);

        //CLOSE
        stream.Close();
    }

    public List<int> loadData()
    {
        string path = Application.persistentDataPath + "/highScores.sc";

        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            //make a temporary arary list and give it whatever is in the .sc file (casted to an array list)
            List<int> scores = (List<int>)bf.Deserialize(stream);

            //CLOSE
            stream.Close();

            return scores;
        }
        else
        {
            return null;
        }
    }
}