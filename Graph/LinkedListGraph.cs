namespace Algorizem.Graph;

/// <summary>
/// LinkedList로 구현된 단순 그래프입니다.
/// </summary>
/// <typeparam name="T">저장할 정점 정보</typeparam>
[Obsolete("특별한 이유가 없다면 ListGraph를 사용하는것이 성능상 권장됩니다.")]
public abstract class LinkedListGraph<T>
{
    /// <summary>
    /// 현재 설정된 간선 목록입니다.
    /// </summary>
    public LinkedList<T>[] Lines { get; init; }
    /// <summary>
    /// 정점의 갯수입니다.
    /// </summary>
    public uint Count { get; init; }
    /// <summary>
    /// 그래프를 생성합니다.
    /// </summary>
    /// <param name="count">정점의 갯수</param>
    public LinkedListGraph(in uint count)
    {
        this.Count = count;
        this.Lines = new LinkedList<T>[count];
        for (int i = 0 ; i < count ; i++)
            this.Lines[i] = new();
    }
}