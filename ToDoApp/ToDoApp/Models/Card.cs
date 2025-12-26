using System.Drawing;

namespace ToDoApp.Models
{
    public class Card
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public TeamMember AssignedPerson { get; set; }
        public Size Size { get; set; }

        public override string ToString()
        {
            return $"Başlık      : {Title}\n" +
                   $"İçerik      : {Content}\n" +
                   $"Atanan Kişi : {AssignedPerson.Name}\n" +
                   $"Büyüklük    : {Size}\n";
        }
    }
}