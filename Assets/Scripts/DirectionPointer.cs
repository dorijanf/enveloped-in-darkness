using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using TMPro;

public class DirectionPointer : MonoBehaviour
{
    [SerializeField] private float waitTime = 5f;
    private GameObject shard;
    private GameObject fakeShard;
    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;
    private GameObject narrator;
    private TextMeshProUGUI narratorText;

    void Start()
    {
        pointerRectTransform = transform.GetChild(0).GetComponent<RectTransform>();
        narrator = GameObject.FindGameObjectWithTag("textBox");
        narratorText  = narrator.GetComponent<TextMeshProUGUI>();
        narratorText.text = "Hmmmm.. Now where are those soul shards hidden..";
    }

    void Update()
    {
        if(waitTime <= 2 && waitTime > 0)
        {
            narratorText.text = "Hmmm I think, I know..";
        }

        if (waitTime <= -2.0f)
        {
            StartCoroutine("FindShard");
            Vector3 toPosition = targetPosition;
            Vector3 fromPosition = Camera.main.transform.position;
            fromPosition.z = 0f;
            Vector3 dir = (toPosition - fromPosition).normalized;
            float angle = UtilsClass.GetAngleFromVectorFloat(dir);
            if(angle > 337.5 && angle < 360 || angle > 0 && angle < 22.5)
            {
                narratorText.text = "My senses tell me that the location of the shard is East.";
            }
            else if(angle > 22.5 && angle < 67.5)
            {
                narratorText.text = "I think you should probably move North East";
            }
            else if(angle > 67.5 && angle < 112.5)
            {
                narratorText.text = "I reckon that the shard is somewhere upwards.. so you should probably move North.";
            }
            else if(angle > 112.5 && angle <157.5)
            {
                narratorText.text = "Hmmm.. It seems that this time, the shard is North West.";
            }
            else if(angle > 157.5 && angle < 202.5)
            {
                narratorText.text = "The soul shard you're so desperately seeking might be somewhere West";
            }
            else if(angle > 202.5 && angle < 247.5)
            {
                narratorText.text = "Ohhhh! The Shard is South West I'm sure of it!";
            }
            else if (angle > 247.5 && angle < 292.5)
            {
                narratorText.text = "Ohhhh! The Shard is South, I can almost feel it, hurry and check it out!";
            }
            else if(angle > 292.5 && angle < 337.5)
            {
                narratorText.text = "I am sure that the shard is now South East... faster, poor soul!";
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    IEnumerator FindShard()
    {
        yield return new WaitForSeconds(1.0f);
        shard = GameObject.FindGameObjectWithTag("shard");
        if (!shard)
        {
            fakeShard = GameObject.FindGameObjectWithTag("fakeShard");
            targetPosition = fakeShard.GetComponent<Transform>().position;
        }
        else
        {
            targetPosition = shard.GetComponent<Transform>().position;
        }
    }
}
