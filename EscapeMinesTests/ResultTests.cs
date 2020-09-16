using Xunit;
using Shouldly;
using EscapeMinesLib;
namespace EscapeMinesTests
{
    public class ResultTests
    {
        [Fact]
        public void GetDescriptionExtensionMethodWorks()
        {
            Result.Success.GetDescription().ShouldBe("The turtle has found the exit point.");
        }
    }
}
