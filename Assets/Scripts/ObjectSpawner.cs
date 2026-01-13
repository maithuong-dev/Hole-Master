using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [HideInInspector]
    public GameObject[] objectsToSpawn = new GameObject[4];
    public GameObject[] Models;
    public GameObject WinObject;
    private float Distance = 0.4f;
    private float Rotation = 5f;
    private int ObjectAmount = 10;
    private GameObject TempObject;

    void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        ModelSelection();

        int Level = LevelManager.Instance.GetLevel();

        Debug.Log("Spawning Objects for Level: " + Level);
        Debug.Log("Current Score: " + ScoreManager.Instance.GetScore().ToString());
        Debug.Log("Best Score: " + PlayerData.Instance.LoadData("BestScore").ToString());

        int randomBlockObject = Random.Range(10, 30);
        for (int i = 0; i < ObjectAmount * Level; i++)
        {   
            Vector3 spawnPosition = new Vector3(-0.01f, 12f - (i * Distance), 0.01f);
            Vector3 spawnRotation = new Vector3(0, Rotation, 0);

            if (i == randomBlockObject)
            {
                float[] allowedAngles = {90f, 180f, 270f, 360f};
                int randomIndex = Random.Range(0, allowedAngles.Length);

                spawnRotation = new Vector3(0, Rotation - allowedAngles[randomIndex], 0);
                randomBlockObject = Random.Range(10 + i, 30 + i);
            }

            if (Level <= 5)
                TempObject = Instantiate(objectsToSpawn[Random.Range(0, 2)], spawnPosition, Quaternion.Euler(spawnRotation));
            if (Level > 5 && Level <= 10)
                TempObject = Instantiate(objectsToSpawn[Random.Range(1, 3)], spawnPosition, Quaternion.Euler(spawnRotation));
            if (Level > 10 && Level <= 15)
                TempObject = Instantiate(objectsToSpawn[Random.Range(2, 4)], spawnPosition, Quaternion.Euler(spawnRotation));
            if (Level > 15 && Level <= 20)
                TempObject = Instantiate(objectsToSpawn[Random.Range(3, 4)], spawnPosition, Quaternion.Euler(spawnRotation));

            Rotation += 5f;

            TempObject.transform.parent = FindAnyObjectByType<Rotator>().transform;
        }

        Vector3 WinPosition = new Vector3(0, 12f - (ObjectAmount * Level * Distance), 0);
        Instantiate(WinObject, WinPosition, Quaternion.Euler(0, 0, 0));
    }

    private void ModelSelection()
    {
        int RandomModel = Random.Range(0, 5);

        Debug.Log("Random Model Selected: " + RandomModel);

        switch (RandomModel)
        {
            case 0:
                for (int i = 0; i < 4; i++)
                {
                    objectsToSpawn[i] = Models[i];
                }
                break;

            case 1:
                for (int i = 0; i < 4; i++)
                {
                    objectsToSpawn[i] = Models[i + 4];
                }
                break;

            case 2:
                for (int i = 0; i < 4; i++)
                {
                    objectsToSpawn[i] = Models[i + 8];
                }
                break;

            case 3:
                for (int i = 0; i < 4; i++)
                {
                    objectsToSpawn[i] = Models[i + 12];
                }
                break;

            case 4:
                for (int i = 0; i < 4; i++)
                {
                    objectsToSpawn[i] = Models[i + 16];
                }
                break;
        }
    }
}
