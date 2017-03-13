namespace CoreApiTest.ViewModels
{
    public class ViewQuest
    {
        /// <summary>
        /// Id for Quest.
        /// </summary>
        public int QuestId { get; set; }
        /// <summary>
        /// Foreign key for Quest.
        /// </summary>
        public int QuestOwnerId { get; set; }
        /// <summary>
        /// Title of Quest.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// A boolean value mapping if a Quest was completed or not.
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
