Console.WriteLine("Введіть через пробіл числа для побудови бінарного деревера пошуку:");
string[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

BinaryTree tree = new BinaryTree();

foreach (var number in numbers)
{
    tree.Insert(Int32.Parse(number));
}

Console.WriteLine($"Висота побудованого дерева: {tree.Height()}");

class Node
{
    public Node Right;
    public Node Left;
    public int Data;

    public Node(int item)
    {
        Data = item;
        Right = Left = null;
    }
}

class BinaryTree
{
    public Node root;

    private Node Insert(Node node, int data)
    {
        if (node == null)
            return new Node(data);

        if (data < node.Data)
            node.Left = Insert(node.Left, data);
        else if (data > node.Data)
            node.Right = Insert(node.Right, data);

        return node;
    }

    public void Insert(int data)
    {
        root = Insert(root, data);
    }

    private int Height(Node node)
    {
        if (node == null)
            return 0;

        int leftHeight = Height(node.Left);
        int rightHeight = Height(node.Right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    public int Height()
    {
        return Height(root) - 1;
    }
}