using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timeDuration = 3f * 60f;

    [SerializeField]
    private bool countDown = false;

    private float timer;

    [SerializeField]
    private TextMeshProUGUI firstMinute;
    [SerializeField]
    private TextMeshProUGUI secondMinute;
    [SerializeField]
    private TextMeshProUGUI separator;
    [SerializeField]
    private TextMeshProUGUI firstSecond;
    [SerializeField]
    private TextMeshProUGUI secondSecond;

    void Start(){
        ResetTimer();
    }

    void Update(){
        if (countDown && timer > 0){
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
        } else if(!countDown && timer < timeDuration){
            timer += Time.deltaTime;
            UpdateTimerDisplay(timer);
        } else {
            Flash();
        }
    }

    private void ResetTimer(){
        if (countDown){
            timer = timeDuration;
        } else {
            timer = 0;
        }
        SetTextDisplay(true);

    }

    private void UpdateTimerDisplay(float time){
        if(time < 0){
            time = 0;
        }
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }

    private void Flash(){
        // if (countDown && timer != 0){
        //     timer = 0;
        //     UpdateTimerDisplay(timer);
        // }
        // if (!countDown && timer != timeDuration){
        //     timer = timeDuration;
        //     UpdateTimerDisplay(timer);
        // }
    }

    private void SetTextDisplay(bool enabled){
        firstMinute.enabled = enabled;
        secondMinute.enabled = enabled;
        separator.enabled = enabled;
        firstSecond.enabled = enabled;
        secondSecond.enabled = enabled;
    }
}
