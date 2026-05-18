public class List<T>
{
    private T[] _items = new T[0];

// properties
    public T GetItemAt(int index) => _items[index];
    public void SetItemAt(int index, T value) => _items[index] = value;

    public void Add(T newValue)
    {
        T[] updated = new T[_items.Length + 1];

        for (int index = 0; index < _items.Length; index++)
            updated[index] = _items[index];
        
        updated[^1] = newValue;

        _items = updated;
    }
}