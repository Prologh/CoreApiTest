namespace CoreApiTest.ViewModels
{
    public class HeroViewModel
    {
        /// <summary>
        /// Id for Hero.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of a Hero.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Boolean value mapping if a Hero is already retired or not.
        /// </summary>
        public bool IsRetired { get; set; }
        /// <summary>
        /// An interger number of Quests reffered to Hero.
        /// </summary>
        public int Quests { get; set; }
    }
}
