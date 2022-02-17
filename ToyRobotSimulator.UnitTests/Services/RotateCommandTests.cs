namespace ToyRobotSimulator.UnitTests.Services;

public class RotateCommandTests
{
    private readonly Mock<IMapService> _mapService;
    public RotateCommandTests()
    {
        _mapService = new Mock<IMapService>();
    }

    [Fact]
    public async Task IsCommandAsync()
    {
        //Arrange
        _mapService.Setup(i => i.ReportAsync(It.IsAny<CancellationToken>())).ReturnsAsync((1, 1, Direction.NORTH));
        var command = new RotateCommand(_mapService.Object);

        //Act
        var r1 = await command.IsCommandAsync("LEFT", default);
        var r2 = await command.IsCommandAsync("RIGHT", default);
        var r3 = await command.IsCommandAsync("LEFTRIGHT", default);

        //Assert
        Assert.True(r1);
        Assert.True(r2);
        Assert.False(r3);
    }
}


