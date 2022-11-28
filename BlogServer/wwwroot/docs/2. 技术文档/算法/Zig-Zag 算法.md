### 用途：
用于压缩小负数，例如int a = -1，可以把4b压为1b   
搭配Varint算法一起使用  

### 说明：
关键词是RotateSignMsb & RotateSignLsb  
``` csharp
static ulong WriteZigZag(long value) {
    bool isNegative = value < 0;
    ulong uv = (ulong)value;
    unchecked {
        if (isNegative) {
            return ((~uv + 1ul) << 1) + 1ul;
        } else {
            return uv << 1;
        }
    }
}

static long ReadZigZag(long value) {
    bool isNegative = value % 2 != 0;
	unchecked {
	    if (isNegative) {
		return (~(value >> 1) + 1ul) | 0x8000_0000_0000_0000ul;
	    } else {
		return value >> 1;
	}
    }
}
```