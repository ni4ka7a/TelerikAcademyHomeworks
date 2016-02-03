namespace _02.WebCalculator.Utilities
{
    using _02.WebCalculator.ViewModels;

    public class Convertor
    {
        public static CalculatorResultViewModel Convert(decimal quantity, string type, string kilo)
        {
            var deviser = int.Parse(kilo);
            var model = new CalculatorResultViewModel();

            switch (type)
            {
                case "b":
                    model.Bit = (quantity).ToString("G6");
                    model.Byte = (quantity / 8).ToString("G6");
                    model.Kilobit = (quantity / deviser).ToString("G6");
                    model.Kilobyte = (quantity / (8 * deviser)).ToString("G6");
                    model.Megabit = (quantity / (deviser * deviser)).ToString("G6");
                    model.Megabyte = (quantity / (8 * deviser * deviser)).ToString("G6");
                    break;

                case "B":
                    model.Byte = quantity.ToString("G6");
                    model.Kilobit = (quantity / (deviser / 8)).ToString("G6");
                    model.Kilobyte = (quantity / deviser).ToString("G6");
                    model.Megabit = (quantity / ((deviser * deviser) / 8)).ToString("G6");
                    model.Megabyte = (quantity / (deviser * deviser)).ToString("G6");
                    model.Bit = (quantity * 8).ToString("G6");
                    break;

                case "Kb":
                    model.Kilobit = quantity.ToString("G6");
                    model.Kilobyte = (quantity / 8).ToString("G6");
                    model.Megabit = (quantity / deviser).ToString("G6");
                    model.Megabyte = (quantity / (deviser * 8)).ToString("G6");
                    model.Bit = (quantity * deviser).ToString("G6");
                    model.Byte = (quantity * (deviser / 8)).ToString("G6");
                    break;

                case "KB":
                    model.Kilobyte = quantity.ToString("G6");
                    model.Megabit = (quantity / (deviser / 8)).ToString("G6");
                    model.Megabyte = (quantity / deviser).ToString("G6");
                    model.Bit = (quantity * (deviser * 8)).ToString("G6");
                    model.Byte = (quantity * deviser).ToString("G6");
                    model.Kilobit = (quantity * 8).ToString("G6");

                    break;
                case "Mb":
                    model.Megabit = quantity.ToString("G6");
                    model.Megabyte = (quantity / 8).ToString("G6");
                    model.Bit = (quantity * deviser * deviser).ToString("G6");
                    model.Byte = (quantity * ((deviser * deviser) / 8)).ToString("G6");
                    model.Kilobit = (quantity * deviser).ToString("G6");
                    model.Kilobyte = (quantity * (deviser / 8)).ToString("G6");
                    break;

                case "MB":
                    model.Megabyte = quantity.ToString("G6");
                    model.Bit = (quantity * deviser * deviser * 8).ToString("G6");
                    model.Byte = (quantity * deviser * deviser).ToString("G6");
                    model.Kilobit = (quantity * deviser * 8).ToString("G6");
                    model.Kilobyte = (quantity * deviser).ToString("G6");
                    model.Megabit = (quantity * 8).ToString("G6");
                    break;
                default:
                    break;
            }


            return model;
        }
    }
}