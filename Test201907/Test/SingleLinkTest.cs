using System;
using System.Collections.Generic;

namespace Test201907.Test
{
        public class Node<T>
        {
            private T data; // 节点数据
            public Node<T> next; // 指向下个节点的指针

            public Node(T t)
            {
                data = t;
                next = null;
            }

            public Node(T t, Node<T> next)
            {
                this.data = t;
                this.next = next;
            }

            public Node () 
            { 
                throw new Exception("初始化错误");
            }

            public T getData() => data;

            private void setData(T t)
            {
                this.data = t;
            }
        }

    public class SingleLinkTest<T>
    {
        private Node<T> head; // 头节点
        private Node<T> tail; // 尾节点
        private int size; // 链表长度

        public SingleLinkTest()
        {
            head = null;
            tail = null;
            size = 0;
        }

        // 获取长度
        public int GetSize() => size;

        // 是否包含数据
        public bool IsEmpty() => size == 0;

        // 清空链表
        public void Clear() 
        {
            head = null;
            tail = null;
            size = 0;
        }

        // 插入: 1.头插入, 尾插入, 中间插入
        public void AddAtHead(T t)
        {
            var newNode = new Node<T>(t);
            newNode.next = head;
            head = newNode;
            if (tail == null)
                tail = newNode;
            size++;
        }
        
        public void AddAtTail(T t)
        {
            var newTail = new Node<T>(t);
            if (head == null)
                tail = head = newTail;
            else
            {
                tail.next = newTail;
                tail = newTail;
            }
            size++;
        }

        public void AddAtMidByIndex(T t, int index)
        {
            if (index < 0 | index > size)
                throw new IndexOutOfRangeException("索引越界");
            // 处理上一个
            // 处理下一个
            // 连接上一个以及下一个            
            if (index == 0)
                AddAtHead(t);
            else if (index > 0 && index < size)
            {
                var newNode = new Node<T>(t);

                var perNode = GetNodeByIndex(index - 1);
                var nextNode = GetNodeByIndex(index);

                perNode.next = newNode;
                newNode.next = nextNode;

            }
            else 
                AddAtTail(t);
        }

        public Node<T> GetNodeByIndex(int index)
        {
            if (index < 0 | index > size - 1)
                throw new IndexOutOfRangeException("索引越界");
            
            var node = head;
            for (int i = 0; i <= index; i++, node = node.next)
            {
                if (i == index)
                    return node;
            }

            return null;
        }
    }

    public static class SingleLinkTestStart
    {
        public static void TestStart()
        {
            
            const int LTLENGTH = 3;

            var newSLink = new SingleLinkTest<int>();
            for (int i = 0; i < LTLENGTH; i++)
            {
                newSLink.AddAtTail(i);
            }

            newSLink.AddAtMidByIndex(5, 0);
            newSLink.AddAtMidByIndex(6, 1);
            newSLink.AddAtMidByIndex(99, newSLink.GetSize());
            // 5, 6, 0, 1, 2

            for (int i = 0; i < newSLink.GetSize(); i++)
            {
                System.Console.WriteLine(newSLink.GetNodeByIndex(i).getData());
            }
        }
    }
}