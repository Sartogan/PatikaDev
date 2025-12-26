using System;
using ToDoApp.Services;

class Program
{
    static void Main()
    {
        Board board = new Board();

        while (true)
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
            Console.WriteLine("(0) Çıkış");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    board.ListBoard();
                    break;

                case "2":
                    Console.Write("Başlık: ");
                    var title = Console.ReadLine();
                    Console.Write("İçerik: ");
                    var content = Console.ReadLine();
                    Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5): ");
                    int sizeChoice = int.Parse(Console.ReadLine());
                    Console.Write("Kişi ID Seçiniz: ");
                    int memberId = int.Parse(Console.ReadLine());
                    board.AddCard(title, content, sizeChoice, memberId);
                    break;

                case "3":
                    Console.Write("Silmek istediğiniz kart başlığı: ");
                    var delTitle = Console.ReadLine();
                    board.DeleteCard(delTitle);
                    break;

                case "4":
                    Console.Write("Taşımak istediğiniz kart başlığı: ");
                    var moveTitle = Console.ReadLine();
                    Console.WriteLine("Line seçiniz: (1) TODO (2) IN PROGRESS (3) DONE");
                    int lineChoice = int.Parse(Console.ReadLine());
                    board.MoveCard(moveTitle, lineChoice);
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
    }
}