using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 初始时生成并展示玩家信息
/// </summary>
public class LeaderBoardInfoLoad : MonoBehaviour
{
    [SerializeField] private RectTransform ImageViewPoint; //显示框，需拖拽
    [SerializeField] private ObjectsPool objectsPool; //获取对象池脚本，需拖拽
    [SerializeField] private GridLayoutGroup gridLayoutGroup; //获取排列组件
    private UserData userData; //接收Json数据

    private void Awake()
    {
        float cardHeight = (ImageViewPoint.rect.height - gridLayoutGroup.spacing.y * 6) / 6; //计算每个卡片合适的高
        gridLayoutGroup.cellSize = new Vector2(gridLayoutGroup.cellSize.x, cardHeight); //设置每个卡片排列显示的位置大小
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
            GameObject playerInfo = objectsPool.GetInstance(); //获取对象
            playerInfo.transform.SetParent(transform, false); //设置起父物体
            playerInfo.GetComponent<PlayerInfoLoad>().LoadPlayerInfo(userData.list[i - 1], i); //加载玩家信息
        }
    }
}
