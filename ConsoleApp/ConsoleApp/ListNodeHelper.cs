using System.Collections.Generic;

namespace ConsoleApp
{
	public static class ListNodeHelper
	{
		public static IEnumerable<T> Enumerate<T>(this ListNode<T> lst)
		{
			while (lst != null)
			{
				yield return lst.val;
				lst = lst.next;
			}
		}

		public static ListNode<T> Build<T>(params T[] lst)
		{
			ListNode<T> head = null, last = null;
			foreach (var item in lst)
			{
				var node = new ListNode<T>(item);
				if (head == null)
					head = node;
				if (last != null)
					last.next = node;
				last = node;
			}
			return head;
		}

	}

	public class ListNode<T>
    {
        public T val;
        public ListNode<T> next;
        public ListNode(T val, ListNode<T> next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
