namespace StringsOperations
{
    public class StringsService : IStringsService
    {

        public int NumberOfContains(string subString, string text)
        {
            var conteinsCounter = 0;
            var index = text.IndexOf(subString);

            while (index != -1)
            {
                conteinsCounter++;
                index = text.IndexOf(subString);
            }


            return conteinsCounter;
        }
    }
}
