using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class SpawnManagerLevel1 : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The different types of enemies that should be spawned and their corresponding spawn information.")]
    private EnemySpawnInfo[] m_EnemyTypes;
    #endregion

    #region Non-Editor Variables
    private float[] m_EnemySpawnTimers;
    private bool spawnStart;
    #endregion

    #region First Time Initialization and Set Up
    private void Awake()
    {
        // Initialize the spawn timers using the FirstSpawnTime variable
        m_EnemySpawnTimers = new float[m_EnemyTypes.Length];
        int i = 0;
        foreach (EnemySpawnInfo enemyInstance in m_EnemyTypes)
        {
            m_EnemySpawnTimers[i] = enemyInstance.FirstSpawnTime;
            i += 1;
        }

        spawnStart = false;

    }
    #endregion

    #region Main Updates
    private void Update()
    {
        int i = 0;
        foreach (EnemySpawnInfo enemyInstance in m_EnemyTypes)
        {
            if (enemyInstance.SpawnRate > 0)
            {
                if (!spawnStart && m_EnemySpawnTimers[i] >= enemyInstance.FirstSpawnTime)
                {
                    spawnStart = true;
                    Instantiate(enemyInstance.EnemyPrefab);
                    m_EnemySpawnTimers[i] = (60f / enemyInstance.SpawnRate);
                }

                if (m_EnemySpawnTimers[i] <= 0)
                {
                    Instantiate(enemyInstance.EnemyPrefab);
                    m_EnemySpawnTimers[i] = (60f / enemyInstance.SpawnRate);
                }
                else
                {
                    m_EnemySpawnTimers[i] -= Time.deltaTime;
                }
            }
            i += 1;
        }
    }
    #endregion
}

[System.Serializable]
public struct EnemySpawnInfo
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The enemy prefab to spawn. This is what will be instantiated each time.")]
    private GameObject m_EnemyPrefab;

    [SerializeField]
    [Tooltip("The time we should wait before the first enemy is spawned.")]
    private float m_FirstSpawnTime;

    [SerializeField]
    [Range(0, 100)]
    [Tooltip("How many enemies should spawn per minute.")]
    private float m_SpawnRate;
    #endregion

    #region Accessors and Mutators
    public GameObject EnemyPrefab
    {
        get { return m_EnemyPrefab; }
    }

    public float FirstSpawnTime
    {
        get { return m_FirstSpawnTime; }
    }

    public float SpawnRate
    {
        get { return m_SpawnRate; }
    }
    #endregion
}