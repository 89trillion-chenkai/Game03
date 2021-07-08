using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 倒计时显示控制
/// </summary>
public class CountDownUIControl : MonoBehaviour
{
    [SerializeField] private Text timeText; //时间显示文本，需拖拽
    private int countDown; //存储倒计时时长

    void Start()
    {
        countDown = int.Parse(JsonData.data.countDown); //获取Json数据里的倒计时数据
    }

    //倒计时协程
    IEnumerator CountDownTime()
    {
        while (countDown != 0)
        {
            timeText.text = CalculatingTime(countDown); //转换时间信息格式并显示
            yield return new WaitForSeconds(1);
            --countDown;
        }
    }

    //转换时间信息为日、小时、分钟、秒
    private string CalculatingTime(int time)
    {
        int second = time % 60; //秒数
        int minute = time / 60 % 60; //分数
        int hour = time / 3600 % 24; //小时
        int day = time / 86400; //天数
        string textStr = SetTimeFormat(day) + "d " + SetTimeFormat(hour) + "h " + SetTimeFormat(minute) + "m " +
                         SetTimeFormat(second) + "s";

        return textStr;
    }

    //设置时间格式，如果位数不足两位则在十位补零
    private string SetTimeFormat(int time)
    {
        string timeStr = "";
        
        if (time < 10) //不足两位则补零
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
