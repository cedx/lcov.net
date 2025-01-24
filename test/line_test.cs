namespace belin.lcov;

[TestClass]
public sealed class LineCoverageTest {

	[TestMethod]
	public void TestToString() {
		var data = new LineData { ExecutionCount = 3, LineNumber = 127 };
		AreEqual("LF:0\nLH:0", new LineCoverage().ToString());
		AreEqual($"{data}\nLF:23\nLH:11", new LineCoverage { Data = [data], Found = 23, Hit = 11 }.ToString());
	}
}

[TestClass]
public sealed class LineDataTest {

	[TestMethod]
	public void TestToString() {
		var data = new LineData { Checksum = "ed076287532e86365e841e92bfc50d8c", ExecutionCount = 3, LineNumber = 127 };
		AreEqual("DA:0,0", new LineData().ToString());
		Console.WriteLine(new LineData().Checksum.Length);
		AreEqual("DA:127,3,ed076287532e86365e841e92bfc50d8c", data.ToString());
	}
}
