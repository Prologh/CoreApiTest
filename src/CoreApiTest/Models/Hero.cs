﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApiTest.Models
{
    public class Hero : IEntityBase
    {
        public Hero()
        {
            Quests = new List<Quest>();
        }

        /// <summary>
        /// Integer id for Hero.
        /// </summary>
        //[Key]
        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// String name of a Hero.
        /// </summary>
        //[Required]
        //[MaxLength(length: 100)]
        public string Name { get; set; }
        /// <summary>
        /// A boolean value mapping if a Hero is already retired or not.
        /// </summary>
        public bool IsRetired { get; set; }

        /// <summary>
        /// List of all Quests reffered to specific Hero.
        /// </summary>
        public ICollection<Quest> Quests { get; set; }
    }
}
