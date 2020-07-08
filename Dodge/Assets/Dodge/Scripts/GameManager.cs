using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text m_ScoreUI;
    public Text m_RestartUI;

    public PlayerController m_PlayerController;
    public List<GameObject> m_BulletSpawner;

    public bool m_IsPlaying;
    public float m_Score;
    // Start is called before the first frame update
    private void Start()
    {
        GameStart();
    }
    

    public void GameStart()
    {
        //GameStart();
        m_IsPlaying = true;
        m_Score = 0f;
        m_RestartUI.gameObject.SetActive(false);
        m_PlayerController.gameObject.SetActive(true);

        for (int i = 0; i < m_BulletSpawner.Count; i++)
        {
            m_BulletSpawner[i].gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        m_IsPlaying = false;
        m_RestartUI.gameObject.SetActive(true);
        m_PlayerController.gameObject.SetActive(false);

        for (int i = 0; i < m_BulletSpawner.Count; i++)
        {
            m_BulletSpawner[i].gameObject.SetActive(false);
        }
        
        Bullet[] bullets = FindObjectsOfType<Bullet>();

        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject);
        }

        float topScore = PlayerPrefs.GetFloat("TopScore", 0);

        if(topScore < m_Score)
        {
            topScore = m_Score;
        }
        PlayerPrefs.SetFloat("TopScore", topScore);
        PlayerPrefs.Save();

        m_RestartUI.text = string.Format("게임오버\n최고점 : {0}\n다시 시작하시려면 R버튼을 누르세요", topScore);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_IsPlaying)
        {
            m_Score = m_Score + Time.deltaTime;  
            m_ScoreUI.text = string.Format("Score : {0}", m_Score);
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                GameStart();
            }
        }
    }
}
