public static class MemoryStreamExtensions
{
    public static BinaryWriter CreateWriter(this MemoryStream ms)
    {
        return new BinaryWriter(ms, System.Text.Encoding.UTF8, true);
    }

    public static BinaryReader CreateReader(this MemoryStream ms)
    {
        return new BinaryReader(ms, System.Text.Encoding.UTF8, true);
    }

    public static void Write(this BinaryWriter writer, DateTimeOffset value)
    {
        writer.Write(value.ToUnixTimeMilliseconds());
    }

    public static DateTimeOffset ReadDateTimeOffset(this BinaryReader reader)
    {
        var unixTimeMilliseconds = reader.ReadInt64();
        return DateTimeOffset.FromUnixTimeMilliseconds(unixTimeMilliseconds);
    }

    public static void Write(this BinaryWriter writer, string value)
    {
        writer.Write(value ?? "");
    }

    public static string ReadString(this BinaryReader reader)
    {
        return reader.ReadString();
    }
}