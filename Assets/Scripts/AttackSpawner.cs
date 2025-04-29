using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] items;

    private float[] arrPosX = { -6.6f, -5.5f, -4.4f, -3.3f, -2.2f, -1.1f, 0f, 1.1f, 2.2f, 3.3f, 4.4f, 5.5f, 6.6f };

    [SerializeField]
    private float spawnInterval;

    void Start()
    {
        StartAttactRouter();
    }

    void StartAttactRouter() {
        StartCoroutine("AttactRoutine");
    }

    IEnumerator AttactRoutine() {
        yield return new WaitForSeconds(3f);
        
        while (true)
        {
            int posX = Random.Range(0, arrPosX.Length);     // 생성 위치를 결정
            int index = Random.Range(0, items.Length);      // 종류를 결정
            SpawnAttact(posX, index);

            yield return new WaitForSeconds(spawnInterval);
        }
        
    }

    void SpawnAttact(int posX, int index) {
        Vector3 spawnPos = new Vector3(arrPosX[posX], 5.5f, transform.position.z);
        Instantiate(items[index], spawnPos, Quaternion.identity);
    }
}
