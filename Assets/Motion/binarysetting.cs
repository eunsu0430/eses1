using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
public class binarysetting : MonoBehaviour
{
    int i = 0;
    string filePath = Path.Combine(Application.streamingAssetsPath, "Example.bin");
    public Data_motion m_WriteData;

    public InputField m_InputField_m;//모션

    private float timer = 0;
    private void Start()
    {
        m_WriteData = new Data_motion();        
    }
    void Update()
    {
       
      
        if (button_timer.time_chk == 1)
        {
            timer += Time.deltaTime;
            
        }
        if (button_timer.time_chk == 2)
        {
    
            m_WriteData.m[i] = int.Parse(m_InputField_m.text);
            m_WriteData.time_save[i] = timer;
            i++;
            button_timer.time_chk = 0;       
        }
        if (button_timer.time_chk == 3)//end
        {
            // 바이너리파일은 확장자가 bin으로 해야 합니다. 
           WriteBinary(filePath, m_WriteData);
            button_timer.time_chk = 0;
        }
    }
    public void WriteBinary(string filePath, Data_motion binaryData)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));
        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = File.Open(filePath, FileMode.OpenOrCreate);
        binaryFormatter.Serialize(fileStream, binaryData);
        fileStream.Close();
    }
  
}
[Serializable]
public class Data_motion {
    public int[] m = new int[60];//모션
    public float[] time_save = new float[60];
}
