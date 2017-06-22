namespace HeroCore.Api.ViewModels
{
    public class HeroViewModel
    {
        /// <summary>
        /// Id for HeroCore.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of a HeroCore.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Boolean value mapping if a Hero is already retired or not.
        /// </summary>
        public bool IsRetired { get; set; }

        /// <summary>
        /// An interger number of Quests reffered to HeroCore.
        /// </summary>
        public int Quests { get; set; }
    }
}
