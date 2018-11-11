using Microsoft.ML.Legacy;
using Microsoft.ML.Legacy.Data;
using Microsoft.ML.Legacy.Models;
using Microsoft.ML.Legacy.Trainers;
using Microsoft.ML.Legacy.Transforms;
using System.Threading.Tasks;


namespace InternetShop.ML
{
    public class ProductsModelBuilder
    {
        public const string datapath = "./traningData.csv";
        public const string modelpath = "./Model.zip";
        public const string testdatapath = "./testData.csv";

        public static async Task<PredictionModel<ProductsVector, ProductPrediction>> Train()
        {
            var pipeline = new LearningPipeline
            {
                new TextLoader(datapath).CreateFrom<ProductsVector>(separator: ','),
                new ColumnCopier(("Price", "Label")),
                new CategoricalOneHotVectorizer("Forks",
                                                "Spoons",
                                                "Fork",
                                                "Knives",
                                                "GrannySmithApples",
                                                "RedDeliciousApples",
                                                "McIntoshApples",
                                                "WoodenTable",
                                                "WoodenChair",
                                                "AntiqueSwedishMarbleCupboard",
                                                "CocalColaBottle",
                                                "TeaBottle",
                                                "NesteaBottle",
                                                "SpriteBottle",
                                                "FantaBottle",
                                                "Entricote",
                                                "Sinta",
                                                "AbsolutVodka",
                                                "Jagermeister",
                                                "RedLabel",
                                                "JackDaniels",
                                                "Price"),
                new ColumnConcatenator("Forks",
                                    "Spoons",
                                    "Fork",
                                    "Knives",
                                    "GrannySmithApples",
                                    "RedDeliciousApples",
                                    "McIntoshApples",
                                    "WoodenTable",
                                    "WoodenChair",
                                    "AntiqueSwedishMarbleCupboard",
                                    "CocalColaBottle",
                                    "TeaBottle",
                                    "NesteaBottle",
                                    "SpriteBottle",
                                    "FantaBottle",
                                    "Entricote",
                                    "Sinta",
                                    "AbsolutVodka",
                                    "Jagermeister",
                                    "RedLabel",
                                    "JackDaniels",
                                    "Price"),
                new FastTreeRegressor()
            };
            
            PredictionModel<ProductsVector, ProductPrediction> model = pipeline.Train<ProductsVector, ProductPrediction>();
            await model.WriteAsync(modelpath);
            return model;
        }

        public static string Evaluate(PredictionModel<ProductsVector, ProductPrediction> model)
        {
            var testData = new TextLoader(testdatapath).CreateFrom<ProductsVector>(separator: ',');
            var evaluator = new RegressionEvaluator();
            RegressionMetrics metrics = evaluator.Evaluate(model, testData);
            return ($"Rms = {metrics.Rms}" + $", RSquared = {metrics.RSquared}");
        }
    }
}
