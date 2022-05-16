using Spine;
using Spine.Unity;

public interface IAnimalAnimationHandler
{
    void SetUpAnimation(SkeletonAnimation animation, SkeletonDataAsset skeletonDataAsset);
    void PlayAnimation(string name, bool isLoop = false);
    void PlayAnimation(int id, bool isLoop = false);

    void PlayIdleAnimation();

    void PlaySadAnimation();

    void PlayHappyAnimation();

    void SetTailAttachment(Attachment animationAsset);
    Attachment GetTailAttachment(SkeletonData skeletonData);
}