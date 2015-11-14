namespace StringsOperations
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IStringsService
    {
        [OperationContract]
        int NumberOfContains(string subString, string text);
    }
}
