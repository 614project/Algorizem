namespace Algorizem.Graph.ShortestPath;

/// <summary>
/// 데이크스트라(다익스트라) 알고리즘입니다.
/// </summary>
public class Dijkstra : ListGraph<(uint point,ulong distance)>
{
    /// <summary>
    /// 데이크스트라를 사용할수 있는 그래프를 생성합니다.
    /// </summary>
    /// <param name="count">정점의 갯수</param>
    public Dijkstra(uint count) : base(count) { }
    /// <summary>
    /// 단방향 간선을 추가합니다.
    /// </summary>
    /// <param name="starting">시작점</param>
    /// <param name="ending">도착점</param>
    /// <param name="distance">거리</param>
    public virtual void AddOneWay(uint starting , uint ending , ulong distance)
    {
        CheckRange(starting , ending);
        this.Lines[starting].Add((ending, distance));
    }
    /// <summary>
    /// 동일한 거리의 양방향 간선을 추가합니다.
    /// </summary>
    /// <param name="starting">시작점</param>
    /// <param name="ending">도착점</param>
    /// <param name="distance">거리</param>
    public virtual void AddTwoWay(uint starting , uint ending , ulong distance)
    {
        CheckRange(starting , ending);
        this.AddOneWay(starting , ending , distance);
        this.AddOneWay(ending , starting , distance);
    }
    /// <summary>
    /// 데이크스트라를 실행합니다.
    /// </summary>
    /// <param name="starting">시작점</param>
    /// <param name="inf">초기화에 사용될 도달 불가능한 거리</param>
    /// <returns>시작점으로부터 각 정점별 거리</returns>
    public virtual ulong[] Run(uint starting, ulong inf = ulong.MaxValue)
    {
        CheckRange(starting);
        ulong[] TotalDistance = new ulong[Count];
        Array.Fill(TotalDistance , inf);
        TotalDistance[starting] = 0;

        PriorityQueue<uint , ulong> queue = new();
        queue.Enqueue(starting , 0);
        while (queue.TryDequeue(out uint me, out ulong my_dist))
        {
            if (TotalDistance[me] < my_dist)
                continue;

            foreach (var line in Lines[me])
            {
                ulong next_dist = TotalDistance[me] + line.distance;
                if (TotalDistance[line.point] > next_dist)
                {
                    TotalDistance[line.point] = next_dist;
                    queue.Enqueue(line.point , next_dist);
                }
            }
        }

        return TotalDistance;
    }
}
