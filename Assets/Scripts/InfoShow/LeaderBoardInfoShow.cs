using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 排行榜信息展示
/// </summary>
public class LeaderBoardInfoShow : MonoBehaviour
{
    [SerializeField] private InfoCardObjectsPool infoCardObjectsPool; //获取对象池脚本，需拖拽
    [SerializeField] private RectTransform contentTransform; //获取content的矩形组件
    private UserData userData; //接收Json数据

    private void Start()
    {
        userData = JsonData.GetItem(); //获取用户的Json数据
    }

    //展示玩家信息
    public void ShowInfo()
    {
        for (int i = 1; i <= 7; ++i)
        {
            GameObject playerInfo = infoCardObjectsPool.GetInstance(); //获取对象
            playerInfo.transform.SetParent(contentTransform, false); //设置滑动框为其父物体
            playerInfo.transform.localScale = new Vector3(1, LeaderBoardUISet.heightScale, 1);
            playerInfo.GetComponent<PlayerInfoLoad>().LoadPlayerInfo(userData.list[i - 1], i); //加载玩家信息
        }
    }
}
