using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPal.Models.ViewModels
{
    public class AccountLogViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Account ")]
        public int AccountId { get; set; }
        [Required]
        [Display(Name = "Transaction Details")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Date { get; set; }
        [Required]
        public int LogTypeId { get; set; }
        public LogType LogType { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public bool Deposit { get; set; }
        [Display(Name = "Transaction Type")]
        public List<SelectListItem> LogTypeOptions { get; set; }

    }
}
