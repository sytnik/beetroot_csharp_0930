using System.Collections;

public class CustomList<T> : IEnumerable
{
    private const int DefSize = 4;
    private T[] _array;
    private int elementCounter;
    public int Count => elementCounter;

    public CustomList()
    {
        _array = new T[DefSize];
    }

    public void AddElement(T element)
    {
        Resize();
        _array[elementCounter++] = element;
    }

    public void AddBatchElements(IEnumerable<T> elements)
        => AddElementsInner(elements);

    public void AddSomeElements(params T[] arr)
        => AddElementsInner(arr);

    private void AddElementsInner(IEnumerable<T> elements)
    {
        foreach (var elem in elements) AddElement(elem);
    }

    public void RemoveElement(T element)
    {
        var countRemovals = _array.Count(e => e.Equals(element));
        _array = _array.Where(e => !e.Equals(element)).ToArray();
        elementCounter -= countRemovals;
    }

    public void RemoveByIndex(int index)
    {
        T[] arrayForCopy = new T[_array.Length];
        if (elementCounter == 1)
        {
            _array = new T[DefSize];
        }
        else if (index == 0 && elementCounter > 1)
        {
            Array.Copy(_array, 1, arrayForCopy,
                0, elementCounter - 1);
            _array = arrayForCopy;
        }
        else if (index > 0 && index < elementCounter)
        {
            Array.Copy(_array, 0, arrayForCopy,
                0, index + 1);
            Array.Copy(_array, index + 1, arrayForCopy,
                index, elementCounter - index);
            _array = arrayForCopy;
        }
        elementCounter--;
    }


    private void Resize()
    {
        if (_array.Length <= elementCounter)
        {
            Array.Resize(ref _array, _array.Length + DefSize);
        }
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}