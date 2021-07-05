using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 玩家信息显示框复用
/// </summary>
public class ImageScrollShowControl : MonoBehaviour
{
    public LinkedList<GameObject> loopItems = new LinkedList<GameObject>(); //存储所有卡片对象
    public Image viewPointImage; //范围显示框，需拖拽
    private UserData userData; //接收Json数据
    private Vector3[] viewCorners = new Vector3[4]; //存储显示框的四个点坐标
    private Vector3[] rectCorners = new Vector3[4]; //卡片信息的四个点坐标
    private float hight; //信息框加间隔的距离
    private int playerInfoNumber; //玩家信息总数
    private GridLayoutGroup grid; //排序组件
    private RectTransform contentRect;

    private void Start()
    {
        userData = JsonData.GetItem(); //获取Json数据
        playerInfoNumber = userData.list.Count; //获取玩家信息总数
        viewPointImage.GetComponent<RectTransform>().GetWorldCorners(viewCorners); //获取显示框四个角的坐标
        grid = GetComponent<GridLayoutGroup>(); //获取组件
        hight = grid.cellSize.y + grid.spacing.y; //一个信息框加一个间隔的距离
        contentRect = GetComponent<RectTransform>();
        contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, hight * playerInfoNumber); //设置排列框长度
    }

    void Update()
    {
        if (transform.childCount != 0 && loopItems.Count == 0)
        {
            for (int i = 0; i < transform.childCount; i++) //初始时读取排行榜显示卡片物体
            {
                loopItems.AddLast(transform.GetChild(i).gameObject);
            }
        }

        if (transform.childCount != 0 && transform.childCount == loopItems.Count) //保证链表里和显示框里都有全部物体
        {
            IfChange(); //判断是否有卡片离开
        }
    }

    //判断是否有卡片在显示框外
    private void IfChange()
    {
        GameObject first = loopItems.First.Value; //获取第一条信息
        GameObject last = loopItems.Last.Value; //获取最后一条信息
        
        if (first != null)
        {
            first.GetComponent<RectTransform>().GetWorldCorners(rectCorners); //获取第一个信息框的四个角坐标

            if (rectCorners[0].y > viewCorners[1].y) //判断第一个是否离开
            {
                int index = int.Parse(last.transform.Find("SortNumberText").GetComponent<Text>().text); //获取最后一个的序号

                if (index < playerInfoNumber) //序号小于信息总个数
                {
                    first.GetComponent<RectTransform>().localPosition =
                        last.GetComponent<RectTransform>().localPosition - new Vector3(0, hight, 0); //设置信息位置
                    first.GetComponent<PlayerInfoLoad>().LoadPlayerInfo(userData.list[index], index + 1); //更新显示信息
                    loopItems.AddLast(first);
                    first.transform.Find("Toast").gameObject.SetActive(false); //防止信息卡片的Toast还在显示就被复用
                    loopItems.RemoveFirst();
                }
            }

            first = loopItems.First.Value; //重新获取第一条信息
            last = loopItems.Last.Value; //重新获取最后一条信息
            last.GetComponent<RectTransform>().GetWorldCorners(rectCorners); //获取最后一个信息框的四个角坐标

            if (rectCorners[1].y < viewCorners[0].y) //判断最后一个是否离开
            {
                int index = int.Parse(first.transform.Find("SortNumberText").GetComponent<Text>().text); //获取第一个的序号

                if (index > 1 && index < playerInfoNumber)
                {
                    last.GetComponent<RectTransform>().localPosition =
                        first.GetComponent<RectTransform>().localPosition + new Vector3(0, hight, 0); //设置信息位置
                    last.GetComponent<PlayerInfoLoad>().LoadPlayerInfo(userData.list[index - 2], index - 1); //更新显示信息
                    loopItems.AddFirst(last);
                    last.transform.Find("Toast").gameObject.SetActive(false); //防止信息卡片的Toast还在显示就被复用
                    loopItems.RemoveLast();
                }
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++) //如果链表为空则重新读取
            {
                loopItems.AddLast(transform.GetChild(i).gameObject);
            }
        }
    }
}
