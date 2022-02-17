namespace ToyRobotSimulator.UnitTests.Services;

public class PlaceCommandTests
{
    private readonly Mock<IMapService> _mapService;
    public PlaceCommandTests()
    {
        _mapService = new Mock<IMapService>();
    }

    [Fact]
    public async Task IsCommandAsync()
    {
        //Arrange
        _mapService.Setup(i => i.CanSetAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
        var command = new PlaceCommand(_mapService.Object);

        //Act
        var r1 = await command.IsCommandAsync("PLACE 0,0,NORTH", default);
        var r2 = await command.IsCommandAsync("PLACE ,0,SOUTH", default);
        var r3 = await command.IsCommandAsync("PLACE 0,,WEST", default);
        var r4 = await command.IsCommandAsync("PLACE 0,0,NORTHWEST", default);

        //Assert
        Assert.True(r1);
        Assert.False(r2);
        Assert.False(r3);
        Assert.False(r4);
    }
}


