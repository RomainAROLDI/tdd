namespace TDDCalculator;

public class Calculator
{
    private char _delimiter = ',';
    private string _stringToSpecifyAnotherDelimiter = "//";

    public char Delimiter
    {
        get { return _delimiter; }
        set { _delimiter = value; }
    }

    public string StringToSpecifyAnotherDelimiter
    {
        get { return _stringToSpecifyAnotherDelimiter; }
        set { _stringToSpecifyAnotherDelimiter = value; }
    }

    public bool IsStringIsEmpty(string input)
    {
        return string.IsNullOrEmpty(input);
    }

    /*public string GetDelimiterFromString(string input)
    {
        if (IsStringIsEmpty(input)) throw new ArgumentNullException();

        return "";
    }*/

    public bool IsStringStartByValue(string input, string value)
    {
        if (IsStringIsEmpty(input) || IsStringIsEmpty(value)) throw new ArgumentNullException();

        if (input.Length < value.Length) throw new ArgumentException();

        return input.StartsWith(value);
    }

    public char GetDelimiterFromString(string input)
    {
        if (IsStringIsEmpty(input)) throw new ArgumentNullException();

        if (IsStringStartByValue(input, _stringToSpecifyAnotherDelimiter))
        {
            _delimiter = char.Parse(input.Substring(_stringToSpecifyAnotherDelimiter.Length, 1));
        }

        return _delimiter;
    }

    public string GetRealInput(string input)
    {
        if (!input.Contains(Delimiter)) throw new ArgumentException();

        return "";
    }
}