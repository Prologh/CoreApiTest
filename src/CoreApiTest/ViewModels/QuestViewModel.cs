namespace CoreApiTest.ViewModels
{
    public class QuestViewModel
    {
        /// <summary>
        /// Integer id of Quest.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// String title of Quest.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// A boolean value deciding if a Quest was completed or not.
        /// </summary>
        public bool IsCompleted { get; set; }
        /// <summary>
        /// Integer foreign key of Hero for Quest.
        /// </summary>
        public int HeroId { get; set; }
    }
}
