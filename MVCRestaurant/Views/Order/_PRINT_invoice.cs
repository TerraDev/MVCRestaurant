using MVCRestaurant.ViewModels;

namespace MVCRestaurant.Views.Order
{
    public static class _PRINT_invoice
    {
        public static string GetView(OrderViewModel Model)
        {
            string html = "<div id=\"cont\" style=\"direction: rtl\">\r\n" +
                "    <p>فاکتور خرید:</p>\r\n" +
                "    <style>\r\n" +
                "        table, td, th {\r\n" +
                "            border: 1px solid black;\r\n" +
                "            text-align: center;\r\n" +
                "            border-collapse: collapse;\r\n" +
                "        }\r\n" +
                "    </style>\r\n" +
                "    <table width=\"100%\">\r\n" +
                "        <tr>\r\n" +
                "            <th>ردیف</th>\r\n" +
                "            <th>غذا</th>\r\n" +
                "            <th>قیمت</th>\r\n" +
                "            <th>تعداد</th>\r\n" +
                "            <th>قیمت کل</th>\r\n" +
                "        </tr>";

            ushort i = 0;
            foreach (OrderItemViewModel item in Model.orderItems)
            {
                i++;
                uint itemTotalPrice = item.quantity * (uint)item.food.price;
                html += "        <tr>\r\n" +
                    "            <td>" + i + "</td>\r\n" +
                    "            <td>" + item.food.name + "</td>\r\n" +
                    "            <td>" + item.food.price + "</td>\r\n" +
                    "            <td>" + item.quantity + "</td>\r\n" +
                    "            <td>" + itemTotalPrice + "</td>\r\n" +
                    "        </tr>";
            }

            html += "        <tr>\r\n" +
                "            <td colspan=\"4\">مجموع</td>\r\n" +
                "            <td>" + Model.Total + "</td>\r\n" +
                "        </tr>\r\n" +
                "        <tr>\r\n" +
                "            <td colspan=\"4\">مالیات</td>\r\n" +
                "            <td>" + Model.Tax + "</td>\r\n" +
                "        </tr>"+
                "        <tr style=\"height:50px; font-size: 20px\">\r\n" +
                "            <td colspan=\"4\"><b>قیمت نهایی</b></td>\r\n" +
                "            <td><b>" + Model.FinalPrice + " تومان</b></td>\r\n" +
                "        </tr>\r\n" +
                "        <tr>\r\n" +
                "            <td colspan=\"4\">شماره انتظار: 431</td>\r\n" +
                "        </tr>";

            return html;
        }
    }
}
