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
    [SerializeField] private GridLayoutGroup gridLayoutGroup; //获取排列组件，需拖拽
    private UserData userData; //接收Json数据

    private void Awake()
    {
        float cellSizeHeight = gridLayoutGroup.cellSize.y; //每个排行榜信息显示位置的高度
        float spacingHeight = gridLayoutGroup.spacing.y; //排行榜信息间间隔的高度
        float heightScale = ImageViewPoint.rect.height / 6 / (cellSizeHeight + spacingHeight); //计算卡片显示和间隔高度的缩放比例
        gridLayoutGroup.cellSize = new Vector2(gridLayoutGroup.cellSize.x, cellSizeHeight * heightScale); //设置排行榜信息卡片的高
        gridLayoutGroup.spacing = new Vector2(gridLayoutGroup.spacing.x, spacingHeight * heightScale); //设置排行榜卡片间隔
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
            playerInfo.transform.SetParent(transform, false); //设置滑动框为其父物体
            playerInfo.GetComponent<PlayerInfoLoad>().LoadPlayerInfo(userData.list[i - 1], i); //加载玩家信息
        }
    }
}
