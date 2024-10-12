
namespace lab4
{
    ////////////////////////////////////// �������� ���������� //////////////////////////////////////
    public abstract class Controls
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }
        public abstract int Size();
        public abstract void Resize(int width, int height);
        public abstract void Show();
    }

    public class Checktbox : Controls, IControls
    {
        // ������������


        public Checktbox(int width = 10, int height = 10)
        {
            Name = "�������)";
            Width = width;
            Height = height;
        }

        public Checktbox(string name, int width = 10, int height = 10)
        {
            Name = name;
            Width = width;
            Height = height;
        }

        // ��������������� ����������� �������
        public override void Resize(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public override int Size()
        {
            return Width * Height;
        }
        public override void Show()
        {
            Console.WriteLine("��� ������� ���");
        }
        public void UseControl()
        {
            Console.WriteLine("�� ������ �� �������");
        }
        public override string ToString()
        {
            return ($"�������: {this.Name}, ������: {this.Width}, ������: {this.Height}");
        }

    }

    public class Radiobutton : Controls, IControls
    {
        // ������������

        public Radiobutton(int width = 10, int height = 10)
        {
            Name = "������ ������)";
            Width = width;
            Height = height;
        }

        public Radiobutton(string name, int width = 10, int height = 10)
        {
            Name = name;
            Width = width;
            Height = height;
        }

        // ��������������� ����������� �������
        public override void Resize(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public override int Size()
        {
            return Width * Height;
        }
        public override void Show()
        {
            Console.WriteLine("��� ����������� wow");
        }
        public void UseControl()
        {
            Console.WriteLine("�� ������ �� �����������");
        }
        public override string ToString()
        {
            return ($"�������: {this.Name}, ������: {this.Width}, ������: {this.Height}");
        }

    }
    public class Button : Controls, IControls
    {
        // ������������
        public Button(int width = 10, int height = 10)
        {
            Name = "������� ������:(";
            Width = width;
            Height = height;
        }

        public Button(string name, int width = 10, int height = 10)
        {
            Name = name;
            Width = width;
            Height = height;
        }

        // ��������������� ����������� �������
        public override void Resize(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public override int Size()
        {
            return Width * Height;
        }
        public override void Show()
        {
            Console.WriteLine("��� ������� ������ wow");
        }
        public void UseControl()
        {
            Console.WriteLine("�� ������ �� ������");
        }
        public override string ToString()
        {
            return ($"�������: {this.Name}, ������: {this.Width}, ������: {this.Height}");
        }

    }
}