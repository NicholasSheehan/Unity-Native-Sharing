#import "UnityAppController.h"

@interface iOSNativeShare : UIViewController
{
    UINavigationController *navController;
}


struct ConfigStruct {
    char* title;
    char* message;
};

struct SocialSharingStruct {
    char* text;
    char* url;
    char* image;
    char* subject;
};


#ifdef __cplusplus
extern "C" {
#endif
    
    void showAlertMessage(struct ConfigStruct *confStruct);
    void showSocialSharing(struct SocialSharingStruct *confStruct);
    
#ifdef __cplusplus
}
#endif


@end