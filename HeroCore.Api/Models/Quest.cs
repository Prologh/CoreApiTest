using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroCore.Api.Models
{
    public class Quest : IEntityBase
    {
        /// <summary>
        /// Integer id of Quest.
        /// </summary>
        //[Key]
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        //[Required]
        public int HeroId { get; set; }
        /// <summary>
        /// Hero object which is the owner of Quest.
        /// </summary>
        //[DisplayFormat(NullDisplayText = "No_Quests")]
        public Hero Hero { get; set; }
    }
}
