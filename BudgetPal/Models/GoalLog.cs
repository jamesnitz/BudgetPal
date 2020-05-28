using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPal.Models
{
    public class GoalLog
    {
        [Key]
        public int Id { get; set; }
        public int GoalId { get; set; }
        public decimal DepositAmount { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DepositDate { get; set; }
    }
}
