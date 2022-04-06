using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using ConsoleAppProject.Helpers;
// The units for measurement.
public enum UnitSystems
{
    [Display(Name = "Imperial")]
    Imperial,
    [Display(Name = "Metric")]
    Metric
}

public class BMICalculator
{
    // Constants for W.H.O weight status (in BMI kg/m2)
    // Maximum thresholds.
    public const double UNDERWEIGHT_MAX = 18.5;
    public const double NORMAL_MAX = 24.9;
    public const double OVERWEIGHT_MAX = 29.9;
    public const double OBESE_I_MAX = 34.9;
    public const double OBESE_II_MAX = 39.9;
    // Minimum threshold.
    public const double OBESE_III_MIN = 40.0;

    // Properties for height and weight in imperial unita.
    // Weight = stones (st) and pounds (Ib)
    // Height = feet (ft) and inches (in)
    public double Stones { get; set; }
    public double Pounds { get; set; }
    public double Feet { get; set; }
    public double Inches { get; set; }

    // Properties for height and weight in etric units.
    // Weight = kilograms (kg); height = centimetres (cm)
    public double Kilograms { get; set; }
    
    public double Centimetres { get; set; }

    // Properties for user's BMI.
    public double User_BMI { get; set; }

    /// <summary>
    /// Outputs a heading for the App, then shows the user's BMI, weight status and
    /// health risk information after the calculation process has been completed.
    /// </summary>

    public void OutputBMI()
    {
        ConsoleHelper.OutputHeading("Body Mass Index Calculator");

        SelectUnits();

        Console.WriteLine(DisplayWeightStatus());
        Console.WriteLine(DisplayRiskMessage());

        ExitDecision();
    }

    /// <summary>
    /// Prompts the user to select which type they would like to use.
    /// (1 for imprial; 2 for metric)
    /// </summary>
    private void SelectUnits()
    {
        Console.WriteLine(" Which unit type would you like to use?");

        string[] choices = { EnumHelper<UnitSystems>.GetName(UnitSystems.Imperial),
                EnumHelper < UnitSystems >.GetName(UnitSystems.Metric) };

        int choice = ConsoleHelper.SelectChoice(choices);

        if (choice == 1)
        {
            //GetImperialInput();
            //CalculateImperial();

        }
        else if (choice == 2)
        {
            GetMetricInput();
            CalculateMetric();
        }
        else
        {
            Console.WriteLine(" Invalid choice. Please try again.");
            SelectUnits();
        }
    }
    /// <summary>
    /// Prompts the user to enter their weight and height in Imperial units
    /// through the console.
    /// </summary>
    public void GetMetricInput()
    {
        Kilograms = ConsoleHelper.InputNumber(" Please enter your weight " +
            "in kilograms > ", 0, 300);
    }

    /// <summary>
    /// Calculates the user's BMI based on the metric ynits they've
    /// entered.
    /// </summary>
    public void CalculateMetric()
    {
        User_BMI = Kilograms / Math.Pow((Centimetres / 100), 2);
    }

    /// <summary>
    /// Determines the weight status of the user based on tehir BMI and the W.H.O's
    /// weight status guidlines.
    /// </summary>
    /// <returns>A string with the user's current weight status.</returns>
    public string DisplayWeightStatus()
    {
        StringBuilder message = new StringBuilder("\n\t");

        if (User_BMI < UNDERWEIGHT_MAX)
        {
            message.Append($"Your BMI is {User_BMI:0.0}. " + $"You are underweight.");
        }
        else if ((User_BMI > UNDERWEIGHT_MAX) && (User_BMI <= NORMAL_MAX))
        {
            message.Append($"Your BMI is {User_BMI:0.0}. " + $"You are in the normal range.");
        }
        else if ((User_BMI > NORMAL_MAX) && (User_BMI <= OVERWEIGHT_MAX))
        {
            message.Append($"Your BMI is {User_BMI:0.0}. " + $"You are overweight.");
        }
        else if ((User_BMI > OVERWEIGHT_MAX) && (User_BMI <= OBESE_I_MAX))
        {
            message.Append($"Your BMI is {User_BMI:0.0}. " + $"You are obese class I.");
        }
        else if ((User_BMI > OBESE_I_MAX) && (User_BMI <= OBESE_III_MIN))
        {
            message.Append($"Your BMI is {User_BMI:0.0}. " + $"You are obese class II.");
        }
        else if (User_BMI >= OBESE_III_MIN)
        {
            message.Append($"Your BMI is {User_BMI:0.0}. " + $"You are obese class III.");
        }
        return message.ToString();
    }
    /// <summary>
    /// Outputs a message regarding Black, Asian and other minority etnic
    /// groups having a higher health risk.
    /// </summary>
    public string DisplayRiskMessage()
    {
        StringBuilder message = new StringBuilder("\n\t");

        message.Append("If you are Black, Asian, or in another minority " +
            "ethnic group, you have a higher health risk.");
        message.Append("\n\tAdults with BMI od 23.0 or over " + "are at increased risk.");
        message.Append("\n\tAdults with a BMI of 27.5 or over " + "are at high risk.");

            return message.ToString();
    }
    /// <summary>
    /// Gives the user the option to either exit the application or return
    /// to the menu to calculate another BMI result.
    /// </summary>
    private void ExitDecision()
    {
        Console.Write("\n\tWould you like to exit? Selecting 'b' will return "
            + "you to the menu (y/n) > ");
    }
}
