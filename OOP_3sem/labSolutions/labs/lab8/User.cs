    using System;

namespace Lab8
{
    /*1) Используя делегаты (множественные) и события промоделируйте 
    ситуации, приведенные в таблице ниже. Можете добавить новые типы (классы), 
    если существующих недостаточно. */

    public delegate void Move(int extent);
    public delegate void Squeeze(double compressionRate);
    public class User
    {
        public event Action<int> Move; // смещение
        public event Action<double> Resize; // коэффициент сжатия

        public string Name { get; set; }
        public int Position { get; private set; } = 0;
        public double Size { get; private set; } = 1.0;

        public User(string name)
        {
            Name = name;
        }

        public void OnMove(int offset)
        {
            this.Position += offset;
            Move?.Invoke(offset);
        }

        public void OnResize(double factor)
        {
            this.Size *= factor;
            Resize?.Invoke(factor);
        }

        public void SubscribeToMove(Action<int> moveHandler)
        {
            Move += moveHandler;
        }

        public void SubscribeToResize(Action<double> resizeHandler)
        {
            Resize += resizeHandler;
        }
    }
}
