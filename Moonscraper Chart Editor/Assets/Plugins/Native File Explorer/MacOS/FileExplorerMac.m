#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>
#import <UniformTypeIdentifiers/UniformTypeIdentifiers.h>

NSMutableArray<UTType *> *extensionsToUttype(const char *extensions) {
    NSMutableArray<UTType *> *array = [NSMutableArray array];
    for (NSString *extension in [[NSString stringWithUTF8String:extensions] componentsSeparatedByString:@";"]) {
        [array addObject:[UTType typeWithFilenameExtension:extension]];
    }
    return array;
}

const char *FileExplorerMac_OpenFile(const char *title, const char *extensions) {
    NSOpenPanel *openPanel = [NSOpenPanel openPanel];
    openPanel.allowedContentTypes = extensionsToUttype(extensions);
    openPanel.allowsMultipleSelection = NO;
    openPanel.canChooseDirectories = NO;
    openPanel.canChooseFiles = YES;
    openPanel.canSelectHiddenExtension = YES;
    openPanel.title = [NSString stringWithUTF8String:title];
    if ([openPanel runModal] == NSModalResponseOK) {
        return strdup(openPanel.URL.relativePath.UTF8String);
    }
    else {
        return NULL;
    }
}

const char *FileExplorerMac_OpenFolder() {
    NSOpenPanel *openPanel = [NSOpenPanel openPanel];
    openPanel.allowsMultipleSelection = NO;
    openPanel.canChooseDirectories = YES;
    openPanel.canChooseFiles = NO;
    if ([openPanel runModal] == NSModalResponseOK) {
        return strdup(openPanel.URL.relativePath.UTF8String);
    }
    else {
        return NULL;
    }
}

const char *FileExplorerMac_SaveFile(const char *title, const char *extensions) {
    NSSavePanel *savePanel = [NSSavePanel savePanel];
    savePanel.allowedContentTypes = extensionsToUttype(extensions);
    savePanel.canCreateDirectories = YES;
    savePanel.canSelectHiddenExtension = YES;
    savePanel.title = [NSString stringWithUTF8String:title];
    if ([savePanel runModal] == NSModalResponseOK) {
        return strdup(savePanel.URL.relativePath.UTF8String);
    }
    else {
        return NULL;
    }
}