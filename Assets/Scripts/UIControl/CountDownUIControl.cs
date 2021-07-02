using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

/// <summary>
/// 倒计时显示控制
/// </summary>
public class CountDownUIControl : MonoBehaviour
{
    public Text timeText; //时间显示文本
    private int countDown = 835503; //倒计时时长
    private float time; //中间时间变量
    void Start()
    { 
        time = Time.time;
    }
    
    void Update()
    {
        if (Time.time > time + 1) //计时器
        {
            if (countDown > 0)
            {
                countDown--;
            }

            int second = countDown % 60; //秒数
            int temp = countDown / 60; //中间记录变量
            int minute = temp % 60; //分数
            temp /= 60; 
            int hour = temp % 24; //小时
            int day = temp / 24; //天数
            
            timeText.text = SetTimeFormat(day) + "d " + SetTimeFormat(hour) + "h " 
                            + SetTimeFormat(minute) + "m " + SetTimeFormat(second) + "s";
            time = Time.time;
        }
    }

    //设置时间格式
    private string SetTimeFormat(int time)
    {
        string timeStr = "";
        
        if (time < 10)
        {
            timeStr += "0" + time;
        }
        else
        {
            timeStr += time;
        }

        return timeStr;
    }
}
