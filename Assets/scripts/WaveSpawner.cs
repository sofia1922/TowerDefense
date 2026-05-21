using System.Collections;
<<<<<<< HEAD
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [Header("Path")]
    public Transform[] waypoints;

    [Header("Enemy")]
    public EnemyData[] enemyTypes;
    public GameObject enemyPrefab;

    [Header("Wave Settings")]
    public int maxWaves = 5;
    public int startWaveBudget = 80;
    public int budgetIncreasePerWave = 50;

    public float spawnIntervalMin = 0.8f;
    public float spawnIntervalMax = 1.2f;

    public float timeBetweenWaves = 3f;

    [Header("Preparation")]
    public float preparationTime = 10f;

    [Header("UI")]
    public TMP_Text waveText;
    public CanvasGroup waveCanvasGroup;

    private int currentWave = 0;
    private bool allWavesFinished = false;

    void Start()
    {
        if (waveText != null)
            waveText.gameObject.SetActive(false);

        if (waveCanvasGroup != null)
            waveCanvasGroup.alpha = 0f;

        StartCoroutine(WaveLoop());
    }

    IEnumerator WaveLoop()
    {
        while (currentWave < maxWaves)
        {
            currentWave++;

            yield return StartCoroutine(PreparationPhase());

            yield return StartCoroutine(ShowWaveText());

            int waveBudget =
                startWaveBudget +
                (currentWave - 1) * budgetIncreasePerWave;

            yield return StartCoroutine(
                SpawnWaveRoutine(waveBudget)
            );

            yield return new WaitUntil(() =>
                GameObject.FindGameObjectsWithTag("Enemy").Length == 0
            );

            if (currentWave < maxWaves)
            {
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }

        allWavesFinished = true;
    }

    IEnumerator PreparationPhase()
    {
        if (waveText == null || waveCanvasGroup == null)
            yield break;

        waveText.gameObject.SetActive(true);

        waveText.text = "PREPARE";

        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime;

            waveCanvasGroup.alpha =
                Mathf.Lerp(0f, 1f, time);

            yield return null;
        }

        yield return new WaitForSeconds(preparationTime);

        time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime;

            waveCanvasGroup.alpha =
                Mathf.Lerp(1f, 0f, time);

            yield return null;
        }

        waveCanvasGroup.alpha = 0f;
        waveText.gameObject.SetActive(false);
    }

    IEnumerator SpawnWaveRoutine(int budget)
    {
        int remainingBudget = budget;

        while (remainingBudget >= 10)
        {
            EnemyData randomEnemy =
                enemyTypes[Random.Range(0, enemyTypes.Length)];

            if (remainingBudget >= randomEnemy.attackCost)
            {
                SpawnEnemy(randomEnemy);

                remainingBudget -= randomEnemy.attackCost;

                yield return new WaitForSeconds(
                    Random.Range(
                        spawnIntervalMin,
                        spawnIntervalMax
                    )
                );
            }
            else
            {
                break;
            }
        }
    }

    public bool IsWaveComplete()
    {
        return allWavesFinished &&
               GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }

    void SpawnEnemy(EnemyData data)
    {
        GameObject newEnemy = Instantiate(
            enemyPrefab,
            waypoints[0].position,
            Quaternion.identity
        );

        Enemy enemyScript =
            newEnemy.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript.Initialize(data, waypoints);
        }
    }

    IEnumerator ShowWaveText()
    {
        if (waveText == null || waveCanvasGroup == null)
            yield break;

        waveText.gameObject.SetActive(true);

        waveText.text = "WAVE " + currentWave;

        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime;

            waveCanvasGroup.alpha =
                Mathf.Lerp(0f, 1f, time);

            yield return null;
        }

        yield return new WaitForSeconds(3f);

        time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime;

            waveCanvasGroup.alpha =
                Mathf.Lerp(1f, 0f, time);

            yield return null;
        }

        waveCanvasGroup.alpha = 0f;
        waveText.gameObject.SetActive(false);
    }
}
=======
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] waypoints; 

    public EnemyData[] enemyTypes;
    public GameObject enemyPrefab;
    public int currentWaveBudget = 200;
    public float spawnInterval = 1.0f;

    void Start()
    {
        StartWave();
    }

    public void StartWave()
    {
        if (waypoints.Length > 0 && enemyTypes.Length > 0)
        {
            StartCoroutine(SpawnWaveRoutine());
        }
    }

    IEnumerator SpawnWaveRoutine()
    {
        int remainingBudget = currentWaveBudget;
        while (remainingBudget >= 10)
        {
            EnemyData randomEnemy = enemyTypes[Random.Range(0, enemyTypes.Length)];
            if (remainingBudget >= randomEnemy.attackCost)
            {
                SpawnEnemy(randomEnemy);
                remainingBudget -= randomEnemy.attackCost;
                yield return new WaitForSeconds(Random.Range(0.8f, 1.2f));
            }
            else yield return null;
        }
    }

    // GameManager викликає це, щоб дізнатися, чи всі вороги з хвилі відправлені
    public bool IsWaveComplete()
        {
            // Припускаємо, що хвиля закінчилася, коли бюджет витрачено
            return currentWaveBudget <= 10; 
        }

    void SpawnEnemy(EnemyData data)
    {
        GameObject newEnemy = Instantiate(enemyPrefab, waypoints[0].position, Quaternion.identity);
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        if (enemyScript != null) enemyScript.Initialize(data, waypoints);
    }
} 
>>>>>>> 6233c5f4735fd79c7a5d4e067bdbff7ccd940b41
