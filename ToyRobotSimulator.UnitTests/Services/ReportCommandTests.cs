namespace ToyRobotSimulator.UnitTests.Services;

public class ReportCommandTests
{
    private readonly Mock<IMapService> _mapService;
    public ReportCommandTests()
    {
        _mapService = new Mock<IMapService>();
    }

    [Fact]
    public async Task OutoutAsync()
    {
        //Arrange
        _mapService.Setup(i => i.ReportAsync(It.IsAny<CancellationToken>())).ReturnsAsync((1, 1, Direction.NORTH));
        var command = new ReportCommand(_mapService.Object);

        //Act
        var r = await command.OutputAsync(default);

        //Assert
        Assert.Equal("1,1,NORTH", r);
    }
}


