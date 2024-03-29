﻿using Shop.DAL.Models;

namespace Shop.DAL
{
    public class DBObjects
    {
        private const string electricCars = "Electric";
        private const string gasolineCars = "Gasoline";
        public static void Initial(AppDBContext context)
        {  
            if (!context.Categories.Any())
            context.Categories.AddRange(Categories.Select(c => c.Value));

            if (!context.Cars.Any())
            {
                context.AddRange(
                     new Car
                     {
                         Name = "Tesla Model S",
                         ShortDesc = "Luxurious, reliable",
                         LongDesc = "The Tesla Model S is a sleek and luxurious all-electric sedan that epitomizes cutting-edge automotive technology. With its sleek design, impressive range, and lightning-fast acceleration, the Model S offers a truly exhilarating driving experience.",
                         Image = "1.jpg",
                         Price = 30000,
                         TopSellingCars = false,
                         Available = true,
                         Category = Categories[electricCars]
                     },
                     new Car
                     {
                         Name = "Mitsubishi Lancer X Evolution",
                         ShortDesc = "Fast, powerful",
                         LongDesc = "The Mitsubishi Lancer X Evolution is a high-performance sports sedan that combines stylish design with impressive power. Its aggressive exterior features sleek lines and a bold front grille, giving it a commanding presence on the road. Under the hood, the Lancer X Evolution boasts a turbocharged engine, delivering exhilarating performance and precise handling, making it a true driving enthusiast's dream.",
                         Image = "2.jpg",
                         Price = 21000,
                         TopSellingCars = true,
                         Available = false,
                         Category = Categories[gasolineCars]
                     },
                     new Car
                     {
                         Name = "BMW M5",
                         ShortDesc = "High-performance luxury sedan",
                         LongDesc = "The BMW M5 is a high-performance luxury sedan that offers a perfect blend of power, comfort, and sophistication. Its sleek and aerodynamic design turns heads wherever it goes, while its powerful engine and advanced suspension system provide thrilling performance on the road. Inside the cabin, the M5 boasts a luxurious and technologically advanced interior, offering the perfect balance of driver-focused features and passenger comfort.",
                         Image = "14.jpg",
                         Price = 85000,
                         TopSellingCars = false,
                         Available = true,
                         Category = Categories[gasolineCars]
                     },
                     new Car
                     {
                         Name = "Mercedes-Benz EQS",
                         ShortDesc = "Luxury electric sedan",
                         LongDesc = "The Mercedes-Benz EQS is a luxurious all-electric sedan that combines cutting-edge technology with uncompromising comfort. Its sleek and aerodynamic design represents the pinnacle of elegance, while its advanced electric drivetrain delivers smooth and powerful performance. The EQS offers a spacious and opulent interior, featuring the latest in-car technology and premium materials, providing a truly indulgent driving experience for those who appreciate luxury and sustainability.",
                         Image = "15.jpg",
                         Price = 110000,
                         TopSellingCars = false,
                         Available = true,
                         Category = Categories[electricCars]
                     },
                    new Car
                     {
                         Name = "Porsche Panamera",
                         ShortDesc = "Sporty luxury sedan",
                         LongDesc = "The Porsche Panamera is a sporty luxury sedan that offers a thrilling driving experience combined with unparalleled luxury. Its sleek and dynamic design commands attention, while its powerful gasoline engine delivers exhilarating performance on the road. The Panamera features a well-appointed interior with high-quality materials and advanced technology, providing a comfortable and connected driving environment. With its blend of sportiness and refinement, the Panamera is a true driver's car for those who crave performance and style.",
                         Image = "16.jpg",
                         Price = 90000,
                         TopSellingCars = false,
                         Available = true,
                         Category = Categories[gasolineCars]
                     },
                    new Car
                      {
                          Name = "Nissan Leaf 2020",
                          ShortDesc = "Сomfortable, cost-effective",
                          LongDesc = "The Nissan Leaf 2020 is an all-electric vehicle that offers impressive performance and eco-friendly driving experience. With its sleek design and advanced technology, it provides a comfortable and efficient ride for both city commuting and longer trips. The Leaf's long electric range, quick charging capabilities, and spacious interior make it a practical choice for those seeking a reliable and sustainable transportation option.",
                          Image = "3.jpg",
                          Price = 20000,
                          TopSellingCars = true,
                          Available = true,
                          Category = Categories[electricCars]
                      },
                    new Car
                       {
                           Name = "Alfa Romeo",
                           ShortDesc = "Passability, reliability",
                           LongDesc = "Alfa Romeo is an iconic Italian automotive brand known for its rich heritage and timeless style. With a legacy that spans over a century, Alfa Romeo is renowned for producing elegant and sporty vehicles that evoke passion and excitement. From their sleek design to their exhilarating performance, Alfa Romeo cars embody the perfect balance between craftsmanship and driving pleasure.",
                           Image = "4.jpg",
                           Price = 110000,
                           TopSellingCars = true,
                           Available = true,
                           Category = Categories[gasolineCars]
                       },
                    new Car
                         {
                             Name = "Porsche Taycan",
                             ShortDesc = "High-performance, electric",
                             LongDesc = "The Porsche Taycan is a high-performance electric car that combines Porsche's legendary driving dynamics with zero-emission capabilities. With its striking design, blistering acceleration, and impressive driving range, the Taycan offers a thrilling and sustainable driving experience. Experience the future of sports cars with the Porsche Taycan.",
                             Image = "5.jpg",
                             Price = 90000,
                             TopSellingCars = false,
                             Available = true,
                             Category = Categories[electricCars]
                         },

                    new Car
                    {
                        Name = "Audi e-tron GT",
                        ShortDesc = "Stylish, electric",
                        LongDesc = "The Audi e-tron GT is a stylish and luxurious electric car that combines Audi's renowned craftsmanship with zero-emission mobility. With its sleek and aerodynamic design, powerful electric drivetrain, and advanced technologies, the e-tron GT delivers exhilarating performance and a refined driving experience. Experience the future of electric luxury with the Audi e-tron GT.",
                        Image = "6.jpg",
                        Price = 95000,
                        TopSellingCars = false,
                        Available = true,
                        Category = Categories[electricCars]
                    },

                    new Car
                    {
                        Name = "Jaguar I-PACE",
                        ShortDesc = "Elegant, all-electric",
                        LongDesc = "The Jaguar I-PACE is an elegant all-electric SUV that combines Jaguar's iconic design with zero-emission performance. With its spacious interior, versatile capabilities, and advanced electric drivetrain, the I-PACE offers a perfect blend of luxury, practicality, and sustainability. Embrace the future of electric mobility with the Jaguar I-PACE.",
                        Image = "7.jpg",
                        Price = 80000,
                        TopSellingCars = false,
                        Available = true,
                        Category = Categories[electricCars]
                    },

                    new Car
                    {
                        Name = "Subaru WRX STI",
                        ShortDesc = "Agile, rally-inspired",
                        LongDesc = "The Subaru WRX STI is an agile and rally-inspired sports sedan that offers a thrilling driving experience. With its iconic hood scoop, aggressive body lines, and signature wing, the WRX STI showcases its performance-oriented design. Powered by a turbocharged engine and equipped with Subaru's legendary Symmetrical All-Wheel Drive system, the WRX STI delivers exceptional handling and traction, allowing you to conquer any road or track with confidence.",
                        Image = "9.jpg",
                        Price = 35000,
                        TopSellingCars = false,
                        Available = true,
                        Category = Categories[gasolineCars]
                    },

                    new Car
                    {
                        Name = "Ford Mustang GT",
                        ShortDesc = "Muscular, iconic",
                        LongDesc = "The Ford Mustang GT is a muscular and iconic American sports car that embodies power and performance. With its legendary pony car design, aggressive front grille, and sculpted body, the Mustang GT turns heads wherever it goes. Under the hood, it packs a potent V8 engine, delivering exhilarating acceleration and a thrilling exhaust note. Experience the freedom of the open road and the thrill of the Mustang GT's raw power.",
                        Image = "8.jpg",
                        Price = 40000,
                        TopSellingCars = false,
                        Available = true,
                        Category = Categories[gasolineCars]
                    },

                    new Car
                    {
                        Name = "Chevrolet Camaro ZL1",
                        ShortDesc = "Track-ready, high-performance",
                        LongDesc = "The Chevrolet Camaro ZL1 is a track-ready, high-performance sports car that offers blistering speed and exhilarating performance. With its bold and aerodynamic design, the ZL1 commands attention on the road. Powered by a supercharged V8 engine and equipped with advanced performance features, such as Brembo brakes and Magnetic Ride Control, the Camaro ZL1 delivers exceptional handling and track capabilities, providing an adrenaline-pumping driving experience.",
                        Image = "10.jpg",
                        Price = 60000,
                        TopSellingCars = false,
                        Available = true,
                        Category = Categories[gasolineCars]
                    },

                    new Car
                    {
                        Name = "Nissan GT-R",
                        ShortDesc = "Legendary, supercar performance",
                        LongDesc = "The Nissan GT-R is a legendary sports car known for its supercar performance and cutting-edge technology. With its striking design and aerodynamic body, the GT-R is a true head-turner. Beneath the hood lies a twin-turbocharged V6 engine, delivering jaw-dropping acceleration and precise handling. Whether on the track or the street, the GT-R offers an unmatched driving experience that combines power, control, and innovation.",
                        Image = "11.jpg",
                        Price = 110000,
                        TopSellingCars = false,
                        Available = true,
                        Category = Categories[gasolineCars]
                    },

                    new Car
                    {
                        Name = "Acura NSX",
                        ShortDesc = "Hybrid supercar",
                        LongDesc = "The Acura NSX is a hybrid supercar that blends exhilarating performance with advanced hybrid technology. With its low-slung and aerodynamic design, the NSX exudes speed and precision. Powered by a hybrid drivetrain consisting of a twin-turbocharged V6 engine and electric motors, the NSX delivers lightning-fast acceleration and exceptional handling. Experience the perfect fusion of power, efficiency, and craftsmanship with the Acura NSX.",
                        Image = "13.jpg",
                        Price = 160000,
                        TopSellingCars = false,
                        Available = true,
                        Category = Categories[gasolineCars]
                    }

                );
            }

            context.SaveChanges();
        }
        private static Dictionary<string, Category> Category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (Category == null)
                {
                    var list = new Category[]
                    {
                        new Category {CategoryName = electricCars, Desc = "A modern and economical mode of transportation"},
                        new Category {CategoryName = gasolineCars, Desc = "Internal combustion engine vehicles"}
                    };

                    Category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        Category.Add(el.CategoryName, el);

                }

                return Category;
            } 
        }
    }
}
