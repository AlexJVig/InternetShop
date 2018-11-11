using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Runtime.Api;

namespace InternetShop.ML
{
    public class ProductsVector
    {
        [Column("0")]
        public float Forks;

        [Column("1")]
        public float Spoons;

        [Column("2")]
        public float Fork;

        [Column("3")]
        public float Knives;

        [Column("4")]
        public float GrannySmithApples;

        [Column("5")]
        public float RedDeliciousApples;

        [Column("6")]
        public float McIntoshApples;

        [Column("7")]
        public float WoodenTable;

        [Column("8")]
        public float WoodenChair;

        [Column("9")]
        public float AntiqueSwedishMarbleCupboard;

        [Column("10")]
        public float CocalColaBottle;

        [Column("11")]
        public float TeaBottle;

        [Column("12")]
        public float NesteaBottle;

        [Column("13")]
        public float SpriteBottle;

        [Column("14")]
        public float FantaBottle;

        [Column("15")]
        public float Entricote;

        [Column("16")]
        public float Sinta;

        [Column("17")]
        public float AbsolutVodka;

        [Column("18")]
        public float Jagermeister;

        [Column("19")]
        public float RedLabel;

        [Column("20")]
        public float JackDaniels;
    }
}
