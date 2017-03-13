namespace CoreApiTest.ViewModels
{
    public class ViewHero
    {
        /// <summary>
        /// Id for Hero.
        /// </summary>
        public int HeroId { get; set; }
        /// <summary>
        /// The name of a Hero.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Boolean value mapping if a Hero is already retired or not.
        /// </summary>
        public bool IsRetired { get; set; }
    }
}
