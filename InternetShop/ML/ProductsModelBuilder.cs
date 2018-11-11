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
        // Make sure the 'Copy to Output Directory' property of the text file
        // is set to 'Copy always' (text file should just be imported
        // to the project directiry here
        public const string datapath = "./traningData.csv";
        public const string modelpath = "./Model.zip";
        public const string testdatapath = "./testData.csv";

        public static async Task<PredictionModel<ProductsVector, ProductPrediction>> Train()
        {
            // Create a pipeline to load the apartments data
            var pipeline = new LearningPipeline
            {
                // Import the data to the pipeline
                new TextLoader(datapath).CreateFrom<ProductsVector>(separator: ','),

                // Define the price column as the one to be predicted
                new ColumnCopier(("Price", "Label")),

                // Assign the boolean features a numeric value
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

                // Put all features into a vector
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

                // Add  learning algorithm to the pipeline 
                new FastTreeRegressor()
            };

            // Train the model according to the information in the pipeline
            PredictionModel<ProductsVector, ProductPrediction> model = pipeline.Train<ProductsVector, ProductPrediction>();

            // Save the model to a file.
            // The method is async so the 'await' clause  tells it not to continue
            // until the save finishes, since the save is synchronous
            // In the meantime, control returns to the caller of this async method.
            await model.WriteAsync(modelpath);

            // After the save is finished return the model
            return model;
        }

        public static string Evaluate(PredictionModel<ProductsVector, ProductPrediction> model)
        {
            // Load the test data from a file
            var testData = new TextLoader(testdatapath).CreateFrom<ProductsVector>(separator: ',');

            // Make an evaluator matrix
            var evaluator = new RegressionEvaluator();
            RegressionMetrics metrics = evaluator.Evaluate(model, testData);

            // Print the RMS and RSquared are evaluation matrixes of the regression model
            // RMS: The lower it is, the better the model is
            // RSquared: takes values between 0 and 1. The closer its value is to 1, the better the model is. 
            return ($"Rms = {metrics.Rms}" + $", RSquared = {metrics.RSquared}");
        }
    }
}
