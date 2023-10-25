using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    //This will work on any computer. As long as you run from the same BUILD, high scores will save no matter what and on any computer
    public void saveData(List<int> list)
    {
        //Add dummy data if there is nothing in the list to start off with
        if (list.Count == 0)
        {
            //list = new List<int>();
            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Add(0);
            list.Add(0);
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
        else //If there wasn't anything in there:
        {
            //Call saveData() to make a new file and throw in some dummy data
            List<int> temp = new List<int>();
            saveData(temp);

            return null;
        }
    }
}