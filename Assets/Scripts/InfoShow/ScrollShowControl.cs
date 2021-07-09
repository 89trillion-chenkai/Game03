using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 排行榜信息卡片滑动控制
/// </summary>
public class ScrollShowControl : MonoBehaviour
{
    public LinkedList<RectTransform> loopItems = new LinkedList<RectTransform>(); //存储所有排行榜信息卡片物体
    [SerializeField] private RectTransform imgViewPoint; //范围显示框，需拖拽
    [SerializeField] private VerticalLayoutGroup verticalLayoutGroup; //排序组件
    [SerializeField] private RectTransform contentRect; //滑动框的矩形组件属性
    private Vector3[] viewCorners = new Vector3[4]; //存储显示框的四个点坐标
    private Vector3[] rectCorners = new Vector3[4]; //卡片信息的四个点坐标
    private UserData userData; //接收Json数据
    private int playerInfoNumber; //玩家信息总数
    private int firstSortNumber; //记录当前排行榜里显示的第一位的序号
    private int lastSortNumber; //记录当前排行榜里显示的最后一位的序号

    private void Start()
    {
        userData = JsonData.GetItem(); //获取Json数据
        playerInfoNumber = userData.list.Count; //获取玩家信息总数
        imgViewPoint.GetWorldCorners(viewCorners); //获取显示框四个角的坐标
    }

    void Update()
    {
        if (contentRect.childCount != 0 && loopItems.Count == 0)
        {
            for (int i = 0; i < contentRect.childCount; i++) //读取排行榜显示的卡片物体
            {
                loopItems.AddLast(contentRect.GetChild(i).GetComponent<RectTransform>());
                firstSortNumber = 1;
                lastSortNumber = 7;
            }
        }

        if (contentRect.childCount != 0 && contentRect.childCount == loopItems.Count) //保证链表里和显示框里都有全部卡片物体
        {
            IfChange(); //判断是否有卡片被滑出显示框
        }
    }

    //判断是否有卡片在显示框外
    private void IfChange()
    {
        RectTransform first = loopItems.First.Value; //获取第一条信息
        RectTransform last = loopItems.Last.Value; //获取最后一条信息

        first.GetWorldCorners(rectCorners); //获取第一个信息框的四个角坐标

        if (rectCorners[0].y > viewCorners[1].y + verticalLayoutGroup.spacing) //判断第一个是否离开
        {
            if (lastSortNumber < playerInfoNumber) //序号小于信息总个数
            {
                ++firstSortNumber;
                ++lastSortNumber;
                first.localPosition = last.localPosition - new Vector3(0, LeaderBoardUISet.oneGridHeight, 0); //设置信息位置
                first.GetComponent<PlayerInfoLoad>().LoadPlayerInfo(userData.list[lastSortNumber-1], lastSortNumber); //更新显示信息
                loopItems.AddLast(first);
                loopItems.RemoveFirst();
            }
        }
        
        last.GetWorldCorners(rectCorners); //获取最后一个信息框的四个角坐标

        if (rectCorners[1].y < viewCorners[0].y) //判断最后一个是否离开
        {
            if (firstSortNumber > 1)
            {
                --firstSortNumber;
                --lastSortNumber;
                last.localPosition = first.localPosition + new Vector3(0, LeaderBoardUISet.oneGridHeight, 0); //设置信息位置
                last.GetComponent<PlayerInfoLoad>().LoadPlayerInfo(userData.list[firstSortNumber - 1], firstSortNumber); //更新显示信息
                loopItems.AddFirst(last);
                loopItems.RemoveLast();
            }
        }
    }
}
