﻿
// This file was auto-generated by ML.NET Model Builder. 

using StartML;

// Create single instance of sample data from first line of dataset for model input
TestModel.ModelInput sampleData = new TestModel.ModelInput()
{
    Temperature__K_ = 3042F,
    Luminosity_L_Lo_ = 5F,
    Radius_R_Ro_ = 1542F,
    Absolute_magnitude_Mv_ = 166F,
    Star_color = @"Red",
    Spectral_Class = @"M",
};

// Make a single prediction on the sample data and print results
var predictionResult = TestModel.Predict(sampleData);

Console.WriteLine("Using model to make single prediction -- Comparing actual Star_type with predicted Star_type from sample data...\n\n");


Console.WriteLine($"Temperature__K_: {3042F}");
Console.WriteLine($"Luminosity_L_Lo_: {5F}");
Console.WriteLine($"Radius_R_Ro_: {1542F}");
Console.WriteLine($"Absolute_magnitude_Mv_: {166F}");
Console.WriteLine($"Star_type: {0F}");
Console.WriteLine($"Star_color: {@"Red"}");
Console.WriteLine($"Spectral_Class: {@"M"}");


Console.WriteLine($"\n\nPredicted Star_type: {predictionResult.PredictedLabel}\n\n");
Console.WriteLine("=============== End of process, hit any key to finish ===============");
Console.ReadKey();
