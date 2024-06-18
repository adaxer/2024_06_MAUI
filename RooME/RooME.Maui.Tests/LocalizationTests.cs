
using FluentAssertions;
using RooME.Loc;
using System.Globalization;

namespace RooME.Maui.Tests;

public class LocalizationTests
{
	[Theory]
    [InlineData("en-US", "RooME Application")]
	[InlineData("de", "RooME Anwendung")]
    [InlineData("fr", "RooME Suite")]
	public void Designer_WithGivenLanguage_GivesCorrectValue(string culture, string expected)
	{
		// Arrange
		Strings.Culture = new CultureInfo(culture);

		// Act
		string result = Strings.UI_AppTitle;

		// Assert
		result.Should().Be(expected);
	}
}
