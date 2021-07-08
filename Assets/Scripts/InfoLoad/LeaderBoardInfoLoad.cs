using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 初始时生成并展示玩家信息
/// </summary>
public class LeaderBoardInfoLoad : MonoBehaviour
{
    [SerializeField] private RectTransform imgViewPoint; //显示框，需拖拽
    [SerializeField] private ObjectsPool objectsPool; //获取对象池脚本，需拖拽
    [SerializeField] private RectTransform contentTransform; //获取content的矩形组件
    [SerializeField] private GridLayoutGroup grid; //获取排列组件，需拖拽
    private UserData userData; //接收Json数据
    private int playerInfoNumber; //玩家信息总数
    private float oneGridHeight; //信息框加间隔的距离
    
    private void Start()
    {
        userData = JsonData.GetItem(); //获取Json数据
        countLeaderBoardHeight(); //计算并设置排行榜滑动框的高度
    }

    //计算并设置排行榜滑动框的高度
    private void countLeaderBoardHeight()
    {
        float cellSizeHeight = grid.cellSize.y; //每个排行榜信息显示位置的高度
        float spacingHeight = grid.spacing.y; //排行榜信息间间隔的高度
        float heightScale = imgViewPoint.rect.height / 6 / (cellSizeHeight + spacingHeight); //计算卡片显示和间隔高度的缩放比例
        grid.cellSize = new Vector2(grid.cellSize.x, cellSizeHeight * heightScale); //设置排行榜信息卡片的高
        grid.spacing = new Vector2(grid.spacing.x, spacingHeight * heightScale); //设置排行榜卡片间隔
        oneGridHeight = grid.cellSize.y + grid.spacing.y; //一个信息框加一个间隔的距离
        contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x, oneGridHeight * userData.list.Count); //设置排列框长度
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
            playerInfo.transform.SetParent(contentTransform, false); //设置滑动框为其父物体
            playerInfo.GetComponent<PlayerInfoLoad>().LoadPlayerInfo(userData.list[i - 1], i); //加载玩家信息
        }
    }
}
