#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>
#import <UniformTypeIdentifiers/UniformTypeIdentifiers.h>
#import <Cocoa/Cocoa.h>

int ShowYesNoCancelMessage(const char *text, const char *caption)
{
    NSAlert *alert = [[NSAlert alloc] init];
    [alert setMessageText:[NSString stringWithUTF8String:caption]];
    [alert setInformativeText:[NSString stringWithUTF8String:text]];
    [alert addButtonWithTitle:@"Yes"];
    [alert addButtonWithTitle:@"No"];
    [alert addButtonWithTitle:@"Cancel"];

    // Display the alert and capture the response
    NSModalResponse response = [alert runModal];
    
    // Check the user's response and return an integer value
    switch (response)
    {
        case NSAlertFirstButtonReturn:
            // Code to handle Yes option
            return 6;
            
        case NSAlertSecondButtonReturn:
            // Code to handle No option
            return 7;
            
        case NSAlertThirdButtonReturn:
            // Code to handle Cancel option
            return 2;
            
        default:
            // Default case, return 0 or handle other cases
            return 0;
    }
}

int ShowYesNoMessage(const char *text, const char *caption)
{
    NSAlert *alert = [[NSAlert alloc] init];
    [alert setMessageText:[NSString stringWithUTF8String:caption]];
    [alert setInformativeText:[NSString stringWithUTF8String:text]];
    [alert addButtonWithTitle:@"Yes"];
    [alert addButtonWithTitle:@"No"];

    // Display the alert and capture the response
    NSModalResponse response = [alert runModal];
    
    // Check the user's response and return an integer value
    switch (response)
    {
        case NSAlertFirstButtonReturn:
            // Code to handle Yes option
            return 6;
            
        case NSAlertSecondButtonReturn:
            // Code to handle No option
            return 7;

        default:
            // Default case, return 0 or handle other cases
            return 0;
    }
}

int ShowOkMessage(const char *text, const char *caption)
{
    NSAlert *alert = [[NSAlert alloc] init];
    [alert setMessageText:[NSString stringWithUTF8String:caption]];
    [alert setInformativeText:[NSString stringWithUTF8String:text]];
    [alert addButtonWithTitle:@"Ok"];

    // Display the alert and capture the response
    NSModalResponse response = [alert runModal];
    
    // Check the user's response and return an integer value
    switch (response)
    {
        case NSAlertFirstButtonReturn:
            // Code to handle Ok option
            return 1;

        default:
            // Default case, return 0 or handle other cases
            return 0;
    }
}
