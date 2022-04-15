using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class AlmacenarDatos : MonoBehaviour
{
    public AlmacenarDatos instancia;
    public DataPersistencia data;
    public string savedata = "save.dat";
    public static float puntuacion;

    // Update is called once per frame
    void Update()
    {
        if ((Controller_Hud.distance > puntuacion)) {
            Controller_Hud.bestSavedDistance = Controller_Hud.distance;
            puntuacion = Controller_Hud.distance;
            SaveData();
        }

        if (Controller_Hud.gameOver)
        {
            Debug.Log("puntuacion: " + puntuacion);
            Debug.Log("bestSavedDistance:" + Controller_Hud.bestSavedDistance);
            LoadData();
        }
        
    }

    public void SaveData()
    {
        string filePath = Application.persistentDataPath + "/" + savedata;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Datos guardados");


    }


    public void LoadData()
    {
        string filePath = Application.persistentDataPath + "/" + savedata;
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(filePath))
        {
            FileStream file = File.Open(filePath, FileMode.Open);
            DataPersistencia cargado = (DataPersistencia)bf.Deserialize(file);
            data = cargado;
            file.Close();
            Debug.Log("Datos cargados");


        }

    }

    [System.Serializable]
    public class DataPersistencia
    {
        public float record;

        public DataPersistencia()
        {
            record = puntuacion;

        }
    }

}

