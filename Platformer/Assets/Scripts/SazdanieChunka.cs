using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SazdanieChunka : MonoBehaviour
{
    public Transform Player;
    public Cunk[] ChunkPrefabs;
    public Cunk FirstChang;
    public float score;
    public Text PointsText;
    public Text HiPointsText;

    private List<Cunk> SpawnedChanks = new List<Cunk>();


    private void Start()
    {
        SpawnedChanks.Add(FirstChang);
        float hiscore = PlayerPrefs.GetFloat("hiscore");
        HiPointsText.text = "HI " + hiscore;

    }

    private void Update()
    {
        PointsText.text = "score: " + score;
        float hiscore = PlayerPrefs.GetFloat("hiscore");
        if (score > hiscore)
        {
            PlayerPrefs.SetFloat("hiscore", score);
        }

        if (Player.position.x > SpawnedChanks[SpawnedChanks.Count - 1].End.position.x - 9)
        {
            SpawnChank();
        }
    }

    private void SpawnChank()
    {
        Cunk newChank = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        newChank.transform.position = SpawnedChanks[SpawnedChanks.Count - 1].End.position - newChank.Begin.localPosition;
        SpawnedChanks.Add(newChank);
        score++;

        if (SpawnedChanks.Count >= 4)
        {
            Destroy(SpawnedChanks[0].gameObject);
            SpawnedChanks.RemoveAt(0);
        }
    }
}
