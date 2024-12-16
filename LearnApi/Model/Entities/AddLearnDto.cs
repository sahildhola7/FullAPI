using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnApi.Model.Entities
{
    public class AddLearnDto
    {
        public required string Name { get; set; }
        public required string Surename { get; set; }
        public required string BirthMonth{ get; set; }
    }
}