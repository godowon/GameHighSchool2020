using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;
    public Animator m_Animator;

    public float m_SapwnIntervalMin = 2f;
    public float m_SapwnIntervalMax = 6f;

    public int m_MinSpawnCount = 1;
    public int m_MaxSpawnCount = 4;
    public bool isDead;

    public float m_SpawnCooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        m_SpawnCooldown = Random.Range(m_SapwnIntervalMin, m_SapwnIntervalMax);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_SpawnCooldown <= 0)
        {
            int spawnCout = Random.Range(m_MinSpawnCount, m_MaxSpawnCount);

            List<int> spawnNums = new List<int>();
            for (int i = 0; i < spawnCout; i++)
            {
                int spawnNum;
                do
                {
                    spawnNum = Random.Range(0, m_SpawnPoints.Length);
                }
                while (spawnNums.Contains(spawnNum));

                spawnNums.Add(spawnNum);
            }
            foreach (var spawnNum in spawnNums)
            {
                var eulerAngle = m_SpawnPoints[spawnNum].eulerAngles += Vector3.up * Random.Range(-15f, 15f);

                GameObject bullet = GameObject.Instantiate(m_EnemyPrefab, m_SpawnPoints[spawnNum].position, Quaternion.Euler(eulerAngle));
            }
            m_SpawnCooldown = Random.Range(m_SapwnIntervalMin, m_SapwnIntervalMax);
        }
        m_SpawnCooldown -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet")
        {
            m_Animator.SetBool("Die", true);

            GameManager.instance.AddScore();
            isDead = true;
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
