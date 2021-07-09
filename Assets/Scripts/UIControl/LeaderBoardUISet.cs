using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 排行榜长度设置
/// </summary>
public class LeaderBoardUISet : MonoBehaviour
{
    [SerializeField] private RectTransform infoCardPrefab; //信息卡片预制体
    [SerializeField] private RectTransform imgViewPoint; //显示框，需拖拽
    [SerializeField] private RectTransform contentTransform; //获取content的矩形组件
    [SerializeField] private VerticalLayoutGroup verticalLayoutGroup; //获取排列组件，需拖拽
    private UserData userData; //接收Json数据
    public static float oneGridHeight; //信息框加间隔的距离
    public static float heightScale; //显示和间隔高度的缩放比例
    
    private void Start()
    {
        userData = JsonData.GetItem(); //获取Json数据
        countLeaderBoardHeight(); //计算并设置排行榜滑动框的高度
    }

    //计算并设置排行榜滑动框的高度
    private void countLeaderBoardHeight()
    {
        float cardSizeHeight = infoCardPrefab.rect.height; //每个排行榜信息卡片的高度
        float spacingHeight = verticalLayoutGroup.spacing; //排行榜信息间间隔的高度
        heightScale = imgViewPoint.rect.height / 6 / (cardSizeHeight + spacingHeight); //计算卡片显示和间隔高度的缩放比例
        verticalLayoutGroup.spacing = spacingHeight * heightScale; //设置排行榜卡片间隔
        oneGridHeight = cardSizeHeight * heightScale + verticalLayoutGroup.spacing; //一个信息框加一个间隔的距离
        contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x, oneGridHeight * userData.list.Count); //设置排列框长度
    }
}
