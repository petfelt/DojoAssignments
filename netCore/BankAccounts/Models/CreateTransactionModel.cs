using System.ComponentModel.DataAnnotations;
namespace BankAccounts.Models
{
    public class CreateTransactionModel : BaseEntity
    {
        [Required(ErrorMessage = "Amount is required.")]
        [RangeAttribute(int.MinValue, int.MaxValue, ErrorMessage = "Please enter a valid integer number.")]
        public int Amount { get; set; }
    }
}