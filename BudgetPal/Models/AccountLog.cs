using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPal.Models
{
    public class AccountLog
    {
            [Key]
            public int Id { get; set; }
            [Required]
            public int AccountId { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            [DataType(DataType.Date)]
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime Date { get; set; }
            [Required]
            public string ApplicationUserId { get; set; }
            public ApplicationUser ApplicationUser { get; set; }

            [Required]
            public int LogTypeId { get; set; }
            public LogType LogType { get; set; }
            [Required]
            public decimal Amount { get; set; }
            public bool Deposit { get; set; }
    }
}
