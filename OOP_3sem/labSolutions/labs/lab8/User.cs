using System;

namespace Lab08
{
    /*1) Используя делегаты (множественные) и события промоделируйте 
    ситуации, приведенные в таблице ниже. Можете добавить новые типы (классы), 
    если существующих недостаточно. */

    public delegate void Move(int extent);
    public delegate void Squeeze(double compressionRate);
    class User
    {
        public static event Move OnMove;
        public static event Squeeze OnSqueez;

        public static void MoveUser(Software soft)
        {
            Console.WriteLine($"Пользователь перемещен на {}px");
            User.OnSqueez += soft.Move;
            ;
        }
        public static void EndWorkWithSoft(Software soft)
        {
            Console.WriteLine("Завершаю работу...");
            User.EndWork += soft.EndWork;
            EndWork?.Invoke();
        }
        public static void UpgradeVersion(Software soft, string newVersion)
        {
            Console.WriteLine("Обновление...");
            User.OnUpgrade += soft.ChangeVersion;
            OnUpgrade?.Invoke(newVersion);
        }
    }
}
