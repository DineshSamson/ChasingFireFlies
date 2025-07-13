using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonData : MonoBehaviour
{
    void Start()
    {
        //GetData();
    }

    public List<IntPair> GetData()
    {
        string filePath = Application.persistentDataPath + "/pairs.json";

        List <IntPair> tmpList = new List <IntPair>();

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            IntPairList pairList = JsonUtility.FromJson<IntPairList>(json);

            // Print the values
            foreach (var pair in pairList.pairs)
            {
                Debug.Log($"First: {pair.cardIndex}, Second: {pair.optionIndex}");

             
                tmpList.Add(pair);
            }
        }
        else
        {
            Debug.LogWarning("JSON file not found!");
        }

        return tmpList;
    }

    public void StoreData(List<IntPair> data)
    {
        IntPairList pairList = new IntPairList();

        for (int i = 0; i < data.Count; i++)
        {
            pairList.pairs.Add(new IntPair(data[i].cardIndex, data[i].optionIndex));
        }

        // Convert to JSON
        string json = JsonUtility.ToJson(pairList, true); 
        //Debug.Log(json);

        System.IO.File.WriteAllText(Application.persistentDataPath + "/pairs.json", json);
    }

    public void ClearJson()
    {
        IntPairList emptyList = new IntPairList(); // no pairs
        string emptyJson = JsonUtility.ToJson(emptyList, true);

        // Overwrite the file
        File.WriteAllText(Application.persistentDataPath + "/pairs.json", emptyJson);
    }
}


[System.Serializable]
public class IntPairList
{
    public List<IntPair> pairs = new List<IntPair>();
}

[System.Serializable]
public class IntPair
{
    public int cardIndex;
    public int optionIndex;

    public IntPair(int a, int b)
    {
        cardIndex = a;
        optionIndex = b;
    }
}
