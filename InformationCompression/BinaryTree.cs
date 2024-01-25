using System;
using System.Collections.Generic;
using System.Text;

namespace InformationCompression
{
    class BinaryTree
    {

        private Node root;
        public BinaryTree()
        {
            root = new Node();
        }
        public BinaryTree(Node root)
        {
            this.root = root;
        }
        public int getFrequence()
        {
            return root.getFrequence();
        }

        public Node getRoot()
        {
            return root;
        }
        public class Node {
            private int frequence;//частота
            private char letter;//буква
            private Node leftChild;//левый потомок
            private Node rightChild;//правый потомок



            public Node(char letter, int frequence)
            { //собственно, конструктор
                this.letter = letter;
                this.frequence = frequence;
            }

            public Node() { }//перегрузка конструтора для безымянных узлов(см. выше в разделе о построении дерева Хаффмана)
            public void addChild(Node newNode)
            {//добавить потомка
                if (leftChild == null)//если левый пустой=> правый тоже=> добавляем в левый
                    leftChild = newNode;
                else
                {
                    if (leftChild.getFrequence() <= newNode.getFrequence()) //в общем, левым потомком
                        rightChild = newNode;//станет тот, у кого меньше частота
                    else
                    {
                        rightChild = leftChild;
                        leftChild = newNode;
                    }
                }

                frequence += newNode.getFrequence();//итоговая частота
            }

            public Node getLeftChild()
            {
                return leftChild;
            }

            public Node getRightChild()
            {
                return rightChild;
            }

            public int getFrequence()
            {
                return frequence;
            }

            public char getLetter()
            {
                return letter;
            }

            public bool isLeaf()
            {//проверка на лист
                return leftChild == null && rightChild == null;
            }
        }
    }
}
