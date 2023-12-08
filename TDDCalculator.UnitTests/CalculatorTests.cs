namespace TDDCalculator.UnitTests;

[TestClass]
public class CalculatorTests
{
    private Calculator _calculator;

    [TestInitialize]
    public void Init()
    {
        _calculator = new Calculator();
    }

    [DataTestMethod]
    [DataRow("", true)]
    [DataRow(null, true)]
    [DataRow("f", false)]
    [DataRow("1", false)]
    [DataRow("+", false)]
    [DataRow("d+4Fldzokl8bG=.;,d/-1", false)]
    [DataRow("false", false)]
    [DataRow("0", false)]
    [DataRow("null", false)]
    public void IsStringIsEmpty_Input_ReturnsBooleanIndicatesIfStringIsEmptyOrNot(
        string input,
        bool expectedResult
    )
    {
        Assert.AreEqual(expectedResult, _calculator.IsStringIsEmpty(input));
    }

    [DataTestMethod]
    [DataRow("")]
    [DataRow(null)]
    public void GetDelimiterFromString_EmptyInput_ThrowsArgumentNullException(string input)
    {
        Assert.ThrowsException<ArgumentNullException>(() => _calculator.GetDelimiterFromString(input));
    }

    [DataTestMethod]
    [DataRow("", "//")]
    [DataRow(null, "//")]
    public void IsStringStartByValue_EmptyInput_ThrowsArgumentNullException(string input, string value)
    {
        Assert.ThrowsException<ArgumentNullException>(() => _calculator.IsStringStartByValue(input, value));
    }

    [DataTestMethod]
    [DataRow("//*1*2", "")]
    [DataRow("//*1*2", null)]
    public void IsStringStartByValue_EmptyValue_ThrowsArgumentNullException(string input, string value)
    {
        Assert.ThrowsException<ArgumentNullException>(() => _calculator.IsStringStartByValue(input, value));
    }

    [DataTestMethod]
    [DataRow("//*", "//*1*2")]
    [DataRow("/", "//")]
    public void IsStringStartByValue_ValueIsGreaterThanInput_ThrowsArgumentException(string input, string value)
    {
        Assert.ThrowsException<ArgumentException>(() => _calculator.IsStringStartByValue(input, value));
    }

    [DataTestMethod]
    [DataRow("//*1*2", "//", true)]
    [DataRow("//*1*2", "/", true)]
    [DataRow("//*1*2", "///", false)]
    [DataRow("//*1*2", "*", false)]
    [DataRow("1*2", "/", false)]
    [DataRow("1*2", "1", true)]
    public void IsStringStartByValue_Input_ReturnsBooleanIndicatesIfStringStartByValue(
        string input,
        string value,
        bool expectedResult
    )
    {
        Assert.AreEqual(expectedResult, _calculator.IsStringStartByValue(input, value));
    }

    [DataTestMethod]
    [DataRow("//*1*2", "//", '*')]
    [DataRow("//*1*2", "/", '/')]
    [DataRow("//*1*2", "//*", '1')]
    public void GetDelimiterFromString_Input_ReturnsCorrectDelimiter(
        string input,
        string stringToSpecifyAnotherDelimiter,
        char expectedResult
    )
    {
        Calculator calculator = new Calculator();

        calculator.StringToSpecifyAnotherDelimiter = stringToSpecifyAnotherDelimiter;

        Assert.AreEqual(expectedResult, calculator.GetDelimiterFromString(input));
    }

    [DataTestMethod]
    [DataRow("//*1*2", ',')]
    [DataRow("1,2,3", '*')]
    public void GetRealInput_DelimiterIsNotPresentInInput_ThrowsArgumentException(string input, char delimiter)
    {
        Calculator calculator = new Calculator();

        calculator.Delimiter = delimiter;

        Assert.ThrowsException<ArgumentException>(() => calculator.GetRealInput(input));
    }

    [DataTestMethod]
    [DataRow("//*1*2", '*', "//", "1*2")]
    [DataRow("1,2,3", ',', "//", "1,2,3")]
    public void GetRealInput_Input_ReturnsCorrectRealInput(
        string input,
        char delimiter,
        string stringToSpecifyAnotherDelimiter,
        string expectedResult
    )
    {
        Calculator calculator = new Calculator();

        calculator.Delimiter = delimiter;
        calculator.StringToSpecifyAnotherDelimiter = stringToSpecifyAnotherDelimiter;

        Assert.AreEqual(expectedResult, calculator.GetRealInput(input));
    }

    [DataTestMethod]
    public void ExtractNumbersFromString_Input_ReturnsListOfNumbers(string input, int[] expectedResult)
    {
    }
}