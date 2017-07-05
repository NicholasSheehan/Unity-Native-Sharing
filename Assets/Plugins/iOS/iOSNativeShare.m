#import "iOSNativeShare.h"

@implementation iOSNativeShare{
}

#ifdef UNITY_4_0 || UNITY_5_0

#import "iPhone_View.h"

#else

extern UIViewController* UnityGetGLViewController();

#endif

+(id) withTitle:(char*)title withMessage:(char*)message{
	
	return [[iOSNativeShare alloc] initWithTitle:title withMessage:message];
}

-(id) initWithTitle:(char*)title withMessage:(char*)message{
	
	self = [super init];
	
	if( !self ) return self;
	
	ShowAlertMessage([[NSString alloc] initWithUTF8String:title], [[NSString alloc] initWithUTF8String:message]);
	
	return self;
	
}

void ShowAlertMessage (NSString *title, NSString *message){
	
	UIAlertView *alert = [[UIAlertView alloc] initWithTitle:title
	                      
	                      message:message
	                      
	                      delegate:nil
	                      
	                      cancelButtonTitle:@"OK"
	                      
	                      otherButtonTitles: nil];
	
	[alert show];
	
}

+(id) withText:(char*)text withFilePaths:(char*)filePaths withSubject:(char*)subject{
	
	return [[iOSNativeShare alloc] initWithText:text withFilePaths:filePaths withSubject:subject];
}

-(id) initWithText:(char*)text withFilePaths:(char*)filePaths withSubject:(char*)subject{
	
	self = [super init];
	
	if( !self ) return self;
	
	
	
    NSString *mText = text ? [[NSString alloc] initWithUTF8String:text] : nil;
	
    NSString *mSubject = subject ? [[NSString alloc] initWithUTF8String:subject] : nil;
	
    NSString *mfilePath = filePaths ? [[NSString alloc] initWithUTF8String:filePaths] : nil;
    
	
	NSMutableArray *items = [NSMutableArray new];
	
	if(mText != NULL && mText.length > 0){
		
		[items addObject:mText];
		
	}
	
	if(mfilePath != NULL && mfilePath.length > 0){
        NSArray *paths = [mfilePath componentsSeparatedByString:@";"];
		int i;
		for (i = 0; i < [paths count]; i++) {
			NSString *path = [paths objectAtIndex:i];
			
			if([path hasPrefix:@"http"])
			{
				NSURL *url = [NSURL URLWithString:path];
				NSError *error = nil;
				NSData *dataImage = [NSData dataWithContentsOfURL:url options:0 error:&error];
				
				if (!error) {
					UIImage *imageFromUrl = [UIImage imageWithData:dataImage];
					[items addObject:imageFromUrl];
				} else {
					[items addObject:url];
				}
			}
			else if ( [self isStringValideBase64:path]){
                NSData* imageBase64Data = [[NSData alloc]initWithBase64EncodedString:path options:0];
				UIImage* image = [UIImage imageWithData:imageBase64Data];
				if (image != nil){
					[items addObject:image];
				}
				else{
					NSURL *formattedURL = [NSURL fileURLWithPath:path];
					[items addObject:formattedURL];
				}
			}
			else{
				NSFileManager *fileMgr = [NSFileManager defaultManager];
				if([fileMgr fileExistsAtPath:path]){
					NSData *dataImage = [NSData dataWithContentsOfFile:path];
					UIImage *imageFromUrl = [UIImage imageWithData:dataImage];
					if (imageFromUrl != nil){
						[items addObject:imageFromUrl];
                    }else{
						NSURL *formattedURL = [NSURL fileURLWithPath:path];
						[items addObject:formattedURL];
					}
				}else{
                    ShowAlertMessage(@"Error", [NSString stringWithFormat:@"Cannot find file %@", path]);
				}
			}
		}
	}
	
	UIActivityViewController *activity = [[UIActivityViewController alloc] initWithActivityItems:items applicationActivities:Nil];
	
    if(mSubject != NULL) {
        [activity setValue:mSubject forKey:@"subject"];
    } else {
        [activity setValue:@"" forKey:@"subject"];
    }
	
	UIViewController *rootViewController = UnityGetGLViewController();
    //if iPhone
    if (UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPhone) {
          [rootViewController presentViewController:activity animated:YES completion:Nil];
    }
    //if iPad
    else {
        // Change Rect to position Popover
        UIPopoverController *popup = [[UIPopoverController alloc] initWithContentViewController:activity];
        [popup presentPopoverFromRect:CGRectMake(rootViewController.view.frame.size.width/2, rootViewController.view.frame.size.height/4, 0, 0)inView:rootViewController.view permittedArrowDirections:UIPopoverArrowDirectionAny animated:YES];
    }
    return self;
}

-(BOOL) isStringValideBase64:(NSString*)string{
    
    NSString *regExPattern = @"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$";
    
    NSRegularExpression *regEx = [[NSRegularExpression alloc] initWithPattern:regExPattern options:NSRegularExpressionCaseInsensitive error:nil];
    NSUInteger regExMatches = [regEx numberOfMatchesInString:string options:0 range:NSMakeRange(0, [string length])];
    return regExMatches != 0;
}

# pragma mark - C API
iOSNativeShare* instance;

void showAlertMessage(struct ConfigStruct *confStruct) {
	instance = [iOSNativeShare withTitle:confStruct->title withMessage:confStruct->message];
}

void showSocialSharing(struct SocialSharingStruct *confStruct) {
	instance = [iOSNativeShare withText:confStruct->text withFilePaths:confStruct->filePaths withSubject:confStruct->subject];
}

@end
