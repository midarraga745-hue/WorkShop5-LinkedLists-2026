namespace Shared;

public interface ILinkedList<T>
{
    void Add(T item);

    void ShowForward();

    void ShowBackward();

    void SortDescending();

    void ShowMode();

    void ShowChart();

    bool Exists(T item);

    void DeleteOne(T item);

    void DeleteAll(T item);
}