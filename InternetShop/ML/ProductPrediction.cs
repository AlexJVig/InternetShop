using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Runtime.Api;

namespace InternetShop.ML
{
    public class ProductPrediction
    {
        [ColumnName("Score")]
        public float Price;
    }
}
