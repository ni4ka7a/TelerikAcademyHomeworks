namespace DayOfWeek
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDayService
    {
        [OperationContract]
        string GetDayOfWeek(DateTime date);
    }
}
