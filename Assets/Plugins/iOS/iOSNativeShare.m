#import "iOSNativeShare.h"

@implementation iOSNativeShare{
}

//Grab the Unity3D ViewController (UnityGetGLViewController())

#ifdef UNITY_4_0

//Unity4

#import "iPhone_View.h"

#else

//Unity3.5

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

+(id) withText:(char*)text withURL:(char*)url withImage:(char*)image withSubject:(char*)subject{
	
	return [[iOSNativeShare alloc] initWithText:text withURL:url withImage:image withSubject:subject];
}

-(id) initWithText:(char*)text withURL:(char*)url withImage:(char*)image withSubject:(char*)subject{
	
	self = [super init];
	
	if( !self ) return self;
	
	
	
	NSString *mText = [[NSString alloc] initWithUTF8String:text];
	
	NSString *mUrl = [[NSString alloc] initWithUTF8String:url];
	
	NSString *mImage = [[NSString alloc] initWithUTF8String:image];
	
	NSString *mSubject = [[NSString alloc] initWithUTF8String:subject];
	
	
	NSMutableArray *items = [NSMutableArray new];
	
	if(mText != NULL && mText.length > 0){
		
		[items addObject:mText];
		
	}
	
	if(mUrl != NULL && mUrl.length > 0){
		
		NSURL *formattedURL = [NSURL URLWithString:mUrl];
		
		[items addObject:formattedURL];
		
	}
	if(mImage != NULL && mImage.length > 0){
		
		// For image from Web Url
		
		if([mImage hasPrefix:@"http"])
			
		{
			
			NSURL *urlImage = [NSURL URLWithString:mImage];
			
			// NSLog(@"Enter urlImage");
			
			NSData *dataImage = [NSData dataWithContentsOfURL:urlImage];
			
			// NSLog(@"Enter data %d",dataImage.length);
			
			UIImage *imageFromUrl = [UIImage imageWithData:dataImage];
			
			// NSLog(@"Enter data %f",imageFromUrl.size.height);
			
			[items addObject:imageFromUrl];
			
		}else{
			NSFileManager *fileMgr = [NSFileManager defaultManager];
			if([fileMgr fileExistsAtPath:mImage]){
				
				NSData *dataImage = [NSData dataWithContentsOfFile:mImage];
				
				// NSLog(@"Enter data %d",dataImage.length);
				
				UIImage *imageFromUrl = [UIImage imageWithData:dataImage];
				
				// NSLog(@"Enter data %f",imageFromUrl.size.height);
				
				[items addObject:imageFromUrl];
				
			}else{
				ShowAlertMessage(@"Error", @"Cannot find image");
			}
		}
	}
	
	UIActivityViewController *activity = [[UIActivityViewController alloc] initWithActivityItems:items applicationActivities:Nil];
	
	[activity setValue:mSubject forKey:@"subject"];
	
	UIViewController *rootViewController = UnityGetGLViewController();
	[rootViewController presentViewController:activity animated:YES completion:Nil];
	
	return self;
}

# pragma mark - C API
iOSNativeShare* instance;

void showAlertMessage(struct ConfigStruct *confStruct) {
	instance = [iOSNativeShare withTitle:confStruct->title withMessage:confStruct->message];
}

void showSocialSharing(struct SocialSharingStruct *confStruct) {
	instance = [iOSNativeShare withText:confStruct->text withURL:confStruct->url withImage:confStruct->image withSubject:confStruct->subject];
}

@end