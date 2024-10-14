namespace Ametrin.Guard.Test;

public sealed class Tests
{
    [Test]
    public async Task Test_ThrowIfNull()
    {
        await Assert.That(() => Guard.ThrowIfNull((string?)null)).Throws<ArgumentNullException>();
        await Assert.That(() => Guard.ThrowIfNull("")).ThrowsNothing();
    }
    
    [Test]
    public async Task Test_ThrowIfNullOrEmpty()
    {   
        await Assert.That(() => Guard.ThrowIfNullOrEmpty(null)).Throws<ArgumentNullException>();
        await Assert.That(() => Guard.ThrowIfNullOrEmpty("")).Throws<ArgumentNullException>();
        await Assert.That(() => Guard.ThrowIfNullOrEmpty(" ")).ThrowsNothing();
    }
    
    [Test]
    public async Task Test_ThrowIfNullOrWhiteSpace()
    {
        await Assert.That(() => Guard.ThrowIfNullOrWhiteSpace(null)).Throws<ArgumentNullException>();
        await Assert.That(() => Guard.ThrowIfNullOrWhiteSpace("")).Throws<ArgumentNullException>();
        await Assert.That(() => Guard.ThrowIfNullOrWhiteSpace("   ")).Throws<ArgumentNullException>();
        await Assert.That(() => Guard.ThrowIfNullOrWhiteSpace("hello world")).ThrowsNothing();
    }
}
