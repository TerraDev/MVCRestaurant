using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVCRestaurant.ViewModels;

namespace MVCRestaurant
{
    public static class TempDB
    {
        public static List<FoodCategoryViewModel> FoodCategoryDB = new List<FoodCategoryViewModel>()
        {
            new FoodCategoryViewModel()
            {
                id = 1,
                name = "برگر",
                Icon = "fas fa-hamburger",
            },
            new FoodCategoryViewModel()
            {
                id = 2,
                name = "ساندویچ",
                Icon = "fas fa-hotdog"
            },
            new FoodCategoryViewModel()
            {
                id = 3,
                name = "پیتزا",
                Icon = "fas fa-pizza-slice"
            },
            new FoodCategoryViewModel()
            {
                id = 4,
                name = "نوشیدنی",
                Icon = "fas fa-cocktail"
            },
            new FoodCategoryViewModel()
            {
                id = 5,
                name = "صبحانه",
                Icon = "fas fa-bread-slice"
            },
            new FoodCategoryViewModel()
            {
                id = 6,
                name = "دسر",
                Icon = "fas fa-ice-cream"
            }
        };

        public static List<FoodItemViewModel> FoodItemDB = new List<FoodItemViewModel>()
        {
            new FoodItemViewModel()
            {
                //id = 1,
                name = "پیتزا مخصوص",
                category = FoodCategoryDB[2],
                price = 70000,
                ImagePath = "/Images/Food/مخصوص.jpg",
            },
            new FoodItemViewModel()
            {
                //id = 2,
                name = "پیتزا پپرونی",
                category = FoodCategoryDB[2],
                price = 85000,
                ImagePath = "/Images/Food/پپرونی.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 3,
                name = "پیتزا گوشت‌وقارچ",
                category = FoodCategoryDB[2],
                price = 65000,
                ImagePath = "/Images/Food/pizza-gharch-gousht.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 4,
                name = "پیتزا مخلوط",
                category = FoodCategoryDB[2],
                price = 90000,
                ImagePath = "/Images/Food/مخلوط.jpeg",
            },
            new FoodItemViewModel()
            {
                //id = 5,
                name = "پیتزا رست بیف",
                category = FoodCategoryDB[2],
                price = 100000,
                ImagePath = "/Images/Food/پیتزا-رست-بیف.jpeg"
            },
            new FoodItemViewModel()
            {
                //id = 6,
                name = "پیتزا کینگ",
                category = FoodCategoryDB[2],
                price=120000,
                ImagePath = "/Images/Food/پیتزا گینگ.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 7,
                name = "پیتزا سبزیجات",
                category = FoodCategoryDB[2],
                price = 50000,
                ImagePath = "/Images/Food/vegetable pizza.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 8,
                name = "پیتزا ریو",
                category = FoodCategoryDB[2],
                price = 95000,
                ImagePath = "/Images/Food/پیتزا ریو.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 9,
                name = "پیتزا چیکن آلفردو",
                category = FoodCategoryDB[2],
                price = 145000,
                ImagePath = "/Images/Food/پیتزا چیکن الفردو.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 10,
                name = "پیتزا مارگاریتا",
                category = FoodCategoryDB[2],
                price = 135000,
                ImagePath = "/Images/Food/pizza-margarita.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 11,
                name = "پیتزا مرغ",
                category = FoodCategoryDB[2],
                price= 70000,
                ImagePath = "/Images/Food/pitza-morgh.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 12,
                name = "پیتزا استیک",
                category = FoodCategoryDB[2],
                price = 100000,
                ImagePath = "/Images/Food/steak-pizza.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 13,
                name = "پیتزا ناپولیتن",
                category = FoodCategoryDB[2],
                price = 115000,
                ImagePath = "/Images/Food/پیتزا-ایتالیایی-ناپولیتن.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 14,
                name = "پیتزا بوقلمون",
                category = FoodCategoryDB[2],
                price = 165000,
                ImagePath = "/Images/Food/پیتزا بوقلمون.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 15,
                name = "پیتزا نیویورکی",
                category = FoodCategoryDB[2],
                price = 120000,
                ImagePath = "/Images/Food/New-York-Style-Pizza.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 16,
                name = "پیتزا سیسیلی",
                category = FoodCategoryDB[2],
                price = 170000,
                ImagePath = "/Images/Food/sicilian pizza.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 17,
                name = "پیتزا کالزونه",
                category = FoodCategoryDB[2],
                price = 155000,
                ImagePath = "/Images/Food/pizza-calzone.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 18,
                name = "پیتزا زبان",
                category = FoodCategoryDB[2],
                price = 95000,
                ImagePath = "/Images/Food/پیتزا-زبان.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 19,
                name = "پیتزای یونانی",
                category = FoodCategoryDB[2],
                price = 95000,
                ImagePath = "/Images/Food/pizza-greek.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 20,
                name = "همبرگر",
                category = FoodCategoryDB[0],
                price = 55000,
                ImagePath = "/Images/Food/hamburger.jpg",
            },
            new FoodItemViewModel()
            {
                //id = 21,
                name = "برگر بوقلمون",
                category = FoodCategoryDB[0],
                price = 100000,
                ImagePath = "/Images/Food/برگر بوقلمون.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 22,
                name = "چیزبرگر",
                category = FoodCategoryDB[0],
                price = 70000,
                ImagePath = "/Images/Food/cheese burger.jpg",
            },
            new FoodItemViewModel()
            {
                //id = 23,
                name = "برگر زیتون",
                category = FoodCategoryDB[0],
                price = 60000,
                ImagePath = "/Images/Food/زیتون برگر.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 24,
                name = "چیزبرگر پیمنتو",
                category = FoodCategoryDB[0],
                price = 95000,
                ImagePath = "/Images/Food/پیمنتو برگر.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 25,
                name = "بیکی برگر",
                category = FoodCategoryDB[0],
                price = 80000,
                ImagePath = "/Images/Food/بیکی برگر.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 26,
                name = "همبرگر پاسترامی",
                category = FoodCategoryDB[0],
                price = 100000,
                ImagePath = "/Images/Food/برگر پاسترامی.jpeg"
            },
            new FoodItemViewModel()
            {
                //id = 27,
                name = "برگر برنج",
                category = FoodCategoryDB[0],
                price = 40000,
                ImagePath = "/Images/Food/برگر برنج.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 28,
                name = "چیلی برگر",
                category = FoodCategoryDB[0],
                price= 60000,
                ImagePath = "/Images/Food/chili-berger.jpg",
            },
            new FoodItemViewModel()
            {
                //id = 29,
                name = "برگر پیاز",
                category = FoodCategoryDB[0],
                price = 60000
            },
            new FoodItemViewModel()
            {
                //id = 30,
                name = "برگر دوبله",
                category = FoodCategoryDB[0],
                price = 110000
            },
            new FoodItemViewModel()
            {
                //id = 31,
                name = "برگر گوشت‌و‌قارچ",
                category = FoodCategoryDB[0],
                price= 70000
            },
            new FoodItemViewModel()
            {
                //id = 32,
                name = "برگر ترکی",
                category = FoodCategoryDB[0],
                price = 75000
            },
            new FoodItemViewModel()
            {
                //id = 33,
                name = "چیکن برگر",
                category = FoodCategoryDB[0],
                price = 60000
            },
            new FoodItemViewModel()
            {
                //id = 34,
                name = "برگر سوخاری",
                category = FoodCategoryDB[0],
                price = 85000,
                ImagePath = "/Images/Food/zinger.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 35,
                name = "هات‌داگ",
                category = FoodCategoryDB[1],
                price = 50000
            },
            new FoodItemViewModel()
            {
                //id = 36,
                name = "هات‌داگ پنیری",
                category = FoodCategoryDB[1],
                ImagePath = "/Images/Food/cheese-hot-dog.jpg",
                price = 55000
            },
            new FoodItemViewModel()
            {
                //id = 37,
                name = "ساندویچ زبان",
                category = FoodCategoryDB[1],
                price = 65000,
                ImagePath = "/Images/Food/ساندویچ-زبان.png"
            },
            new FoodItemViewModel()
            {
                //id = 38,
                name = "ساندویچ گوشت",
                category = FoodCategoryDB[1],
                price = 90000
            },
            new FoodItemViewModel()
            {
                //id = 39,
                name = "ساندویچ مرغ‌وقارچ",
                category = FoodCategoryDB[1],
                price = 75000,
                ImagePath = "/Images/Food/ساندویچ مرغ و قارچ.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 40,
                name = "ساندویچ ماکارونی",
                category = FoodCategoryDB[1],
                price = 45000,
                ImagePath = "/Images/Food/ساندویچ ماکارونی.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 41,
                name = "ساندویچ قارج‌وسیر",
                category = FoodCategoryDB[1],
                price = 50000
            },
            new FoodItemViewModel()
            {
                //id = 42,
                name = "ساندویچ میگو",
                category = FoodCategoryDB[1],
                price = 120000,
                ImagePath = "/Images/Food/ساندویچ میگو.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 43,
                name = "ساندویچ سوخاری",
                category = FoodCategoryDB[1],
                price = 90000
            },
            new FoodItemViewModel()
            {
                //id = 44,
                name = "ساندویچ فیله",
                category = FoodCategoryDB[1],
                price = 85000,
                ImagePath = "/Images/Food/ساندویچ فیله.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 45,
                name = "ساندویچ مکزیکی",
                category = FoodCategoryDB[1],
                price = 110000
            },
            new FoodItemViewModel()
            {
                //id = 46,
                name = "ساندویچ چیکن پستو",
                category = FoodCategoryDB[1],
                price = 100000
            },
            new FoodItemViewModel()
            {
                //id = 47,
                name = "ساندویچ سزار",
                category = FoodCategoryDB[1],
                price = 65000
            },
            new FoodItemViewModel()
            {
                //id = 48,
                name = "ساندویچ یونانی",
                category = FoodCategoryDB[1],
                price = 90000
            },
            new FoodItemViewModel()
            {
                //id = 49,
                name = "ساندویچ زاپاتا",
                category = FoodCategoryDB[1],
                price = 130000,
                ImagePath = "/Images/Food/ساندویچ زاپاتا.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 50,
                name = "ساندویچ پاسترامی آمریکایی",
                category = FoodCategoryDB[1],
                price = 130000
            },
            new FoodItemViewModel()
            {
                //id = 51,
                name = "ساندویچ ژامبون",
                category = FoodCategoryDB[1],
                price = 70000,
                ImagePath = "/Images/Food/sandevich-jambon.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 52,
                name = "کوکتل ساده",
                category = FoodCategoryDB[1],
                price = 75000,
                ImagePath = "/Images/Food/کوکتل.jpeg"
            },
            new FoodItemViewModel()
            {
                //id = 53,
                name = "کوکتل پنیری",
                category = FoodCategoryDB[1],
                price = 85000,
                ImagePath = "/Images/Food/کوکتل پنیری.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 54,
                name = "ساندویچ بندری",
                category = FoodCategoryDB[1],
                price = 55000,
                ImagePath = "/Images/Food/Sosis-Bandari.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 55,
                name = "ساندویچ فلافل",
                category = FoodCategoryDB[1],
                price = 35000,
                ImagePath = "/Images/Food/ساندویچ-فلافل.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 56,
                name = "شاورما",
                category = FoodCategoryDB[1],
                price = 50000,
                ImagePath = "/Images/Food/شاورما.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 57,
                name = "آب",
                category = FoodCategoryDB[3],
                ImagePath = "/Images/Food/water.jpeg",
                price = 5000
            },
            new FoodItemViewModel()
            {
                //id = 58,
                name = "دوغ",
                category = FoodCategoryDB[3],
                ImagePath = "/Images/Food/doogh.jpg",
                price = 8000
            },
            new FoodItemViewModel()
            {
                //id = 59,
                name = "کوکا کولا",
                category = FoodCategoryDB[3],
                ImagePath = "/Images/Food/cocacola.jpg",
                price = 15000
            },
            new FoodItemViewModel()
            {
                //id = 60,
                name = "کوکا کولا زیرو",
                category = FoodCategoryDB[3],
                ImagePath = "/Images/Food/cocacola-zero.jpg",
                price = 18000
            },
            new FoodItemViewModel()
            {
                //id = 61,
                name = "کوکا کولا لایت",
                category = FoodCategoryDB[3],
                ImagePath = "/Images/Food/cocacola-light.jpg",
                price = 17000
            },
            new FoodItemViewModel()
            {
                //id = 62,
                name = "پپسی",
                category = FoodCategoryDB[3],
                ImagePath = "/Images/Food/Pepsi2.ico",
                price = 16000
            },
            new FoodItemViewModel()
            {
                //id = 63,
                name = "فانتا",
                category = FoodCategoryDB[3],
                ImagePath = "/Images/Food/fanta.png",
                price = 20000
            },
            new FoodItemViewModel()
            {
                //id = 64,
                name = "لبموناد",
                category = FoodCategoryDB[3],
                ImagePath = "/Images/Food/lemonade.jpg",
                price = 16000
            },
            new FoodItemViewModel()
            {
                //id = 65,
                name = "موهیتو",
                category = FoodCategoryDB[3],
                ImagePath = "/Images/Food/Mojito.jpg",
                price = 17000
            },
            new FoodItemViewModel()
            {
                //id = 66,
                name = "دلستر",
                category = FoodCategoryDB[3],
                ImagePath = "/Images/Food/Delster.jpg",
                price = 23000
            },
            new FoodItemViewModel()
            {
                //id = 67,
                name = "بلولایم",
                category = FoodCategoryDB[3],
                ImagePath = "/Images/Food/blue lime.jpg",
                price = 28000
            },
            new FoodItemViewModel()
            {
                //id = 68,
                name = "مسکو میول",
                category = FoodCategoryDB[3],
                ImagePath = "/Images/Food/moscow-mule.jpg",
                price = 35000
            },
            new FoodItemViewModel()
            {
                //id = 69,
                name = "نیمرو",
                category = FoodCategoryDB[4],
                price = 30000,
                ImagePath = "/Images/Food/نیمرو.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 70,
                name = "املت",
                category = FoodCategoryDB[4],
                price = 35000,
                ImagePath = "/Images/Food/omlet.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 71,
                name = "املت هندی",
                category = FoodCategoryDB[4],
                price = 40000,
                ImagePath = "/Images/Food/omlet-hendi.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 72,
                name = "املت قارچ‌و‌سبزیجات",
                category = FoodCategoryDB[4],
                price = 40000
            },
            new FoodItemViewModel()
            {
                //id = 73,
                name = "پنکیک",
                category = FoodCategoryDB[4],
                price = 45000,
                ImagePath = "/Images/Food/pancake.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 74,
                name = "پنکیک سیب‌زمینی لهستانی",
                category = FoodCategoryDB[4],
                price = 50000
            },
            new FoodItemViewModel()
            {
                //id = 75,
                name = "پنکیک ردولوت",
                category = FoodCategoryDB[4],
                price = 55000,
                ImagePath = "/Images/Food/پنکیک ردولوت.jpeg"
            },
            new FoodItemViewModel()
            {
                //id = 76,
                name = "عدسی",
                category = FoodCategoryDB[4],
                price = 25000,
                ImagePath = "/Images/Food/adasi.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 77,
                name = "نرگسی اسفناج",
                category = FoodCategoryDB[4],
                price = 35000
            },
            new FoodItemViewModel()
            {
                //id = 78,
                name = "ماست",
                category = FoodCategoryDB[5],
                price = 15000
            },
            new FoodItemViewModel()
            {
                //id = 79,
                name = "ژله",
                category = FoodCategoryDB[5],
                price = 23000,
                ImagePath = "/Images/Food/zhele.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 80,
                name = "بستنی",
                category = FoodCategoryDB[5],
                price = 15000
            },
            new FoodItemViewModel()
            {
                //id = 81,
                name = "کوکی",
                category = FoodCategoryDB[5],
                price = 10000,
                ImagePath = "/Images/Food/cookie.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 82,
                name = "چیزکیک",
                category = FoodCategoryDB[5],
                price = 30000,
                ImagePath = "/Images/Food/cheeseCake.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 83,
                name = "بانوفی پای",
                category = FoodCategoryDB[5],
                price = 30000
            },
            new FoodItemViewModel()
            {
                //id = 84,
                name = "پودینگ",
                category = FoodCategoryDB[5],
                price = 17000,
                ImagePath = "/Images/Food/پودینگ.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 85,
                name = "تیرامیسو",
                category = FoodCategoryDB[5],
                price = 20000,
                ImagePath = "/Images/Food/tiramiso.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 86,
                name = "سیب کاراملی",
                category = FoodCategoryDB[5],
                price = 25000,
                ImagePath = "/Images/Food/سیب کاراملی.jpg"
            },
            new FoodItemViewModel()
            {
                //id = 87,
                name = "تارت گیلاس",
                category = FoodCategoryDB[5],
                price = 40000,
                ImagePath = "/Images/Food/tart-gilas.jpg"
            },
        };

        public static List<OrderItemViewModel> OrderItemDB = new List<OrderItemViewModel>()
        {
            new OrderItemViewModel()
            {
                food = FoodItemDB[0],
                quantity = 2,
                //TotalPrice = 10.5M,
            },
            new OrderItemViewModel()
            {
                food = FoodItemDB[1],
                quantity = 1,
                //TotalPrice = 8.4M,
            },
            new OrderItemViewModel()
            {
                food = FoodItemDB[2],
                quantity = 3,
                //TotalPrice = 9.2M,
            },
            new OrderItemViewModel()
            {
                food = FoodItemDB[3],
                quantity = 6,
                //TotalPrice = 22.1M,
            }
        };

        public static List<List<OrderItemViewModel>> OrderDB = new List<List<OrderItemViewModel>>()
        {
            new List<OrderItemViewModel>()
            {
                OrderItemDB[0],
                OrderItemDB[1],
                OrderItemDB[2],
                OrderItemDB[3]
            }
        };

    }
}
