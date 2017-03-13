using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApiTest.Models.Hero
{
    public class Hero
    {
        /// <summary>
        /// Id for Hero.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HeroId { get; set; }
        /// <summary>
        /// The name of Hero.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A boolean value mapping if a Hero is already retired or not.
        /// </summary>
        public bool IsRetired { get; set; }
        /// <summary>
        /// A list of all Quests reffered to specific Hero.
        /// </summary>
        //public List<Quest.Quest> Quests { get; set; }
    }
}
