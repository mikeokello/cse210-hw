namespace JournalProgram
{
    public class Entry
    {
        private string _date;
        private string _prompt;
        private string _response;

        public Entry(string date, string prompt, string response)
        {
            _date = date;
            _prompt = prompt;
            _response = response;
        }

        public string ToDisplayString()
        {
            return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}";
        }

        public string ToFileString()
        {
            return $"{_date}~|~{_prompt}~|~{_response}";
        }
    }
}
