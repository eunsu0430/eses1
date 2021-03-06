﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
public class checkbinaryfile : MonoBehaviour
{

    int i = 0;
    string filePath = Path.Combine(Application.streamingAssetsPath, "Example.bin");
    public Data_motion m_ReadData;



    private float timer = 0;
 
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, "Example.bin");
            // 바이너리파일은 확장자가 bin으로 해야 합니다. 
            if (Input.GetKeyDown(KeyCode.R))
            {
                m_ReadData = (Data_motion)ReadBinary<Data_motion>(filePath);
                Debug.Log(m_ReadData.m[0]);
                Debug.Log(m_ReadData.m[1]);
                Debug.Log(m_ReadData.m[2]);
                Debug.Log(m_ReadData.m[10]);
            }
        }
    
    }
  
    public T ReadBinary<T>(string filePath)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Open(filePath, FileMode.Open);

        if (fileStream != null && fileStream.Length > 0)
            return (T)binaryFormatter.Deserialize(fileStream);
        else
        {
            Debug.Log("바이너리 파일을 확인해 보세요!!");
            return default(T);
        }
    }
}
