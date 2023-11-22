CFLAGS += -arch x86_64 -arch arm64
LINKFLAGS += -shared -framework Foundation -framework Cocoa -framework UniformTypeIdentifiers

NativeMessageBoxMac.dylib: NativeMessageBoxMac.m
	clang -o $@ $^ $(CFLAGS) $(LINKFLAGS)
