using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 初始时生成并展示玩家信息
/// </summary>
public class LeaderboardInfoLoad : MonoBehaviour
{
    public GameObject ImageViewPoint; //显示框
    public GameObject gameManager; //游戏管理物体，用于获取对象池脚本
    private UserData userData; //接收Json数据
    private GridLayoutGroup gridLayoutGroup; //排列组件
    private float cardY; //计算后的宽度

    private void Awake()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        cardY = (ImageViewPoint.GetComponent<RectTransform>().rect.height 
                 - gridLayoutGroup.spacing.y * 6) / 6; //计算每个卡片大小
        gridLayoutGroup.cellSize = new Vector2(700, cardY); //设置每个卡片位置大小
    }

    //展示玩家信息
    public void ShowInfo()
    {
        if (userData == null)
        {
            userData = JsonData.GetItem(); //获取Json数据
        }
        
        for (int i = 1; i <= 7; ++i)
        {
            GameObject playerInfo = gameManager.GetComponent<ObjectsPool>().GetInstance(); //获取对象
            playerInfo.transform.SetParent(transform, false);
            playerInfo.GetComponent<PlayerInfoLoad>().LoadPlayerInfo(userData.list[i - 1], i); //加载玩家信息
        }
    }
}
