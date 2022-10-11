﻿// This file was auto-generated by ML.NET Model Builder.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using Microsoft.ML;

namespace StartML
{
    public partial class TestModel
    {
        /// <summary>
        /// Retrains model using the pipeline generated as part of the training process. For more information on how to load data, see aka.ms/loaddata.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainPipeline(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(@"Spectral Class", @"Spectral Class", outputKind: OneHotEncodingEstimator.OutputKind.Indicator)      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"Temperature (K)", @"Temperature (K)"),new InputOutputColumnPair(@"Luminosity(L/Lo)", @"Luminosity(L/Lo)"),new InputOutputColumnPair(@"Radius(R/Ro)", @"Radius(R/Ro)"),new InputOutputColumnPair(@"Absolute magnitude(Mv)", @"Absolute magnitude(Mv)")}))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"Star color",outputColumnName:@"Star color"))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"Spectral Class",@"Temperature (K)",@"Luminosity(L/Lo)",@"Radius(R/Ro)",@"Absolute magnitude(Mv)",@"Star color"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName:@"Star type",inputColumnName:@"Star type"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.OneVersusAll(binaryEstimator:mlContext.BinaryClassification.Trainers.FastTree(new FastTreeBinaryTrainer.Options(){NumberOfLeaves=4,MinimumExampleCountPerLeaf=20,NumberOfTrees=4,MaximumBinCountPerFeature=255,FeatureFraction=1,LearningRate=0.1,LabelColumnName=@"Star type",FeatureColumnName=@"Features"}),labelColumnName: @"Star type"))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName:@"PredictedLabel",inputColumnName:@"PredictedLabel"));

            return pipeline;
        }
    }
}