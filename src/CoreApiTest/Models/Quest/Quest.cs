﻿using System;
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
        /// Integer id of Quest.
        /// </summary>
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdQuest { get; set; }
        /// <summary>
        /// String title of Quest.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// A boolean value mapping if a Quest was completed or not.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Integer foreign key of Hero for Quest.
        /// </summary>
        [ForeignKey("IdHero")]
        public int? IdHero { get; set; }
        /// <summary>
        /// Hero object which Quest is reffered to.
        /// </summary>
        public Hero.Hero Hero { get; set; }
    }
}
