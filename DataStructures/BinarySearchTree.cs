using System;
using System.Collections.Generic;

namespace dataStructuresCsharp
{
    public class BinarySearchTree
    {
        internal class Node
        {
            internal int value;
            internal Node left;
            internal Node right;

            public Node(int value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
            }

            public Node(int value, Node left, Node right)
            {
                this.value = value;
                this.left = left;
                this.right = right;
            }
        }


        private Node _root;

        public BinarySearchTree()
        {
            _root = null;
        }

        public void Insert(int value)
        {
            //Non recursive
            //InternalInsert(value);
            _root = InternalRecursiveInsert(value, _root);
        }

        private Node InternalRecursiveInsert(int value, Node currentNode)
        {
            if (currentNode == null)
            {
                return new Node(value);
            }

            if (currentNode.value < value)
            {
                currentNode.right = InternalRecursiveInsert(value, currentNode.right);
            }
            else if (value < currentNode.value)
            {
                currentNode.left = InternalRecursiveInsert(value, currentNode.left);
            }
            else
            {
                return currentNode;
            }

            return currentNode;
        }

        private void InternalInsert(int value)
        {
            var newNode = new Node(value);
            if (_root == null)
            {
                _root = newNode;
            }
            else
            {
                var tempNode = _root;
                while (tempNode != null)
                {
                    if (tempNode.value < value)
                    {
                        if (tempNode.right != null)
                        {
                            tempNode = tempNode.right;
                        }
                        else
                        {
                            tempNode.right = newNode;
                            break;
                        }
                    }
                    else
                    {
                        if (tempNode.left != null)
                        {
                            tempNode = tempNode.left;
                        }
                        else
                        {
                            tempNode.left = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public bool Lookup(int value)
        {
            //Non recursive lookup
            //return InternalLookup(value);
            return InternalRecursiveLookup(value, _root);
        }

        private bool InternalRecursiveLookup(int value, Node currentNode)
        {
            if (currentNode == null)
            {
                return false;
            }

            if (currentNode.value == value)
            {
                return true;
            }

            return currentNode.value < value ?
                InternalRecursiveLookup(value, currentNode.right) : InternalRecursiveLookup(value, currentNode.left);
        }
        private bool InternalLookup(int value)
        {
            if (_root == null)
            {
                return false;
            }

            var tempNode = _root;
            while (tempNode != null)
            {
                if (value == tempNode.value)
                {
                    return true;
                }
                else if (tempNode.value < value)
                {
                    if (tempNode.right != null)
                    {
                        tempNode = tempNode.right;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (tempNode.left != null)
                    {
                        tempNode = tempNode.left;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        private Node FindSuccessor(Node node)
        {
            var tempNode = node.right;
            while (tempNode.left != null)
            {
                tempNode = tempNode.left;
            }

            return tempNode;
        }

        public void Remove(int value)
        {
            //Non recursive lookup
            //InternalRemove(value);
            _root = InternalRecursiveRemove(value, _root);

        }

        private void InternalRemove(int value)
        {
            if (_root == null)
            {
                throw new Exception("root cannot be null");
            }
            else
            {
                var tempNode = _root;
                Node prevNode = null;
                bool isLeft = false;
                while (tempNode != null)
                {
                    if (value == tempNode.value)
                    {
                        //if has no child then delete
                        if (tempNode.left == null && tempNode.right == null)
                        {
                            if (isLeft)
                            {
                                prevNode.left = null;
                            }
                            else
                            {
                                prevNode.right = null;
                            }
                        }
                        //if has 2 child then replace with successor
                        else if (tempNode.left != null && tempNode.right != null)
                        {
                            var successor = tempNode.right;
                            var prevSuccessor = tempNode;
                            while (successor.left != null)
                            {
                                successor = successor.left;
                                prevSuccessor = successor;
                            }
                            var tempValue = successor.value;
                            tempNode.value = tempValue;
                            if (prevSuccessor == successor)
                            {
                                _root = tempNode;
                            }
                            else
                            {
                                prevSuccessor.right = null;
                            }
                        }
                        else
                        {
                            if (isLeft)
                            {
                                prevNode.left = tempNode.left == null ? tempNode.right : tempNode.left;
                            }
                            else
                            {
                                prevNode.right = tempNode.left == null ? tempNode.right : tempNode.left;
                            }
                        }
                        return;
                    }
                    else if (tempNode.value < value)
                    {
                        if (tempNode.right != null)
                        {
                            tempNode = tempNode.right;
                            prevNode = tempNode;
                            isLeft = false;
                        }
                        else
                        {
                            throw new Exception("Value to be removed cannot be found");
                        }
                    }
                    else
                    {
                        if (tempNode.left != null)
                        {
                            tempNode = tempNode.left;
                            prevNode = tempNode;
                            isLeft = true;
                        }
                        else
                        {
                            throw new Exception("Value to be removed cannot be found");
                        }
                    }
                }
            }
        }

        private Node InternalRecursiveRemove(int value, Node currentNode)
        {
            if (currentNode == null)
            {
                return currentNode;
            }

            if (currentNode.value < value)
            {
                currentNode.right = InternalRecursiveRemove(value, currentNode.right);
                return currentNode;
            }
            else if (currentNode.value > value)
            {
                currentNode.left = InternalRecursiveRemove(value, currentNode.left);
                return currentNode;
            }
            else
            {
                //if has no child then delete
                if (currentNode.left == null && currentNode.right == null)
                {
                    return null;
                }

                //if has one child then replace
                if (currentNode.left == null)
                {
                    return currentNode.right;
                }
                else if (currentNode.right == null)
                {
                    return currentNode.left;
                }
                //if has two child, then find successor
                var smallestValue = FindSmallestValue(currentNode.right);
                currentNode.value = smallestValue;
                currentNode.right = InternalRecursiveRemove(smallestValue, currentNode.right);
            }

            return currentNode;
        }

        private int FindSmallestValue(Node node)
        {
            return node.left == null ? node.value : FindSmallestValue(node.left);
        }
    }
}