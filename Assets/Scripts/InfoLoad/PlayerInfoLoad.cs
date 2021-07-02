using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 加载的玩家信息
/// </summary>
public class PlayerInfoLoad : MonoBehaviour
{
    public Image sortImage; //玩家名次图片
    public Text sortText; //玩家名次文本
    public Text nameText; //玩家名字
    public Image rankImage; //玩家段位
    public Text trophyNumberText; //玩家奖杯数量
    public Text idText; //玩家ID
    private string pathSortImage = "Sprites/Rank/rank_"; //序号图片路径
    private string pathRankImage = "Sprites/Grade/arenaBadge_"; //段位图片路径
    
    //加载玩家信息
    public void LoadPlayerInfo(UserInfo info, int sortNumber)
    {
        int rank = info.trophy / 1000 + 1; //计算玩家段位
        rankImage.sprite = Resources.Load<Sprite>(pathRankImage + rank); //加载段位图片
        idText.text = info.uid; //玩家ID设置
        nameText.text = info.nickName; //设置昵称
        trophyNumberText.text = info.trophy.ToString(); //设置奖杯数量
        
        if (sortNumber <= 3)
        {
            sortImage.gameObject.SetActive(true); //隐藏名次图片
            sortImage.sprite = Resources.Load<Sprite>(pathSortImage + sortNumber); //加载名次图片
            sortText.text = sortNumber.ToString(); //加载名次文本
        }
        else
        {
            sortImage.gameObject.SetActive(false); //隐藏名次图片
            sortText.text = sortNumber.ToString(); //加载名次文本
        }
    }
}
