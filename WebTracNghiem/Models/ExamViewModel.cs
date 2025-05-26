namespace WebTracNghiem.Models
{
    public class ExamViewModel
    {
        public List<Question> Questions { get; set; }
        public Dictionary<int, string> UserAnswers { get; set; } = new Dictionary<int, string>();
    }

}
