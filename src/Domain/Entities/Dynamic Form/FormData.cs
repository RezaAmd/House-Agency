using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Dynamic_Form
{
    public class FormData
    {
        [Key]
        public string Id { get; set; }
        public string Value { get; set; }
    }
}