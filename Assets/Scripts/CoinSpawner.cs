using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;

    private float[] arrPosX = { -6.6f, -5.5f, -4.4f, -3.3f, -2.2f, -1.1f, 0f, 1.1f, 2.2f, 3.3f, 4.4f, 5.5f, 6.6f };

    [SerializeField]
    private float spawnInterval;

    void Start()
    {
        StartCoinRoutine();
    }

    void StartCoinRoutine()
    {
        StartCoroutine("CoinRoutine");
    }

    void StopCoinRoutine()
    {
        StopCoroutine("CoinToutine");
    }

    IEnumerator CoinRoutine() {
        yield return new WaitForSeconds(7f);

        while (true) {
            int posX = Random.Range(0, arrPosX.Length);
            SpawnCoin(posX);

            yield return new WaitForSeconds(spawnInterval);
        }

    }

    void SpawnCoin(int posX)
    {
        Vector3 spawnPos = new Vector3(arrPosX[posX], 5.5f, transform.position.z);
        Instantiate(coin, spawnPos, Quaternion.identity);
    }
}
