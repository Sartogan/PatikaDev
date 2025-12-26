using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class Board
    {
        public List<Card> Todo { get; set; } = new();
        public List<Card> InProgress { get; set; } = new();
        public List<Card> Done { get; set; } = new();

        public Dictionary<int, TeamMember> TeamMembers { get; set; } = new();

        public Board()
        {
            TeamMembers.Add(1, new TeamMember { Id = 1, Name = "Ali" });
            TeamMembers.Add(2, new TeamMember { Id = 2, Name = "Ayşe" });
            TeamMembers.Add(3, new TeamMember { Id = 3, Name = "Mehmet" });

            Todo.Add(new Card { Title = "Alışveriş", Content = "Market alışverişi yapılacak", AssignedPerson = TeamMembers[1], Size = Size.M });
            InProgress.Add(new Card { Title = "Ödev", Content = "C# projesi yazılacak", AssignedPerson = TeamMembers[2], Size = Size.L });
            Done.Add(new Card { Title = "Spor", Content = "Koşuya çıkıldı", AssignedPerson = TeamMembers[3], Size = Size.S });
        }

        public void ListBoard()
        {
            Console.WriteLine("TODO Line\n************************");
            PrintCards(Todo);

            Console.WriteLine("\nIN PROGRESS Line\n************************");
            PrintCards(InProgress);

            Console.WriteLine("\nDONE Line\n************************");
            PrintCards(Done);
        }

        private void PrintCards(List<Card> cards)
        {
            if (!cards.Any())
            {
                Console.WriteLine("~ BOŞ ~");
                return;
            }
            foreach (var card in cards)
            {
                Console.WriteLine(card);
                Console.WriteLine("-");
            }
        }

        public void AddCard(string title, string content, int sizeChoice, int memberId)
        {
            if (!TeamMembers.ContainsKey(memberId))
            {
                Console.WriteLine("Hatalı girişler yaptınız!");
                return;
            }

            var card = new Card
            {
                Title = title,
                Content = content,
                Size = (Size)sizeChoice,
                AssignedPerson = TeamMembers[memberId]
            };

            Todo.Add(card);
            Console.WriteLine("Kart eklendi.");
        }

        public void DeleteCard(string title)
        {
            bool deleted = DeleteFromList(Todo, title) | DeleteFromList(InProgress, title) | DeleteFromList(Done, title);

            if (!deleted)
            {
                Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı.");
            }
        }

        private bool DeleteFromList(List<Card> list, string title)
        {
            var toDelete = list.Where(c => c.Title.Equals(title, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!toDelete.Any()) return false;

            foreach (var card in toDelete)
                list.Remove(card);

            Console.WriteLine($"{toDelete.Count} kart silindi.");
            return true;
        }

        public void MoveCard(string title, int lineChoice)
        {
            Card card = Todo.FirstOrDefault(c => c.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                     ?? InProgress.FirstOrDefault(c => c.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                     ?? Done.FirstOrDefault(c => c.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (card == null)
            {
                Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı.");
                return;
            }

            Todo.Remove(card);
            InProgress.Remove(card);
            Done.Remove(card);

            switch (lineChoice)
            {
                case 1: Todo.Add(card); break;
                case 2: InProgress.Add(card); break;
                case 3: Done.Add(card); break;
                default:
                    Console.WriteLine("Hatalı bir seçim yaptınız!");
                    return;
            }

            Console.WriteLine("Kart taşındı.");
            ListBoard();
        }
    }
}