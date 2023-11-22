CFLAGS += -arch x86_64 -arch arm64
LINKFLAGS += -shared -framework Foundation -framework Cocoa -framework UniformTypeIdentifiers

FileExplorerMac.dylib: FileExplorerMac.m
	clang -o $@ $^ $(CFLAGS) $(LINKFLAGS)