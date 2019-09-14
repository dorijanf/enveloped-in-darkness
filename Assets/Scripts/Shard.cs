using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shard : MonoBehaviour
{
    [SerializeField] private float timeBetweenShards = 50f;
    private GameObject collector;
    private TextMeshProUGUI collectorText;
    private RoomTemplates templates;
    private GameObject timer;
    private TextMeshProUGUI timerText;

    private void Start()
    {
        collector = GameObject.FindGameObjectWithTag("winText");
        collectorText = collector.GetComponent<TextMeshProUGUI>();
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        timer = GameObject.FindGameObjectWithTag("timer");
        timerText = timer.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        timeBetweenShards -= Time.deltaTime;

        if (timeBetweenShards < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        int timeInInt = (int)timeBetweenShards;
        timerText.text = timeInInt.ToString();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<PlayerController>())
        {
            collectorText.text = "Good job, you've collected a shard, now hurry and find the rest! I'll keep 'helping' you ofcourse!";
            templates.GetComponent<RoomTemplates>().isCollected = true;
            gameObject.SetActive(false);
        }
    }
}
