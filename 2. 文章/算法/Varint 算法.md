#algorithm

用于压缩小整数，比如int a = 3，实质上只需要1b即可，不需要4b

``` csharp
public static void WriteVarint(byte[] dst, ulong data, ref int offset) {
    while(data >= 0x80) {
        dst[offset++] = (byte)(data | 0x80);
        data >>= 7;
    }
    dst[offset++] = (byte)data;
}

public static ulong ReadVarint(byte[] src, ref int offset) {
    ulong data = 0;
    byte b = 0;
    for (int i = 0, j = 0; ; i += 1, j += 7) {
        b = src[offset++];
        if ((b & 0x80) != 0) {
            data |= (ulong)(b & 0x7F) << j;
        } else {
            data |= (ulong)b << j;
            break;
        }
        if (i >= 9 && b > 0) {
            throw new Exception("overflow");
        }
    }
    return data;
}
```