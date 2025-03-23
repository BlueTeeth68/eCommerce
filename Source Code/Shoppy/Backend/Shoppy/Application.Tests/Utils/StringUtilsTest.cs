using Application.Utils;

namespace Application.Tests.Utils;

public class StringUtilsTest
{
    [Theory]
    [InlineData("     ")]
    [InlineData(null)]
    public void FormatNameMustReturnEmpty(string? input)
    {
        var result = StringUtils.FormatName(input);
        Assert.Empty(result);
    }

    [Theory]
    [InlineData("ngUyễN    vĂn A    ", "Nguyễn Văn A")]
    [InlineData("   Trần  VĂN sÁnG  ", "Trần Văn Sáng")]
    public void FormatNameMustReturnFormattedString(string input, string expected)
    {
        var result = StringUtils.FormatName(input);
        Assert.Equal(result, expected);
    }
}