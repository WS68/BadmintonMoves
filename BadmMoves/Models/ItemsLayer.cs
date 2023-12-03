using System.Collections;
using System.Diagnostics;

namespace BadmMoves.Models;

internal class ItemsLayer: IEnumerable<ModelItem>
{
    private readonly LinkedList<ModelItem> _owner;
    private readonly LinkedListNode<ModelItem> _start;
    private readonly LinkedListNode<ModelItem> _end;

    public ItemsLayer(LinkedList<ModelItem> owner, LinkedListNode<ModelItem> start, LinkedListNode<ModelItem> end)
    {
        Debug.Assert( owner != null );
        Debug.Assert(start != null);
        Debug.Assert(end != null && start.Next == end );

        _owner = owner;
        _start = start;
        _end = end;
    }

    public void Append(ModelItem item)
    {
        Debug.Assert( item != null );
        _owner.AddBefore(_end!, item);
    }

    public void Clear()
    {
        var current = _start.Next;
        while (current != _end)
        {
            var c = current;
            current = current!.Next;
            _owner.Remove(c!);
        }
    }

    public IEnumerator<ModelItem> GetEnumerator()
    {
        var current = _start.Next;
        while (current != _end)
        {
            var item = current!.Value;
            current = current.Next;
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void RemoveWhere<T>( Func< T, bool > predicate ) where T: ModelItem
    {
        Debug.Assert( predicate != null );

        var current = _start.Next;
        while (current != _end)
        {
            var c = current;
            current = current!.Next;

            if (c!.Value is T t)
            {
                if (predicate(t))
                {
                    _owner.Remove(c);
                }
            }
        }
    }
}