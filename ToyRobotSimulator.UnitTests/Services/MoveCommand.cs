namespace ToyRobotSimulator.UnitTests.Services;

public class MoveCommandTests
{
    private readonly Mock<IMapService> _mapService;
    public MoveCommandTests()
    {
        _mapService = new Mock<IMapService>();
    }

    [Fact]
    public async Task IsCommandAsync()
    {
        //Arrange
        _mapService.Setup(i=>i.CanMoveAsync(It.IsAny<CancellationToken>())).ReturnsAsync(true);
        var command = new MoveCommand(_mapService.Object);

        //Act
        var r1 = await command.IsCommandAsync("", default);
        var r2 = await command.IsCommandAsync("MOVE", default);
        var r3 = await command.IsCommandAsync(" MOVE ", default);

        //Assert
        Assert.False(r1);
        Assert.True(r2);
        Assert.False(r3);
    }
}
