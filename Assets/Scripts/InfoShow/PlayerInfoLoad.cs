using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 加载玩家信息到卡片上
/// </summary>
public class PlayerInfoLoad : MonoBehaviour
{
    [SerializeField] private Image imgSortImage; //玩家名次图片
    [SerializeField] private Text txtSortNumber; //玩家名次文本
    [SerializeField] private Text txtUserName; //玩家名字
    [SerializeField] private Image imgUserRank; //玩家段位
    [SerializeField] private Text txtTrophyNumber; //玩家奖杯数量
    [SerializeField] private Text txtUserId; //玩家ID
    private string pathSortImage = "Sprites/Rank/rank_"; //序号图片路径
    private string pathRankImage = "Sprites/Grade/arenaBadge_"; //段位图片路径
    
    //加载玩家信息
    public void LoadPlayerInfo(UserInfo info, int sortNumber)
    {
        int rank = info.trophy / 1000 + 1; //计算玩家段位
        imgUserRank.sprite = Resources.Load<Sprite>(pathRankImage + rank); //加载段位图片
        txtUserId.text = info.uid; //玩家ID设置
        txtUserName.text = info.nickName; //设置昵称
        txtTrophyNumber.text = info.trophy.ToString(); //设置奖杯数量
        
        if (sortNumber <= 3) //前三名需要显示名次图片
        {
            imgSortImage.gameObject.SetActive(true);
            imgSortImage.sprite = Resources.Load<Sprite>(pathSortImage + sortNumber); //加载名次图片
            txtSortNumber.text = sortNumber.ToString(); //加载名次文本
        }
        else
        {
            imgSortImage.gameObject.SetActive(false); //隐藏名次图片
            txtSortNumber.text = sortNumber.ToString(); //加载名次文本
        }
    }
}
