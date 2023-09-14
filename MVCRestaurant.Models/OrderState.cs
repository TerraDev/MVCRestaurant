using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Models
{
    public enum OrderStateEnum
    {
        [Display(Name = "شروع نشده")]
        NotStarted = 1,

        [Display(Name = "در حال انتخاب غذا")]
        Deciding = 2,

        [Display(Name = "در حال سفارش")]
        Ordering = 3,

        [Display(Name = "تایید آدرس")]
        ConfirmedAddress =4,

        [Display(Name = "اقدام برای تراکنش")]
        AttemptedTransaction =5,

        [Display(Name = "تراکنش ناموفق")]
        TransactionFailed =6,

        [Display(Name = "در انتظار غذا")]
        Waiting =7,

        [Display(Name = "غذا دریافت شد")]
        Delivered =8,
    }
}
