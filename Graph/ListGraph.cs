using System.Diagnostics;

namespace Algorizem.Graph;

/// <summary>
/// List로 구현된 단순 그래프입니다.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ListGraph<T>
{
    /// <summary>
    /// 현재 설정된 간선 목록입니다.
    /// </summary>
    public List<T>[] Lines { get; init; }
    /// <summary>
    /// 정점의 갯수입니다.
    /// </summary>
    public uint Count { get; init; }
    /// <summary>
    /// 그래프를 생성합니다.
    /// </summary>
    /// <param name="count">정점의 갯수</param>
    public ListGraph(uint count)
    {
        this.Count = count;
        this.Lines = new List<T>[count];
        for (int i = 0 ; i < count ; i++)
            this.Lines[i] = new();
    }

    [Conditional("DEBUG")]
    private protected void CheckRange(uint start, uint? end = null)
    {
#if DEBUG
        if (start >= Count || end >= Count)
        {
            throw new IndexOutOfRangeException($"유효한 정점 범위는 0~{Count-1} 입니다. 하지만 들어온 {(end is null ? $"정점이 {start}" : $"간선이 {start} -> {end}")}으로 범위를 초과했습니다.");
        }
#endif
    }
}