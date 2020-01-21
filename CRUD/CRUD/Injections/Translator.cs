using Google.Cloud.Translation.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Injections
{
    public interface ITranslator
    {
        //method for translating html
        string TranslateText(string text, string language);

        //method for translating text
        string TranslateHtml(string text, string language);
    }

    public class Translator : ITranslator
    {
        private readonly TranslationClient client;

        public Translator()
        {
            client = TranslationClient.Create();
        }

        //method for translating html
        public string TranslateHtml(string text, string language)
        {
            var response = client.TranslateHtml(text, language);
            return response.TranslatedText;
        }

        //method for translating text
        public string TranslateText(string text, string language)
        {
            var response = client.TranslateText(text, language);
            return response.TranslatedText;
        }
    }

}
