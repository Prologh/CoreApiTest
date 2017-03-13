using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApiTest.Models.Quest
{
    public class Quest
    {
        /// <summary>
        /// Id for Quest.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestId { get; set; }
        /// <summary>
        /// Foreign key for Quest.
        /// </summary>
        public int QuestOwnerId { get; set; }
        /// <summary>
        /// A Hero object which Quest is (not always) reffering to.
        /// </summary>
        [ForeignKey("QuestOwnerId")]
        public Hero.Hero Hero { get; set; }
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
